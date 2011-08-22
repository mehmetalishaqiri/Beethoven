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
 * File Name: SerializationHelper.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      04.08.2011 09:40 PM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Data;

namespace Beethoven.Plugins.Serialization
{
    /// <summary>
    /// A generic class used to serialize/deserialize objects
    /// </summary>
    /// <typeparam name="T">The type of the working object</typeparam>
    public class SerializationHelper<T>
    {
        #region SerializeObject

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pObject"></param>
        /// <returns></returns>
        public static String SerializeObject(T pObject)
        {
            string serialized = String.Empty;
            try
            {
                MemoryStream stream = new MemoryStream();
                using (XmlTextWriter xml = new XmlTextWriter(stream, Encoding.UTF8))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    xs.Serialize(xml, pObject);
                    stream = (MemoryStream)xml.BaseStream;
                    stream.Seek(0, SeekOrigin.Begin);
                }
                serialized = UTF8ByteArrayToString(stream.ToArray());
            }

            catch (Exception ex)
            {

            }
            return serialized;
        }

        #endregion

        #region DeserializeObject

        /// <summary>
        /// Method to reconstruct an Object from XML string
        /// </summary>
        /// <param name="pXmlizedString"></param>
        /// <returns></returns>
        public static T DeserializeObject(String pXmlizedString)
        {


            using (MemoryStream stream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString)))
            using (new XmlTextWriter(stream, Encoding.UTF8))
            {
                return (T)new XmlSerializer(typeof(T)).Deserialize(stream);
            }

        }

        #endregion

        #region UTF8ByteArrayToString

        /// <summary>
        /// To convert a Byte Array of Unicode values (UTF-8 encoded) to a complete String.
        /// </summary>
        /// <param name="characters">Unicode Byte Array to be converted to String</param>
        /// <returns>String converted from Unicode Byte Array</returns>
        private static String UTF8ByteArrayToString(Byte[] characters)
        {

            UTF8Encoding encoding = new UTF8Encoding();
            String constructedString = encoding.GetString(characters);
            return (constructedString);

        }

        #endregion

        #region StringToUTF8ByteArray

        /// <summary>
        /// Converts the String to UTF8 Byte array and is used in De serialization
        /// </summary>
        /// <param name="pXmlString"></param>
        /// <returns></returns>
        private static Byte[] StringToUTF8ByteArray(String pXmlString)
        {

            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(pXmlString);
            return byteArray;

        } 

        #endregion        
    }
}
