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
 * File Name: Widget.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      30.07.2011 09:50 PM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beethoven.Plugins.Widgets
{
    public class Widget
    {
        /// <summary>
        /// The unique ID of the widget
        /// </summary>

        public Guid ID { get; set; }

        /// <summary>
        /// Determines whether widget is collapsed or not
        /// </summary>
        public bool Collapsed { get; set; }

        /// <summary>
        /// The position of the widget in dashboard
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// The column where the widget is located
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// The Widget Title
        /// </summary>
        public string DisplayText { get; set; }

        /// <summary>
        /// The id of plugin the widget belongs to
        /// </summary>
        public string PluginID { get; set; }

        /// <summary>
        /// The controller where widget should take 
        /// </summary>
        public string Controller { get; set; }

        public string Action { get; set; }

        public Guid UserId { get; set; }

        public string Alias { get; set; }
    }
}
