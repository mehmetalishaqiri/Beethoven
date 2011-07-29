/*
 * Beethoven - A lightweight framework for building plugin based 
 * web applications using Asp.Net MVC and MEF.
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
 * File Name: CompositionContainerFactory.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      29.07.2011 06:06 PM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using Beethoven.Plugins.Shared;

namespace Beethoven
{
    /// <summary>
    /// Creates a composition container.
    /// </summary>
    internal sealed class CompositionContainerFactory : ICompositionContainerFactory
    {


        /// <summary>
        /// Creates a <see cref="CompositionContainer"/>
        /// The composition container coordinates creation and satisfies dependencies.
        /// </summary>
        /// <param name="path">The path of the assemblies.</param>
        /// <returns>An instance of <see cref="CompositionContainer"/></returns>
        public CompositionContainer CreateCompositionContainer()
        {
            //= new DirectoryCatalog(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, GlobalConstants.Bin));
            string plugins = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, GlobalConstants.Plugins);


            string[] dirs = Directory.GetDirectories(plugins)
                .Union(
                new[] { 
                    plugins, 
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, GlobalConstants.Bin)
                }).ToArray();

            AggregateCatalog catalog = new AggregateCatalog(
                from dir in dirs
                select new DirectoryCatalog(
                    Path.Combine(GlobalConstants.Plugins, dir)));


            return new CompositionContainer(catalog);
        }
    }
}
