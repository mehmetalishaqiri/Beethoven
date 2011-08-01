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
 * File Name: MetaTags.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      30.07.2011 09:10 PM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Beethoven.Configuration
{
    public class MetaTags : ConfigurationElement
    {      

        [ConfigurationProperty("MetaLanguage", IsRequired = true)]
        public string MetaLanguage
        {
            get { return (string)base["MetaLanguage"]; }
            set { base["MetaLanguage"] = value; }
        }

        [ConfigurationProperty("MetaGenerator", IsRequired = true)]
        public string MetaGenerator
        {
            get { return (string)base["MetaGenerator"]; }
            set { base["MetaGenerator"] = value; }
        }

        [ConfigurationProperty("MetaDescription", IsRequired = true)]
        public string MetaDescription
        {
            get { return (string)base["MetaDescription"]; }
            set { base["MetaDescription"] = value; }
        }

        [ConfigurationProperty("MetaKeywords", IsRequired = true)]
        public string MetaKeywords
        {
            get { return (string)base["MetaKeywords"]; }
            set { base["MetaKeywords"] = value; }
        }

        [ConfigurationProperty("Copyright", IsRequired = true)]
        public string Copyright
        {
            get { return (string)base["Copyright"]; }
            set { base["Copyright"] = value; }
        }

    }
}