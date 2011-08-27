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
 * File Name: WidgetService.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      31.07.2011 05:30 PM
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web.Mvc;
using Beethoven.Plugins.MetaData;
using Beethoven.Plugins.Shared;
using Beethoven.Plugins.Security;
using System.Web;


namespace Beethoven.Plugins.Widgets
{
    [Export(typeof(IWidgetService))]
    public class WidgetService : IWidgetService
    {
        [Import]
        private IWidgetRepository _widgetRepository { get; set; }

        [ImportMany(AllowRecomposition = true)]
        private IEnumerable<Lazy<ActionResult, IWidgetMetadata>> _menuItemsMetadata { get; set; }

        public IEnumerable<Widget> GetAvailableWidgets(string pluginId, Guid userId)
        {
            var userWidgets = GetWidgetsForUser(pluginId, userId);

            var widgets = new List<Widget>();

            bool exists, isAuthorized;
            foreach (var item in _menuItemsMetadata.Where(m =>
                                  m.Metadata.WidgetPluginID == pluginId))
            {
                exists = false;
                isAuthorized = false;

                List<Capability> userCapabilities = (List<Capability>)HttpContext.Current.Session["UserCapabilities"];
                string[] validCapabilities = item.Metadata.Capabilities;
                if (userCapabilities != null && item.Metadata.Capabilities.Length != 0)
                {
                    if (userCapabilities.Any(userCapability => item.Metadata.Capabilities.Contains(userCapability.Name)))
                        isAuthorized = true;
                }

                if (isAuthorized)
                {
                    foreach (var w in userWidgets)
                    {
                        if (item.Metadata.WidgetAlias == w.Alias)
                        {
                            exists = true;
                            break;
                        }
                    }
                    if (!exists)
                    {
                        widgets.Add(new Widget
                        {
                            DisplayText = item.Metadata.WidgetDisplayText,
                            PluginID = item.Metadata.WidgetPluginID,
                            Controller = item.Metadata.WidgetController,
                            Action = item.Metadata.WidgetAction,
                            Alias = item.Metadata.WidgetAlias
                        });
                    }
                }
            }

            return widgets;
        }

        public IEnumerable<Widget> GetWidgetsForUser(string pluginId, Guid userId)
        {
            var userWidgets = _widgetRepository.GetWidgetsForUser(pluginId, userId);

            var widgets = new List<Widget>();

            bool exists, isAuthorized;
            foreach (var item in _menuItemsMetadata.Where(m =>
                                  m.Metadata.WidgetPluginID == pluginId))
            {
                exists = false;
                isAuthorized = false;

                List<Capability> userCapabilities = (List<Capability>)HttpContext.Current.Session["UserCapabilities"];
                string[] validCapabilities = item.Metadata.Capabilities;
                if (userCapabilities != null && item.Metadata.Capabilities.Length != 0)
                {
                    if (userCapabilities.Any(userCapability => item.Metadata.Capabilities.Contains(userCapability.Name)))
                        isAuthorized = true;
                }

                if (isAuthorized)
                {
                    foreach (var w in userWidgets)
                    {
                        if (item.Metadata.WidgetAlias == w.Alias)
                        {
                            widgets.Add(w);
                        }
                    }
                }
            }

            return widgets;
            //return _widgetRepository.GetWidgetsForUser(pluginId, userId);
        }

        public void Add(Widget widget)
        {
            IEnumerable<Widget> widgets = _widgetRepository.GetRelatedWidgets(widget);

            foreach (var item in widgets)
            {
                item.Position++;
            }
            _widgetRepository.Add(widget);

            _widgetRepository.SaveChanges();
        }

        public void Move(Guid id, int column, int position)
        {
            Widget widget = _widgetRepository.GetById(id);

            if (widget.Column == column)
            {
                int from;
                int to;
                bool increment;
                if (widget.Position > position)
                {
                    from = position;
                    to = widget.Position;
                    increment = true;
                }
                else
                {
                    from = widget.Position;
                    to = position;
                    increment = false;
                }

                IEnumerable<Widget> widgets = _widgetRepository.GetInRange(widget.PluginID, widget.UserId, widget.Column, from, to);

                foreach (var item in widgets)
                {
                    if (increment)
                    {
                        item.Position++;
                    }
                    else
                    {
                        item.Position--;
                    }
                }
                widget.Position = position;
            }
            else
            {
                IEnumerable<Widget> widgetsOldColumn = _widgetRepository.GetRelatedWidgets(widget);

                foreach (var item in widgetsOldColumn)
                {
                    item.Position--;
                }

                widget.Column = column;
                widget.Position = position;

                IEnumerable<Widget> widgetsNewColumn = _widgetRepository.GetRelatedWidgets(widget);

                foreach (var item in widgetsNewColumn)
                {
                    item.Position++;
                }

            }
            _widgetRepository.SaveChanges();
        }

        public void Collapse(Guid id)
        {
            Widget widget = _widgetRepository.GetById(id);

            widget.Collapsed = !widget.Collapsed;

            _widgetRepository.SaveChanges();
        }
        public void Close(Guid id)
        {
            Widget widget = _widgetRepository.GetById(id);

            IEnumerable<Widget> widgets = _widgetRepository.GetRelatedWidgets(widget);

            foreach (var item in widgets)
            {
                item.Position--;
            }

            _widgetRepository.Delete(widget);
            _widgetRepository.SaveChanges();
        }
    }
}
