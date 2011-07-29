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
 * File Name: ViewModelBase.cs
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
using System.Web.Mvc;

namespace Beethoven.Plugins.ViewModels
{
    /// <summary>
    /// Represents a base view model for all views
    /// </summary>    
    public class ViewModelBase<TLayout, TView> : LayoutViewModelBase<TLayout>
    {
        public ViewModelBase()
        {

        }
        public ViewModelBase(TLayout layout, TView view)
            : base(layout)
        {
            ViewModel = view;
        }

        /// <summary>
        /// The View Model
        /// </summary>
        public TView ViewModel { get; set; }

    }
}
