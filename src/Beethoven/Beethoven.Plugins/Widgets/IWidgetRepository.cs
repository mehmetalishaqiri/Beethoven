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
 * File Name: IWidgetRepository.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      31.07.2011 05:30 PM
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
    public interface IWidgetRepository
    {
        IEnumerable<Widget> GetWidgetsForUser(string pluginId, Guid userId);

        IEnumerable<Widget> GetRelatedWidgets(Widget widget);

        IEnumerable<Widget> GetInRange(string pluginId, Guid userId, int column, int positionFrom, int positionTo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Widget GetById(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="widget"></param>
        void Add(Widget widget);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="widget"></param>
        void Delete(Widget widget);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}
