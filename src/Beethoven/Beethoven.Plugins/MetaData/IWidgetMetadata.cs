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
 * File Name: IWidgetMetadata.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      30.07.2011 10:08 PM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beethoven.Plugins.Shared;


namespace Beethoven.Plugins.MetaData
{
    /// <summary>
    /// Metadata about widgets
    /// </summary>
    public interface IWidgetMetadata
    {
        string WidgetPluginID { get; }

        string WidgetDisplayText { get; }

        string WidgetParentID { get;  }       

        int WidgetOrderNumber { get;  }

        /// <summary>
        /// Gets the action.
        /// </summary>
        string WidgetAction { get; }

        /// <summary>
        /// Gets the controller.
        /// </summary>
        string WidgetController { get; }


        string WidgetAlias { get; }
        
    }
}
