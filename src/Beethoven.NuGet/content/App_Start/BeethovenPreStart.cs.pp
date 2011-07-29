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
            
			Beethoven.Compose("Plugins");
			
			Beethoven.RegisterViewEngine(false); 

        }
    }
}