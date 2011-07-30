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
 * File Name: BeethovenPreStart.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      30.07.2011 05:32 PM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Beethoven;

[assembly: WebActivator.PreApplicationStartMethod(typeof($rootnamespace$.App_Start.Composer), "Start")]
namespace $rootnamespace$.App_Start {
    public static class Composer {
        public static void Start() {
            
			Beethoven.Composer.Compose();

            Beethoven.Composer.RegisterViewEngine(true);

            Beethoven.Composer.RegisterAllAreas();

        }
    }
}