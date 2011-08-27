/*
 * DeepThought.Account
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
 * File Name: DeepThoughtDataContext.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beethoven.Configuration;
using System.Configuration;
using System.Data.Entity;


namespace Beethoven.Plugins.Security
{
    public class SecurityDataContext : DbContext
    {
        private readonly BeethovenConfiguration _configuration = ConfigurationManager.GetSection("BeethovenConfiguration") as BeethovenConfiguration;

        public SecurityDataContext()
        {
            base.Database.Connection.ConnectionString = _configuration.DataSource.ConnectionString;
        }

        public IDbSet<Capability> Capabilities { get; set; }

        public IDbSet<RoleCapability> RoleCapabilities { get; set; }

        public IDbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Capability>().ToTable("Capabilities");

            modelBuilder.Entity<RoleCapability>().ToTable("RoleCapabilities");

            modelBuilder.Entity<Role>().ToTable("aspnet_Roles");

            base.OnModelCreating(modelBuilder);
        }
    }
}
