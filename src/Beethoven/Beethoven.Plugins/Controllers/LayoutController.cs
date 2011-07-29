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
 * File Name: LayoutController.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      29.07.2011 08:20 PM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Beethoven.Plugins.ViewModels;
using System.ComponentModel.Composition;

namespace Beethoven.Plugins.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class LayoutController<TLayoutModel> : Controller
    {
        /// <summary>
        /// Views this instance.
        /// </summary>
        /// <returns></returns>
        protected virtual new ActionResult View()
        {
            return View(ViewData.Model);
        }

        /// <summary>
        /// Views the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        protected virtual new ActionResult View(object model)
        {
            //get the master page view model
            var layoutModel = GetLayoutViewModel();

            //create the view model
            object wrapper = CreateModel(model, layoutModel);

            return base.View(wrapper);
        }

        /// <summary>
        /// Gets the master view model.
        /// override this in your master controller.
        /// </summary>
        /// <returns></returns>
        protected virtual TLayoutModel GetLayoutViewModel()
        {
            return default(TLayoutModel);
        }

        /// <summary>
        /// Creates the model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="layoutModel">The master model.</param>
        /// <returns></returns>
        private static object CreateModel(object model, TLayoutModel layoutModel)
        {
            
            var modelType = typeof(object);

            if (model != null)
            {
                //get the type of the model
                modelType = model.GetType();
            }

            var types = new[] { typeof(TLayoutModel), modelType };


            Type generic = typeof(ViewModelBase<,>).MakeGenericType(types);

            //create an instance of the specified type using the constructor that best matches the specified parameters.
            return Activator.CreateInstance(generic, layoutModel, model);
        }
    }
}
