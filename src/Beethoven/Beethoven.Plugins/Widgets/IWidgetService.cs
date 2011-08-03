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
 * File Name: IWidgetService.cs
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
    /// <summary>
    /// 
    /// </summary>
    public interface IWidgetService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="widget"></param>
        void Add(Widget widget);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="column"></param>
        /// <param name="position"></param>
        void Move(Guid id, int column, int position);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Collapse(Guid id);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Close(Guid id);

        IEnumerable<Widget> GetWidgetsForUser(string pluginId, Guid userId);

        IEnumerable<Widget> GetAvailableWidgets(string pluginId, Guid userId);
    }
}
