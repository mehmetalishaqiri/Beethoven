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
 * File Name: PluginComparer.cs
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

namespace Beethoven.Plugins
{
    // Custom comparer for the Plugin class
    class PluginComparer : IEqualityComparer<Plugin>
    {
        // Plugins are equal if their id's are equal.
        public bool Equals(Plugin x, Plugin y)
        {

            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the products' properties are equal.
            return x.PluginID == y.PluginID;
        }

        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.
        public int GetHashCode(Plugin plugin)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(plugin, null)) return 0;           

            //Get hash code for the PluginID field.
            int hashPluginID = plugin.PluginID.GetHashCode();

            //return the hash code for the plugin.
            return hashPluginID;
        }

    }
}
