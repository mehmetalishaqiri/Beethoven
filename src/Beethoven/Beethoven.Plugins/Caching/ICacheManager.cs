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
 * File Name: ICacheManager.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      01.08.2011 09:45 PM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Caching;

namespace Beethoven.Plugins.Cashing
{
    /// <summary>
    /// A common interface which specifies what methods should support all classes that manage application cache
    /// </summary>
    public interface ICacheManager
    {
        /// <summary>
        /// Add a new object into the cache
        /// </summary>
        /// <param name="key">The key of the object to add</param>
        /// <param name="value">The value of the object to add</param>
        void Add(string key, object value);


        void Add(string key, object value, CacheDependency dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority cachePriority, CacheItemRemovedCallback onRemoveCallback);

        /// <summary>
        /// Check whether the key is contained by the cache
        /// </summary>
        /// <param name="key">The key to check</param>
        /// <returns>Returns true if the key is contained by the cache</returns>
        bool Contains(string key);

        /// <summary>
        /// Returns the number of items in the cache
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// Insert a new object into the cache 
        /// </summary>
        /// <param name="key">The key of the object to insert</param>
        /// <param name="value">The value of the object to insert</param>
        void Insert(string key, object value);


        /// <summary>
        /// Insert a new object into the cache 
        /// </summary>
        /// <param name="key">The key of the object to insert</param>
        /// <param name="value">The value of the object to insert</param>
        /// <param name="value">The dependency of the object to insert</param>
        void Insert(string key, object value,CacheDependency dependency);


        void Insert(string key, object value, CacheDependency dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority cachePriority, CacheItemRemovedCallback onRemoveCallback);

        /// <summary>
        /// Get the object that its key is given
        /// </summary>
        /// <typeparam name="T">The object</typeparam>
        /// <param name="key">The given key to check</param>
        /// <returns>returns the object or null if it doesn't exists</returns>
        T Get<T>(string key);

        /// <summary>
        /// Removes the object that is referenced by the given key
        /// </summary>
        /// <param name="key">The given key</param>
        void Remove(string key);

        /// <summary>
        /// Get/Set the the given key and object
        /// </summary>
        /// <param name="key">The given key to the indexer</param>
        /// <returns>Returns the object that the given key reference</returns>
        object this[string key]
        {
            get;
            set;
        }
    }
}
