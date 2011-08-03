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
 * File Name: Languages.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      02.08.2011 07:40 AM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Beethoven.Configuration
{
    /// <summary>
    /// Represents a configuration element within a configuration file - The language path in web configuration section.
    /// </summary>
    public class Languages : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets the languages file path in web configuration section
        /// </summary>
        [ConfigurationProperty("Path", IsRequired = true)]
        public string Path
        {
            get { return (string)base["Path"]; }
            set { base["Path"] = value; }
        }
    }
}
