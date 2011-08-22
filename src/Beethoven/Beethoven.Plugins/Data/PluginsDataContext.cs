/*
 * Beethoven.Plugins
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
 * File Name: PluginsDataContext.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Beethoven.Configuration;
using System.Configuration;
using Beethoven.Plugins.Widgets;
using Beethoven.Plugins.Security;

namespace Beethoven.Plugins.Data
{
    public class PluginsDataContext : DbContext
    {
        private readonly BeethovenConfiguration _configuration = ConfigurationManager.GetSection("BeethovenConfiguration") as BeethovenConfiguration;

        public PluginsDataContext()
        {
            base.Database.Connection.ConnectionString = _configuration.DataSource.ConnectionString;
        }

        public IDbSet<Widget> Widgets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Widget>().ToTable("Widgets");

            base.OnModelCreating(modelBuilder);
        }
    }  

}
