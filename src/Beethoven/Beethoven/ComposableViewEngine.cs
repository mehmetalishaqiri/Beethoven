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
 * File Name: ComposableViewEngine.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      29.07.2011 06:06 PM
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Beethoven.Plugins.Shared;
using System.Web;

namespace Beethoven
{
    /// <summary>
    /// Represents a view engine that is used to render a Web page that uses the ASP.NET Razor syntax.
    /// </summary>
    public class ComposableViewEngine : RazorViewEngine
    {
        #region Fields

        /// <summary>
        /// List of available plugins
        /// </summary>
        private List<string> _plugins;

        #endregion

        #region CTOR

        /// <summary>
        /// Set the location of views, master pages, and partial views
        /// </summary>
        /// <param name="plugins">List of available plugins</param>
        public ComposableViewEngine(List<string> plugins)
        {
            _plugins = plugins;

            ViewLocationFormats = ViewLocationFormats.Union(GetViewLocations()).ToArray();

            MasterLocationFormats = MasterLocationFormats.Union(GetMasterLocations()).ToArray();

            PartialViewLocationFormats = PartialViewLocationFormats.Union(GetViewLocations().Union(GetMasterLocations())).ToArray();
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Construct locations of views based on available plugins
        /// </summary>
        /// <returns>View Location Formats</returns>
        string[] GetViewLocations()
        {
            List<string> views = new List<string>();
            _plugins.ForEach(plugin =>
                views.Add("~/" + GlobalConstants.Plugins + "/" + plugin + ".dll/Views/{1}/{0}.cshtml")
            );
            return views.ToArray();
        }


        /// <summary>
        /// Construct locations of master pages based on available plugins
        /// </summary>
        /// <returns>Master Location Formats</returns>
        string[] GetMasterLocations()
        {
            List<string> masterPages = new List<string>();

            masterPages.Add("~/Views/Shared/{0}.cshtml");

            _plugins.ForEach(plugin =>
                masterPages.Add("~/" + GlobalConstants.Plugins + "/" + plugin + "/Views/Shared/{0}.cshtml")
            );

            return masterPages.ToArray();
        }

        #endregion                         
    }
}
