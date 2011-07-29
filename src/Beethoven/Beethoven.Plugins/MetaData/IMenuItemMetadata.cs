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
 * File Name: IMenuItemMetadata.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      29.07.2011 08:40 PM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beethoven.Plugins.Shared;


namespace Beethoven.Plugins.MetaData
{
    /// <summary>
    /// Metadata about menu items
    /// </summary>
    public interface IMenuItemMetadata : IAction
    {
        string PluginID { get; }

        string DisplayText { get; }

        string ParentID { get;  }       

        int OrderNumber { get;  }
        
    }
}
