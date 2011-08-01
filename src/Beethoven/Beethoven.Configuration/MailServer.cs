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
 * File Name: MailServer.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      30.07.2011 08:55 PM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Beethoven.Configuration
{
    public class MailServer:ConfigurationElement
    {       
       
        [ConfigurationProperty("SmtpServer", IsRequired = true)]
        public string SmtpServer
        {
            get { return (string)base["SmtpServer"]; }
            set { base["SmtpServer"] = value; }
        }

        [ConfigurationProperty("SmtpServerPort", IsRequired = true)]
        public string SmtpServerPort
        {
            get { return (string)base["SmtpServerPort"]; }
            set { base["SmtpServerPort"] = value; }
        }

        [ConfigurationProperty("Username", IsRequired = true)]
        public string Username
        {
            get { return (string)base["Username"]; }
            set { base["Username"] = value; }
        }

        [ConfigurationProperty("Password", IsRequired = true)]
        public string Password
        {
            get { return (string)base["Password"]; }
            set { base["Password"] = value; }
        }

        [ConfigurationProperty("MailFrom", IsRequired = true)]
        public string MailFrom
        {
            get { return (string)base["MailFrom"]; }
            set { base["MailFrom"] = value; }
        }

        public override bool IsReadOnly()
        {
            return false;
        }

    }
}
