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
using System.Text;
using System.Web.Mvc;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;

namespace Beethoven
{
    /// <summary>
    /// DependencyResolver should delegate to the underlying dependency injection container to provide the 
    /// registered service for the requested type. 
    /// When there are no registered services of the requested type, 
    /// the ASP.NET MVC framework expects implementations of this interface to return null from GetService 
    /// and to return an empty collection from GetServices.
    /// </summary>
    internal sealed class DependencyResolver : IDependencyResolver
    {
        #region Private Members

        /// <summary>
        /// 
        /// </summary>
        private readonly CompositionContainer _container;


        #endregion

        #region Ctors

        /// <summary>
        /// Initializes a new instance of <see cref="LCMSDependencyResolver"/>
        /// </summary>
        /// <param name="container">The current composition container</param>
        public DependencyResolver(CompositionContainer container)
        {
            this._container = container;
        }

        #endregion

        #region IDependencyResolver Members

        /// <summary>
        /// Gets an instances of the service of the specified type.
        /// </summary>
        /// <param name="serviceType">The type of the given service</param>
        /// <returns>An instance of the service of the specified type.</returns>
        public object GetService(Type serviceType)
        {
            try
            {
                //get the exported object with the specified contract name
                return _container.GetExportedValue<object>(AttributedModelServices.GetContractName(serviceType));
            }
            catch (Exception ex)
            {
                //When there are no registered services of the requested type, 
                //the ASP.NET MVC framework expects to return null                
                return null;
                //throw ex;
            }
        }



        /// <summary>
        ///  Gets all instances of the services of the specified type.
        /// </summary>
        /// <param name="serviceType">The type</param>
        /// <returns>An enumerable of all instances of the services of the specified type.</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                //Get All the exported objects with the specified contract name
                return _container.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
            }
            catch (Exception ex)
            {
                //When there are no registered services of the requested type, 
                //the ASP.NET MVC framework expects to return an empty collection                
                return null;
                //throw ex;
            }
        }


        #endregion
    }
}
