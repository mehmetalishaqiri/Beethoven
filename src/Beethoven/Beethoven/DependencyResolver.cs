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
 * File Name: DependencyResolver.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      29.07.2011 08:20 PM
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
