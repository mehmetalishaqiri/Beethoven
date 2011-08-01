/*
 * Beethoven.Configuration
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
 * File Name: AudiLog.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      30.07.2011 08:50 PM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Beethoven.Configuration
{
    /// <summary>
    /// Represents a configuration element within a configuration file - whether the log is enabled or not.
    /// </summary>
    public class AudiLog : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets the status of the log in web configuration section
        /// </summary>
        [ConfigurationProperty("Enabled", IsRequired = true)]
        public bool Enabled
        {
            get { return (bool)base["Enabled"]; }
            set { base["Enabled"] = value; }
        }
    }
}
