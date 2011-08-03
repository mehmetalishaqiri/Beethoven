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
 * File Name: Composer.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      29.07.2011 06:06 PM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Web.Routing;
using Beethoven.Plugins.Shared;
using System.Web.Mvc;
using Beethoven.Plugins.MetaData;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using System.Web.Hosting;
using Beethoven.Plugins.Tasks;

namespace Beethoven
{
	/// <summary>
	/// Beethoven is responsible for the initialization of the HOST and composition of plugins
	/// </summary>
	public static class Composer
	{
		#region Private Members

		/// <summary>
		/// Gets the current container.
		/// </summary>
		[Export(typeof(CompositionContainer))]
		public static CompositionContainer Container { get; private set; }
		
		
		#endregion

		#region Compose

		public static void Compose()
		{

			ICompositionContainerFactory compositionFactory = new CompositionContainerFactory();

			//get an instance of the MEF composition container created by Composition Container Factory
			CompositionContainer container = compositionFactory.CreateCompositionContainer();

			Container = container;
			// BeethovenRoutes = RouteTable.Routes;
			try
			{
				CompositionBatch batch = new CompositionBatch();
				batch.AddExportedValue(container);                
				
				////compose the existing parts.
				container.ComposeParts(batch);
			}
			catch //(CompositionException compositionException)
			{
				//TO DO:
				// Log composition exception
			}



			//set the cuctom controller factory
			//ControllerBuilder.Current.SetControllerFactory(new ControllerFactory(container));

			//The SetResolver method of DependencyResolver class provides a registration point for dependency injection containers.
			System.Web.Mvc.DependencyResolver.SetResolver(new DependencyResolver(container));
			

			RegisterHttpModules();

			//HostingEnvironment.RegisterVirtualPathProvider(new LCMSAssemblyResourceProvider());
		}

		#endregion

		#region RunStartupTasks

		public static void RunStartupTasks()
		{
			var tasks = Container.GetExports<IStartupTask, IStartupTaskMetadata>();
			
			foreach (var task in tasks)
				task.Value.Run(Container);
		}
	
		#endregion

		#region RegisterViewEngine

		/// <summary>
		/// Registers the viewengine based on available plugins
		/// </summary>
		/// <param name="clearExisting">Indicates whether the existing view engines should be removed or not.</param>
		public static void RegisterViewEngine(bool clearExisting)
		{
			//get all exported controllers
			IEnumerable<Lazy<IController, IPluginMetadata>> exports = Container.GetExports<IController, IPluginMetadata>();

			//from exported controllers, get PluginID from controller's metadata
			List<string> plugins = exports.Select(p => p.Metadata.PluginID).Distinct().ToList();

			//check if we should remove existing viewengines
			if (clearExisting)
				ViewEngines.Engines.Clear();

			//register the custom view engine
			ViewEngines.Engines.Add(new ComposableViewEngine(plugins));
		}

		#endregion        

		#region RegisterAllAreas

		public static void RegisterAllAreas()
		{
			//TO DO:
			//register an area for each plugin

			var areas = Container.GetExports<AreaRegistration>();
			foreach (var export in areas)
			{
				AreaRegistration area = export.Value;                
				var context = new AreaRegistrationContext(area.AreaName,RouteTable.Routes);
				area.RegisterArea(context);
			}

			

		}

		#endregion

		#region RegisterHttpModules

		static void RegisterHttpModules()
		{
			var modules = Container.GetExports<IHttpModule>();
			foreach (var export in modules)
			{
				
				IHttpModule module = export.Value;
				
				var moduleType = module.GetType();
				
				DynamicModuleUtility.RegisterModule(moduleType);
			}
		}

		#endregion
	}
}
