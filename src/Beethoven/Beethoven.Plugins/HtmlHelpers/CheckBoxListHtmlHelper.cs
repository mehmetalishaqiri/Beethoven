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

namespace Beethoven.Plugins.HtmlHelpers
{
    public static class CheckBoxListHtmlHelper
    {
        public static IHtmlString CheckboxList(this HtmlHelper html, string name, List<CheckBoxListInfo> lInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table class='grid'>");

            foreach (var item in lInfo)
            {
                sb.Append("<tr><td>");
                TagBuilder tBuilder = new TagBuilder("input");
                if (item.IsChecked) tBuilder.MergeAttribute("checked", "checked");
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
