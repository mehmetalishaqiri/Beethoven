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
 * File Name: BeethovenConfiguration.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      30.07.2011 09:45 PM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.ComponentModel.Composition;

namespace Beethoven.Configuration
{
    public class BeethovenConfiguration : ConfigurationSection
    {                

        [ConfigurationProperty("Application", IsRequired = true)]
        public Application Application
        {
            get
            {
                return (Application)base["Application"];
            }
        }

        [ConfigurationProperty("Articles", IsRequired = true)]
        public Articles Articles
        {
            get
            {
                return (Articles)base["Articles"];
            }
        }

        [ConfigurationProperty("DataSource", IsRequired = true)]
        public DataSource DataSource
        {
            get
            {
                return (DataSource)base["DataSource"];
            }
        }

        

        [ConfigurationProperty("MailServer", IsRequired = true)]
        public MailServer MailServer
        {
            get
            {
                return (MailServer)base["MailServer"];
            }
        }

        [ConfigurationProperty("MetaTags", IsRequired = true)]
        public MetaTags MetaTags
        {
            get
            {
                return (MetaTags)base["MetaTags"];
            }
        }

        [ConfigurationProperty("Plugins", IsRequired = true)]
        public Plugins Plugins
        {
            get
            {
                return (Plugins)base["Plugins"];
            }
        }


        [ConfigurationProperty("Notifications", IsRequired = true)]
        public Notifications Notifications
        {
            get
            {
                return (Notifications)base["Notifications"];
            }
        }

        /// <summary>
        /// Get the AuditLog configuration from web.config
        /// </summary>
        [ConfigurationProperty("AuditLog", IsRequired = true)]
        public AudiLog AudiLog 
        {
            get
            {
                return (AudiLog)base["AuditLog"];
            }
        }

        [ConfigurationProperty("Membership", IsRequired = true)]
        public Membership Membership
        {
            get
            {
                return (Membership)base["Membership"];
            }
        }

        [ConfigurationProperty("Linguist", IsRequired = true)]
        public Linguist Linguist
        {
            get
            {
                return (Linguist)base["Linguist"];
            }
        }

        [ConfigurationProperty("DefaultPlugin", IsRequired = true)]
        public DefaultPlugin DefaultPlugin
        {
            get
            {
                return (DefaultPlugin)base["DefaultPlugin"];
            }
        }

        public override bool IsReadOnly()
        {
            return false;
        }

      
    }
}
