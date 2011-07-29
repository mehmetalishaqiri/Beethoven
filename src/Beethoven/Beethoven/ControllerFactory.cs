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
 * File Name: ControllerFactory.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      29.07.2011 09:20 PM
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Web.SessionState;
using System.Web.Routing;
using System.Reflection;
using Beethoven.Plugins.MetaData;

namespace Beethoven
{
    /// <summary>
    /// Creates instances of <see cref="IController"/> from exported parts via MEF.
    /// </summary>    
    [Export(typeof(IControllerFactory))]
    public class ControllerFactory : DefaultControllerFactory
    {
        #region Private Members

        private readonly CompositionContainer _container;


        #endregion

        #region CTOR

        /// <summary>
        /// Initialises a new instance of <see cref="ControllerFactory"/>
        /// </summary>
        /// <param name="container">The current controller.</param>
        [ImportingConstructor]
        public ControllerFactory(CompositionContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            this._container = container;
        }

        #endregion

        #region IControllerFactory Members

        /// <summary>
        /// Creates the specified controller by using the specified request context.
        /// </summary>
        /// <param name="requestContext">The context of the HTTP request, which includes the HTTP context and route data.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <returns>A reference to the controller.</returns>
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {

            //Gets all the exports ==> get all the exported controllers with their associated metadata
            IEnumerable<Lazy<IController, IPluginMetadata>> controllers = _container.GetExports<IController, IPluginMetadata>();

            //match the requested controller with an exported controller
            IController controller = controllers
                .Where(c => c.Metadata.Controller.Equals(controllerName, StringComparison.OrdinalIgnoreCase))
                .Select(c => c.Value)
                .FirstOrDefault();

            return controller ?? base.CreateController(requestContext, controllerName);
        }

        #endregion
    }
}
