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
 * File Name: LinguistDataAnnotationsModelMetadataProvider.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      09.08.2011 12:27 AM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Beethoven.Plugins.Linguist
{
    /// <summary>
    /// Model metadata provider that renders properties to be localized by Linguist.
    /// </summary>
    public class LinguistDataAnnotationsModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        /// <summary>
        /// Gets metadata about specified property
        /// </summary>
        /// <param name="attributes"></param>
        /// <param name="containerType"></param>
        /// <param name="modelAccessor"></param>
        /// <param name="modelType"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>        
        protected override ModelMetadata CreateMetadata(
                 IEnumerable<Attribute> attributes,
                 Type containerType,
                 Func<object> modelAccessor,
                 Type modelType,
                 string propertyName)
        {
            var meta = base.CreateMetadata
                (attributes, containerType, modelAccessor, modelType, propertyName);

            if (string.IsNullOrEmpty(propertyName))
                return meta;
            
            if (string.IsNullOrEmpty(meta.DisplayName))
                meta.DisplayName = "{" + string.Format("Linguist.{0}.{1}", containerType.Name, propertyName) + "}";

            return meta;
        }
    }
}