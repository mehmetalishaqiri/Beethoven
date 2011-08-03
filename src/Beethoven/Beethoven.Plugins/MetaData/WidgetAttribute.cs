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
 * File Name: WidgetAttribute.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      29.07.2011 09:00 PM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace Beethoven.Plugins.MetaData
{
    /// <summary>
    /// Meta data about widgets
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class WidgetAttribute : ExportAttribute, IWidgetMetadata
    {
        #region Class Constructors


        public WidgetAttribute() : base(typeof(IWidgetMetadata)) { }


        #endregion

        #region IWidgetMetadata Members

        public string WidgetPluginID { get; set; }

        public string WidgetDisplayText { get; set; }

        public string WidgetParentID { get; set; }

        public int WidgetOrderNumber { get; set; }

        public string WidgetAction { get; set; }

        public string WidgetController { get; set; }


        public string WidgetAlias { get; set; }

        #endregion        
    }
}
