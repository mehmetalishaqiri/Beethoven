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
 * File Name: DataSource.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      30.07.2011 08:51 PM
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Beethoven.Configuration
{
    public class DataSource:ConfigurationElement
    {

        [ConfigurationProperty("ConnectionString", IsRequired = true)]
        public string ConnectionString
        {
            get { return (string)base["ConnectionString"]; }
            set { base["ConnectionString"] = value; }
        }


        [ConfigurationProperty("ProviderName", IsRequired = true)]
        public string ProviderName
        {
            get { return (string)base["ProviderName"]; }
            set { base["ProviderName"] = value; }
        }

    }
}