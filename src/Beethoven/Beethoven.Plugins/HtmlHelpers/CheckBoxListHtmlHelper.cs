/*
 * Beethoven - A lightweight framework for building plugin based 
 * web applications using Asp.Net MVC and MEF.
 * 
 * Written for .NET 4.0 in C#
 * 
 * Copyright (C) 2009, 2010, 2011. All Right Reserved, Spartansoft L.L.C.
 * http://spartansoft.org
 * 
 * Proprietary and Confidential information of Spartansoft L.L.C. 
 * Redistribution and use in source and binary forms, with or without modification, 
 * without the authorization of Spartansoft L.L.C.  is prohibited. * 
 * 
 * "Whatever happens SPARTAN's code must stand ... or at least crash responsibly."
 *  
 * File Name: CheckBoxListHtmlHelper.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      29.07.2011 10:40 PM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Beethoven.Plugins.Controls;
using System.Linq.Expressions;
using System.Web.Routing;

namespace Beethoven.Plugins.HtmlHelpers
{
    public static class CheckBoxListHtmlHelper
    {
        public static IHtmlString CheckBoxListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper, 
            Expression<Func<TModel, TProperty[]>> expression, 
            MultiSelectList multiSelectList, 
            object htmlAttributes = null)
        {
            //Derive property name for checkbox name
            MemberExpression body = expression.Body as MemberExpression;
            string propertyName = body.Member.Name;

            //Get currently select values from the ViewData model
            TProperty[] list = expression.Compile().Invoke(htmlHelper.ViewData.Model);

            //Convert selected value list to a List<string> for easy manipulation
            List<string> selectedValues = new List<string>();

            if (list != null)
            {
                selectedValues = new List<TProperty>(list).ConvertAll<string>(delegate(TProperty i) { return i.ToString(); });
            }

            //Create div
            TagBuilder divTag = new TagBuilder("div");
            divTag.MergeAttributes(new RouteValueDictionary(htmlAttributes), true);

            //Add checkboxes
            foreach (SelectListItem item in multiSelectList)
            {
                divTag.InnerHtml += String.Format("<div><input type=\"checkbox\" name=\"{0}\" id=\"{0}_{1}\" " +
                                                    "value=\"{1}\" {2} /><label for=\"{0}_{1}\">{3}</label></div>",
                                                    propertyName,
                                                    item.Value,
                                                    selectedValues.Contains(item.Value) ? "checked=\"checked\"" : "",
                                                    item.Text);
            }

            return MvcHtmlString.Create(divTag.ToString());
        }


        public static IHtmlString CheckboxList(this HtmlHelper html, string name, List<CheckBoxListInfo> lInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table class='grid'>");

            foreach (var item in lInfo)
            {
                sb.Append("<tr><td>");
                TagBuilder tBuilder = new TagBuilder("input");
                if (item.IsChecked) 
                    tBuilder.MergeAttribute("checked", "checked");
                tBuilder.MergeAttribute("type", "checkbox");
                tBuilder.MergeAttribute("value", item.Value);
                tBuilder.MergeAttribute("name", name);
                tBuilder.InnerHtml = item.DisplayText;
                sb.Append(tBuilder.ToString(TagRenderMode.Normal));
                sb.Append("</td></tr>");
            }
            sb.Append("</table>");

            return MvcHtmlString.Create(sb.ToString());
        }
    }
}
