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
 * File Name: LinguistRequiredAttributeAdapter.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      09.08.2011 01:01 AM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Beethoven.Plugins.Linguist
{
    /// <summary>
    /// Provides an adapter for the required attribute.
    /// </summary>
    public class LinguistRequiredAttributeAdapter : RequiredAttributeAdapter
    {
        public LinguistRequiredAttributeAdapter(ModelMetadata metadata, ControllerContext context, RequiredAttribute attribute)
            : base(metadata, context, attribute) { }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            string errorMessage;            

            errorMessage = String.Format("{0} ", Metadata.DisplayName) + " {Linguist.Validation.RequiredField}";

            return new[] { new ModelClientValidationRequiredRule(errorMessage) };
        }

       
    }
}
