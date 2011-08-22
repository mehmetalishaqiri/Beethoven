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
 * File Name: WidgetRepository.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      31.07.2011 05:46 PM
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Beethoven.Plugins.Data;


namespace Beethoven.Plugins.Widgets
{
    [Export(typeof(IWidgetRepository))]
    public class WidgetRepository : IWidgetRepository
    {
        PluginsDataContext _dataContext = new PluginsDataContext();

        public Widget GetById(Guid id)
        {
            return _dataContext.Widgets.Single(w => w.ID == id);
        }

        public IEnumerable<Widget> GetWidgetsForUser(string pluginId, Guid userId)
        {
            IEnumerable<Widget> widgets = _dataContext.Widgets.Where(w => w.UserId == userId && w.PluginID == pluginId);

            return widgets.ToList();
        }

        public IEnumerable<Widget> GetRelatedWidgets(Widget widget)
        {
            var widgets = from w in _dataContext.Widgets
                          where
                          w.PluginID == widget.PluginID &&
                          w.UserId == widget.UserId &&
                          w.Column == widget.Column &&
                          w.Position >= widget.Position
                          select w;

            return widgets;
        }

        public IEnumerable<Widget> GetInRange(string pluginId, Guid userId, int column, int positionFrom, int positionTo)
        {
            var widgets = from w in _dataContext.Widgets
                          where
                          w.PluginID == pluginId &&
                          w.UserId == userId &&
                          w.Column == column &&
                          w.Position >= positionFrom &&
                          w.Position <= positionTo
                          select w;

            return widgets;
        }

        public void Add(Widget widget)
        {
            _dataContext.Widgets.Add(widget);
        }
        public void Delete(Widget widget)
        {
            _dataContext.Widgets.Remove(widget);
        }

        public int SaveChanges()
        {
            return _dataContext.SaveChanges();
        }

    }
}
