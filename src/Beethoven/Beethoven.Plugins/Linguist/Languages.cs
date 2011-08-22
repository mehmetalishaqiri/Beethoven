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
 * File Name: Languages.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      01.08.2011 09:30 PM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Xml.Linq;
using Beethoven.Configuration;
using System.Web.Configuration;


namespace Beethoven.Plugins.Linguist
{
    /// <summary>
    /// Singleton Pattern
    /// Ensures that there is only one instance of the Languages class and there is a global access point to that object.
    /// This class is only instantiated once and all the requests all directed to that one and only object.
    /// The object it is not created until it is actually needed.
    /// </summary>
    public sealed class Languages
    {
        /// <summary>
        /// private constructor
        /// </summary>
        Languages() { }
        

        /// <summary>
        /// Nested class for lazy instantiation
        /// </summary>
        class LanguagesCreator
        {
            /// <summary>
            /// private constructor 
            /// </summary>
            static LanguagesCreator() { }

            #region LanguagesPath

            /// <summary>
            /// Gets the location the xml document where the languages are stored.
            /// </summary>
            internal static string LanguagesPath
            {
                get
                {
                    return ((BeethovenConfiguration)WebConfigurationManager.GetSection("BeethovenConfiguration")).Linguist.LanguagesPath;
                }
            }


            #endregion
            
            /// <summary>
            /// private object instantiated with private constructor
            /// </summary>
            internal static readonly Languages uniqueInstance = new Languages();

            /// <summary>
            /// Holds the list of supported languages.
            /// </summary>
            internal static readonly List<Language> languages = GetSupportedLanguages();


            #region GetSupportedLanguages

            /// <summary>
            /// Get the list of supported languages
            /// </summary>
            /// <returns>A generic list of Language class.</returns>
            internal static List<Language> GetSupportedLanguages()
            {
                List<Language> languages = new List<Language>();

                //load xml document
                XDocument xmlDoc = XDocument.Load(LanguagesPath);
                
                //get the languages
                var query = xmlDoc.Element("languages").Elements("language");
                //iterate through resultset
                foreach (var item in query)
                {
                    Language obj = new Language
                    {                        
                        Code = item.Attribute("code").Value,
                        IsDefault = Convert.ToBoolean(item.Attribute("isDefault").Value),
                        Name = item.Element("name").Value,
                        XmlFile = item.Element("xmlFile").Value
                    };
                    //fill the generic list of Language.
                    languages.Add(obj);
                }               
                return languages;
            }

            #endregion
        }

        #region UniqueInstance

        /// <summary>
        /// A public static property which returns the unique instance of the Languages Class.
        /// </summary>
        public static Languages UniqueInstance
        {
            get
            {
                return LanguagesCreator.uniqueInstance;
            }
        }

        #endregion        

        #region SupportedLanguages

        /// <summary>
        /// A public static property that returns the unique instance of the SupportedLanguages List (List<Language>).
        /// </summary>        
        public static List<Language> SupportedLanguages
        {
            get
            {
                return LanguagesCreator.languages;
            }
        }

        #endregion

        #region DefaultLanguage

        /// <summary>
        /// A public static property that returns the Default Language of the site.
        /// </summary>
        public static Language DefaultLanguage
        {
            get
            {
                return LanguagesCreator.languages.Where(lang => lang.IsDefault == true).SingleOrDefault();
            }
        }

        #endregion      
        
        #region GetLanguage

        /// <summary>
        /// A public static method to get a particular language
        /// </summary>
        /// <param name="languageID">The unique identifier of the language trying to retrieve</param>
        /// <returns>An instance of the Language class.</returns>
        public static Language GetLanguage(string languageCode)
        {
            return LanguagesCreator.languages.Where(lang=>lang.Code == languageCode).SingleOrDefault();
        }

        #endregion

        #region IslanguageSupported

        /// <summary>
        /// Check if the given language is supported or not.
        /// </summary>
        /// <param name="languageCode">The unique identifier of the language</param>
        /// <returns>True: If the language is supported, False: If the language is not supported</returns>
        public static bool IsLanguageSupported(string languageCode)
        {
            return (LanguagesCreator.languages.Where(lang => lang.Code == languageCode).Count() > 0) ? true : false;
        }
        
        #endregion

    }
}