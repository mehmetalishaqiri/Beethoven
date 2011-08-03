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
 * File Name: BaseDashboardController.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      29.07.2011 10:40 AM
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Beethoven.Plugins.Widgets;

namespace Beethoven.Plugins.Controllers
{
    /// <summary>
    /// BaseDashboardController is intended to serve as a base class for all dashboards in the host/plugins
    /// </summary> 
    public class BaseDashboardController : BaseController
    {
        
        /// <summary>
        /// Used to identify the plugin
        /// </summary>
        private string _pluginID;

        protected BaseDashboardController(string pluginID)
        {
            this._pluginID = pluginID;
        }

        /// <summary>
        /// Import WidgetService from Composition Container
        /// </summary>
        [Import]
        public IWidgetService widgetService { get; set; }

         
        /// <summary>
        /// Add widget to the dashboard
        /// </summary>
        /// <param name="text">The DisplayText of the widget</param>
        /// <param name="plugin">The id of plugin the widget belongs to</param>
        /// <param name="controller">The controller where the widget should point to get the data</param>
        /// <param name="action">The action where the widget should point to get the data</param>
        /// <param name="alias">An alias used to determine the widget image</param>
        /// <returns>The widget content</returns>
        public PartialViewResult AddWidget(string text, string plugin, string controller, string action, string alias)
        {
            Widget widget = new Widget()
            {
                ID = Guid.NewGuid(),
                Column = 0,
                Position = 0,
                Collapsed = false,
                UserId = (Guid)Membership.GetUser().ProviderUserKey,
                DisplayText = text,
                PluginID = plugin,
                Controller = controller,
                Action = action,
                Alias = alias
            };

            widgetService.Add(widget);

            return PartialView("_WidgetContainer", widget);
        }


        /// <summary>
        /// Remove widget from dashboard
        /// </summary>
        /// <param name="id">The id of the widget</param>
        /// <returns></returns>
        public JsonResult CloseWidget(string id)
        {
            widgetService.Close(Guid.Parse(id));

            return Json(true);
        }

        public JsonResult CollapseWidget(string id)
        {
            widgetService.Collapse(Guid.Parse(id));

            return Json(true);
        }

        public JsonResult MoveWidget(string id, int column, int position)
        {
            widgetService.Move(Guid.Parse(id), column, position);

            return Json(true);
        }

        [NonAction]
        public IEnumerable<Widget> LoadWidgets()
        {
            return widgetService.GetWidgetsForUser(_pluginID, (Guid)Membership.GetUser().ProviderUserKey);
        }

        public PartialViewResult GetAvailableWidgets()
        {
            return PartialView("_AvailableWidgets", widgetService.GetAvailableWidgets(_pluginID, (Guid)Membership.GetUser().ProviderUserKey));
        }
    }
}
