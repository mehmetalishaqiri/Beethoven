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
 * File Name: GuardianAttribute.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      03.08.2011 08:00 AM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;

namespace Beethoven.Plugins.Security
{
    /// <summary>
    /// Represents an attributes that is used to restrict access by callers to an action method or controller.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class GuardianAttribute : AuthorizeAttribute
    {
        private string[] _validCapabilities;

        /// <summary>
        /// Valid user capabilities for an action method or controller.
        /// </summary>
        public string[] Capabilities
        {
            get
            {
                return _validCapabilities;
            }
        }

        /// <summary>
        /// Initializes a new instance of Beethoven.Plugins.Security.GuardianAttribute
        /// </summary>
        /// <param name="validCapabilities">Valid user capabilities for an action method or controller.</param>
        public GuardianAttribute(params string[] validCapabilities)
        {
            _validCapabilities = validCapabilities;
        }

        /// <summary>
        /// Called when a process requests authorization.
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (_validCapabilities.Length == 0)
            {
                if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    filterContext.HttpContext.Response.Redirect("~/Account/TheGateway?ReturnUrl=" + filterContext.HttpContext.Request.Url);
                }
            }
            else
            {

                List<Capability> userCapabilities = (List<Capability>)filterContext.HttpContext.Session["UserCapabilities"];

                if (userCapabilities != null && _validCapabilities.Length != 0)
                {
                    if (!userCapabilities.Any(userCapability => _validCapabilities.Contains(userCapability.Name)))
                        filterContext.HttpContext.Response.Redirect("~/Errors/UnAuthorized");
                }
                else if (userCapabilities == null && _validCapabilities.Length != 0)
                {
                    filterContext.HttpContext.Response.Redirect("~/Errors/UnAuthorized");
                }
            }

        }
    }
}
