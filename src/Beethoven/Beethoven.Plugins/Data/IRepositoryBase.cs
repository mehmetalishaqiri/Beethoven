/*
 * Beethoven.Plugins
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
 * File Name: IRepositoryBase.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      09.08.2011 03:27 AM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Beethoven.Plugins.Data
{
    /// <summary>
    /// Defines a base contract for all repositories
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> GetItems();

        IEnumerable<T> GetItems(int pageIndex, int pageSize);

        IEnumerable<T> GetItems(Expression<Func<T, bool>> query);

        IEnumerable<T> GetItems(Expression<Func<T, bool>> query, int pageIndex, int pageSize);

        T GetItem(object id);

        void Add(T item);

        void Delete(T item);

        int CountItems();

        int SaveChanges();
    }
}
