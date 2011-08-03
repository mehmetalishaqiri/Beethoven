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
 * File Name: CacheManager.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      01.08.2011 09:55 PM
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace Beethoven.Plugins.Cashing
{
    /// <summary>
    /// Manage the cache for current application.
    /// </summary>
    public class CacheManager : ICacheManager
    {
        #region ICacheManager Members

        /// <summary>
        /// Add a new object into the cache
        /// </summary>
        /// <param name="key">The key of the object to add</param>
        /// <param name="value">The value of the object to add</param>
        public void Add(string key, object value)
        {
            HttpRuntime.Cache.Add(key, value, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
        }

        public void Add(string key, object value, CacheDependency dependency, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority cachePriority, CacheItemRemovedCallback onRemoveCallback)
        {
            HttpRuntime.Cache.Insert(key, value, dependency, absoluteExpiration, slidingExpiration, cachePriority, onRemoveCallback);
        }

        /// <summary>
        /// Check whether the key is contained by the cache
        /// </summary>
        /// <param name="key">The key to check</param>
        /// <returns>Returns true if the key is contained by the cache</returns>
        public bool Contains(string key)
        {
            return HttpRuntime.Cache.Get(key) != null;
        }


        /// <summary>
        /// Returns the number of items in the cache
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return HttpRuntime.Cache.Count;
        }


        /// <summary>
        /// Insert a new object into the cache 
        /// </summary>
        /// <param name="key">The key of the object to insert</param>
        /// <param name="value">The value of the object to insert</param>
        public void Insert(string key, object value)
        {
            HttpRuntime.Cache.Insert(key, value);
        }

        /// <summary>
        /// Insert a new object into the cache 
        /// </summary>
        /// <param name="key">The key of the object to insert</param>
        /// <param name="value">The value of the object to insert</param>
        /// <param name="value">The dependency of the object to insert</param>
        public void Insert(string key, object value, CacheDependency dependency)
        {
            HttpRuntime.Cache.Insert(key, value,dependency);
        }

        /// Insert a new object into the cache 
        /// </summary>
        /// <param name="key">The key of the object to insert</param>
        /// <param name="value">The value of the object to insert</param>
        /// <param name="value">The dependency of the object to insert</param>
        public void Insert(string key, object value, CacheDependency dependency,DateTime absoluteExpiration,TimeSpan slidingExpiration,CacheItemPriority cachePriority,CacheItemRemovedCallback onRemoveCallback)
        {
            HttpRuntime.Cache.Insert(key, value,dependency,absoluteExpiration,slidingExpiration,cachePriority,onRemoveCallback);
        }


        /// <summary>
        /// Get the object that its key is given
        /// </summary>
        /// <typeparam name="T">The object</typeparam>
        /// <param name="key">The given key to check</param>
        /// <returns>returns the object or null if it doesn't exists</returns>
        public T Get<T>(string key)
        {
            return (T)HttpRuntime.Cache.Get(key);
        }


        /// <summary>
        /// Removes the object that is referenced by the given key
        /// </summary>
        /// <param name="key">The given key</param>
        public void Remove(string key)
        {
            HttpRuntime.Cache.Remove(key);
        }


        /// <summary>
        /// Get/Set the the given key and object
        /// </summary>
        /// <param name="key">The given key to the indexer</param>
        /// <returns>Returns the object that the given key reference</returns>
        public object this[string key]
        {
            get
            {
                return HttpRuntime.Cache[key];
            }
            set
            {
                HttpRuntime.Cache[key] = value;
            }
        }

        #endregion
    }
}