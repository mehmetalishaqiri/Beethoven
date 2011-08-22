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
 * File Name: GravatarHelper.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Beethoven.Plugins.Helpers
{
    public class GravatarHelper
    {
        public static string GetUserGravatar(string emailAddress)
        {
            byte[] loweredEmailAddressBytes = Encoding.Default.GetBytes(emailAddress.ToLower());

            byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(loweredEmailAddressBytes);

            StringBuilder hashedEmailAddressBuilder = new StringBuilder(buffer.Length * 2);

            for (int i = 0; i < buffer.Length; i++)
            {
                hashedEmailAddressBuilder.Append(buffer[i].ToString("X2"));
            }
            string md5 = hashedEmailAddressBuilder.ToString().ToLower();
            return String.Format("http://www.gravatar.com/avatar/{0}", md5);              
        }
    }
}
