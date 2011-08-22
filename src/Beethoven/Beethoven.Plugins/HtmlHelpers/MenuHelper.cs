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
 * File Name: MenuHelper.cs
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
using System.Web.Mvc;
using Beethoven.Plugins.Menu;
using System.Web;

namespace Beethoven.Plugins.HtmlHelpers
{
    /// <summary>
    /// Html helpers for lcms menus
    /// </summary>
    public static class MenuHelper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="menuItems"></param>
        /// <returns></returns>
        public static IHtmlString DisplayPluginMenuItems(this HtmlHelper helper, Plugin plugin)
        {
            StringBuilder sb = new StringBuilder();

            TagBuilder ul = new TagBuilder("ul");

            if (plugin == null || plugin.MenuItems == null)
                return new HtmlString(String.Empty);


            foreach (MenuItem item in plugin.MenuItems)
            {
                TagBuilder li = new TagBuilder("li");
                var link =
                li.InnerHtml = System.Web.Mvc.Html.LinkExtensions.ActionLink(helper, item.DisplayText, item.Action, item.Controller, new { area = item.PluginID }, null).ToString();
                ul.InnerHtml += string.Format("  {0}{1}", li.ToString(), Environment.NewLine);
            }

            sb.Append(ul.ToString(TagRenderMode.Normal));

            return new HtmlString(sb.ToString());
        }

    }
}
