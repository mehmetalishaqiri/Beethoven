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
 * File Name: CheckBoxListInfo.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      04.08.2011 12:14 AM
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Beethoven.Plugins.Controls
{
    public class CheckBoxListInfo
    {
        public string Value { get; set; }
        public bool IsChecked { get; set; }
        public string DisplayText { get; set; }

        public CheckBoxListInfo(string value, bool isChecked, string displayText)
        {
            this.Value = value;
            this.IsChecked = isChecked;
            this.DisplayText = displayText;
        }
    }
}