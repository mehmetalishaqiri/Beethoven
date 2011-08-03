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
 * File Name: DefaultPlugin.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      02.08.2011 07:35 AM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Beethoven.Configuration
{
    /// <summary>
    /// Represents a configuration element within a configuration file - The Default Plugin
    /// </summary>
    public class DefaultPlugin : ConfigurationElement
    {

        /// <summary>
        /// Gets the Area Name.
        /// </summary>
        [ConfigurationProperty("AreaName", IsRequired = false)]
        public string AreaName
        {
            get { return (string)base["AreaName"]; }
            set { base["AreaName"] = value; }
        }

        /// <summary>
        /// Gets the controller.
        /// </summary>
        [ConfigurationProperty("Controller", IsRequired = true)]
        public string Controller
        {
            get { return (string)base["Controller"]; }
            set { base["Controller"] = value; }
        }

        /// <summary>
        /// Gets the action.
        /// </summary>
        [ConfigurationProperty("Action", IsRequired = true)]
        public string Action
        {
            get { return (string)base["Action"]; }
            set { base["Action"] = value; }
        }

        

    }
}
