/*  
    Beethoven - A lightweight framework for building plugin based web applications using Asp.Net MVC and MEF.
  
    "Whatever happens SPARTAN's code must stand ... or at least crash responsibly."
  
    The MIT License (MIT)
    
    Copyright (C) 2011 Mehmetali Shaqiri (mehmetalishaqiri@gmail.com)
 
    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:
    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.
    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE. 
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
                views.Add("~/" + GlobalConstants.Plugins + "/" + plugin + "/Views/{1}/{0}.cshtml")
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
