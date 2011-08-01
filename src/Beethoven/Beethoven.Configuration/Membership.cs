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
 * File Name: Membership.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      30.07.2011 09:00 PM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Beethoven.Configuration
{
    public class Membership : ConfigurationElement
    {
        

        [ConfigurationProperty("DefaultPassword", IsRequired = true)]
        public string DefaultPassword
        {
            get { return (string)base["DefaultPassword"]; }
            set { base["DefaultPassword"] = value; }
        }

        [ConfigurationProperty("AllowSignUp", IsRequired = true)]
        public bool AllowSignUp
        {
            get { return (bool)base["AllowSignUp"]; }
            set { base["AllowSignUp"] = value; }
        }
    }
}
