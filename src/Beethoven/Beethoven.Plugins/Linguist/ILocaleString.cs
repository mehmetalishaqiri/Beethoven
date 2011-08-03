﻿/*
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
 * File Name: ILocaleString.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      01.08.2011 09:15 PM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beethoven.Plugins.Linguist
{
    
    /// <summary>
    /// A common interface for all locale strings
    /// </summary>    
    public interface ILocaleString
    {
        /// <summary>
        /// The unique identifier of the locale string
        /// </summary>
        int ID { get; set; }


        /// <summary>
        /// The value of the locale string
        /// </summary>
        string Value { get; set; }
    }
}