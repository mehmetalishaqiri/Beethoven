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
 * File Name: BaseController.cs
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
using System.ComponentModel.Composition;
using Beethoven.Plugins.ViewModels;
using System.ComponentModel.Composition.Hosting;
using Beethoven.Plugins.Menu;
using Beethoven.Plugins.MetaData;
using Beethoven.Plugins.Controllers;


namespace Beethoven.Plugins.Controllers
{
    /// <summary>
    /// BaseController is intended to serve as a base class for all controllers in the host/plugins
    /// </summary>    
    public class BaseController : LayoutController<LayoutModel>
    {
        /// <summary>
        /// Import all exported controllers from the composition container
        /// Note: the AllowRecomposition = true ==> This means that as new exports become available in the container, collections are automatically updated with the new set. 
        /// </summary>
        [ImportMany(AllowRecomposition = true)]
        private IEnumerable<Lazy<IController, IPluginMetadata>> _pluginsMetadata { get; set; }


        /// <summary>
        /// Import all exported action methods from the composition container
        /// Note: the AllowRecomposition = true ==> This means that as new exports become available in the container, collections are automatically updated with the new set. 
        /// </summary>
        [ImportMany(AllowRecomposition = true)]
        private IEnumerable<Lazy<ActionResult, IMenuItemMetadata>> _menuItemsMetadata { get; set; }


        /// <summary>
        /// Fill the master page view model with information about plugins and menuitems
        /// </summary>
        /// <returns></returns>
        protected override LayoutModel GetLayoutViewModel()
        {
            //create a new view model for master page
            LayoutModel layoutModel = new LayoutModel();

            if (_pluginsMetadata != null)
            {
                foreach (var plugin in _pluginsMetadata)
                {
                    if (layoutModel.Plugins.Where(p => p.PluginID == plugin.Metadata.PluginID).Count() == 0)
                    {

                        var p = new Plugin
                        {
                            PluginID = plugin.Metadata.PluginID,
                            PluginName = plugin.Metadata.PluginName,
                            Controller = plugin.Metadata.Controller,
                            Version = plugin.Metadata.Version
                        };

                        if (_menuItemsMetadata != null)
                        {
                            var query = _menuItemsMetadata.Where(item =>
                                item.Metadata.PluginID.Equals(plugin.Metadata.PluginID)
                            ).OrderBy(m => m.Metadata.OrderNumber);
                            if (query.Count() > 0)
                            {
                                p.MenuItems = new List<MenuItem>();
                                foreach (var m in query)
                                {
                                    p.MenuItems.Add(new MenuItem
                                    {
                                        PluginID = m.Metadata.PluginID,
                                        ParentID = m.Metadata.ParentID,
                                        Action = m.Metadata.Action,
                                        Controller = m.Metadata.Controller,
                                        DisplayText = m.Metadata.DisplayText,
                                        IsDefault = m.Metadata.IsDefault,
                                        OrderNumber = m.Metadata.OrderNumber
                                    });
                                }
                            }
                        }

                        layoutModel.Plugins.Add(p);
                    }
                }
            }

            return layoutModel;
        }

    }
}
