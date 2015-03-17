/*  
    Beethoven - A lightweight framework for building plugin based web applications using Asp.Net MVC and MEF.
  
    "Whatever happens SPARTAN's code must stand ... or at least crash responsibly."
  
    The MIT License (MIT)
    
    Copyright (C) 2011 Mehmetali Shaqiri (mehmetalishaqiri@gmail.com)
 
    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:
    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.
    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE. 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public CompositionContainer CreateCompositionContainer(Assembly currentAssembly)
        {
            //= new DirectoryCatalog(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, GlobalConstants.Bin));
            string plugins = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, GlobalConstants.Plugins);

            if (!Directory.Exists(plugins))
                Directory.CreateDirectory(plugins);

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

            catalog.Catalogs.Add(new AssemblyCatalog(currentAssembly));

            return new CompositionContainer(catalog);
        }
    }
}
