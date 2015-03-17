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

            IController controller = null;
            var area = requestContext.RouteData.DataTokens["area"];

            if (area != null)
            {
                //match the requested controller with an exported controller
                controller = controllers
                    .Where(c => c.Metadata.Controller.Equals(controllerName, StringComparison.OrdinalIgnoreCase) && c.Metadata.PluginID.Equals(area.ToString(),StringComparison.OrdinalIgnoreCase))
                    .Select(c => c.Value)
                    .FirstOrDefault();
            }
            else
            {
                //match the requested controller with an exported controller
                controller = controllers
                    .Where(c => c.Metadata.Controller.Equals(controllerName, StringComparison.OrdinalIgnoreCase))
                    .Select(c => c.Value)
                    .FirstOrDefault();
            }
            

            return controller ?? base.CreateController(requestContext, controllerName);
        }

        #endregion
    }
}
