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
 * Date Created:
 *      03.08.2011 10:38 PM
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

using System.ComponentModel.Composition;
namespace Beethoven.Plugins.Data
{
    public class PluginsDataContextInitializer : IDatabaseInitializer<PluginsDataContext>
    {
        //private readonly List<Capability> _capabilities;

        //[ImportingConstructor]
        //public PluginsDataContextInitializer(List<Capability> capabilities)
        //{
        //    _capabilities = capabilities;
        //}

        public void InitializeDatabase(PluginsDataContext context)
        {
            //if (_capabilities != null)
            //{
            //    _capabilities.ForEach(capability => context.Capabilities.Add(capability));
            //}
        }
    }
}
