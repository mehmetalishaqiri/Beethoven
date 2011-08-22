﻿/*
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
 * File Name: Plugin.cs
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
using Beethoven.Plugins.MetaData;
using Beethoven.Plugins.Menu;

namespace Beethoven.Plugins
{
    /// <summary>
    /// Represents a plugin
    /// </summary>
    public class Plugin:IPluginMetadata
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        public string PluginName { get; set; }

        /// <summary>
        /// Gets the ID of the Plugin.
        /// </summary>
        public string PluginID { get; set; }

        /// <summary>
        /// Gets the Version of the Plugin.
        /// </summary>
        public string Version { get; set; }


        /// <summary>
        /// The name of the controller
        /// </summary>
        public string Controller { get; set; }

        /// <summary>
        /// The display order of plugin
        /// </summary>
        public int OrderNumber { get; set; }

        /// <summary>
        /// Menu items of a plugin
        /// </summary>
        public List<MenuItem> MenuItems { get; set; }
    }
}
