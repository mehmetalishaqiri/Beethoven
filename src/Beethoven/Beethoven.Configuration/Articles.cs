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
 * File Name: Articles.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      30.07.2011 08:48 PM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Beethoven.Configuration
{
    public class Articles : ConfigurationElement
    {

        [ConfigurationProperty("ResourcesPath", IsRequired = true)]
        public string ResourcesPath
        {
            get { return (string)base["ResourcesPath"]; }
            set { base["ResourcesPath"] = value; }
        }

        [ConfigurationProperty("DefaultMasterPage", IsRequired = true)]
        public string DefaultMasterPage
        {
            get { return (string)base["DefaultMasterPage"]; }
            set { base["DefaultMasterPage"] = value; }
        }

        [ConfigurationProperty("ExcerptLength", IsRequired = true)]
        public string ExcerptLength
        {
            get { return (string)base["ExcerptLength"]; }
            set { base["ExcerptLength"] = value; }
        }

        [ConfigurationProperty("DefaultPageSize", IsRequired = true)]
        public string DefaultPageSize
        {
            get { return (string)base["DefaultPageSize"]; }
            set { base["DefaultPageSize"] = value; }
        }

        [ConfigurationProperty("DefaultPageIndex", IsRequired = true)]
        public string DefaultPageIndex
        {
            get { return (string)base["DefaultPageIndex"]; }
            set { base["DefaultPageIndex"] = value; }
        }
    }
}
