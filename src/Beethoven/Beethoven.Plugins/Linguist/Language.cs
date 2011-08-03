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
 * File Name: Language.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      01.08.2011 09:20 PM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beethoven.Plugins.Linguist
{
    /// <summary>
    /// Implements the ILanguage interface.
    /// </summary>
    public class Language:ILanguage
    {
        #region ILanguage Members

       
        /// <summary>
        ///  The unique identifier for the language - a querystring parameter.
        /// The application will get this code from querystring and it will translate the website
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The language name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Specify the location where the locale strings of the language will be stored.        
        /// </summary>
        public string XmlFile { get; set; }


        /// <summary>
        /// Specify whether this will be a default language for the site.
        /// </summary>
        public bool IsDefault { get; set; }

        #endregion
    }
}
