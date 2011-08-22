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
 * File Name: LayoutModel.cs
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
using System.ComponentModel.Composition;
using System.Web.Mvc;
using Beethoven.Plugins.MetaData;
using System.Web;
using System.Web.Routing;
using Beethoven.Plugins.Shared;
using Beethoven.Configuration;
using System.Configuration;


namespace Beethoven.Plugins.ViewModels
{
    /// <summary>
    /// Defines the Layout Model
    /// </summary>   
    public class LayoutModel
    {
        private readonly BeethovenConfiguration _configuration = ConfigurationManager.GetSection("BeethovenConfiguration") as BeethovenConfiguration;

        private string _title;

        public string Title 
        { 
            get { return _title; }
            set { _title = value; }
        }

        

        /// <summary>
        /// All present plugins
        /// </summary>
        public List<Plugin> Plugins { get; set; }


        public LayoutModel()
        {
            //initialize list
            Plugins = new List<Plugin>();

            _title = _configuration.Application.ApplicationName;
        }

        /// <summary>
        /// Gets the current controller from RouteData
        /// </summary>
        public string CurrentController
        {
            get
            {
                return RouteTable.Routes.GetRouteData(new HttpContextWrapper(HttpContext.Current)).Values[GlobalConstants.ControllerInRouteData].ToString();
            }
        }

        /// <summary>
        /// Gets the info about the plugin we're currently working on.
        /// </summary>
        public Plugin CurrentPlugin
        {
            get
            {

                var area = RouteTable.Routes.GetRouteData(new HttpContextWrapper(HttpContext.Current)).DataTokens["area"].ToString();
                var plugin = Plugins.Where(p => p.PluginID.Equals(area)).SingleOrDefault();
                return plugin;
            }
        }

        /// <summary>
        /// Gets the info about the plugin we're currently working on.
        /// </summary>
        public Plugin GetPluginByID(string pluginID)
        {
            return Plugins.Where(p => p.PluginID == pluginID).Distinct(new PluginComparer()).SingleOrDefault();
        }
    }
}
