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
 * File Name: LayoutViewModelBase.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      29.07.2011 10:40 PM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Beethoven.Plugins.ViewModels
{
    /// <summary>
    /// Represents the base viewmodel for layouts
    /// </summary>
    public class LayoutViewModelBase<TLayout>
    {
        public LayoutViewModelBase()
        {
             
        }

        public LayoutViewModelBase(TLayout model)
        {
            LayoutModel = model;
        }

        /// <summary>
        /// Gets or sets the master model
        /// </summary>
        public TLayout LayoutModel { get; set; }        
    }
}
