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
 * File Name: Localization.cs
 * 
 * File Authors:
 * 		Mehmetali N. Shaqiri, m.shaqiri@spartansoft.org
 * 
 * Date Created:
 *      01.08.2011 10:20 PM
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Xml.Linq;
using System.Web.SessionState;
using Beethoven.Plugins.Cashing;
using System.ComponentModel.Composition;

namespace Beethoven.Plugins.Linguist
{
    /// <summary>
    /// An HTTP Module designed to translate locale strings in supported languages
    /// </summary>   
    [Export(typeof(IHttpModule))]
    public class Localization : IHttpModule
    {
        #region Private Members

        /// <summary>
        /// An CacheItemRemovedCallback delegate used to track when an item is modified in cache.
        /// </summary>
        private CacheItemRemovedCallback OnLocalizationUpdated = null;   


        #endregion

        #region IHttpModule Members

        /// <summary>
        /// Dispose unnecessary resources.
        /// </summary>
        public void Dispose()
        {
            //nothing to dispose
        }

        /// <summary>
        /// Initialize the Localization module and prepare it to handle requests
        /// </summary>
        /// <param name="context">The executing application.</param>
        public void Init(HttpApplication context)
        {            
            CacheManager _cache = new CacheManager();

            //get the list of supported languages.
            //This is where the Singleton Pattern is instantiated
            List<Language> supported = Languages.SupportedLanguages;

            foreach (Language lang in supported)
            {
                //make sure that the language doesn't exist in cache.
                if (!_cache.Contains(lang.Code))
                {
                    //specify which method to call when an item is removed from cache
                    OnLocalizationUpdated = new CacheItemRemovedCallback(UpdateLanguageInCache);

                    //insert language in the cache and associate cache dependencies
                    _cache.Insert(lang.Code, GetLanguageDocument(lang.Code), new CacheDependency(lang.XmlFile), DateTime.Now.AddYears(1), TimeSpan.Zero, CacheItemPriority.Default, OnLocalizationUpdated);
                }
            }

           
                //Attach an event handler to modify the HTML before it is rendered to the user and translate the locale strings. 
                //This happens when ASP.NET responds to a request.
                context.BeginRequest += new EventHandler(TranslateLocalStrings);
           

        }

        #endregion

        #region Class Methods

        #region TranslateLocalStrings

        /// <summary>
        /// Download the rendered html and translate locale strings
        /// </summary>       
        void TranslateLocalStrings(object sender, EventArgs e)
        {            
            HttpResponse response = HttpContext.Current.Response;
            

            //make sure that we're dealing with html content
            if (response.ContentType == "text/html" && response.ContentType != "text/javascript")
            {
                response.ClearContent();
                response.ClearHeaders();
                string path = HttpContext.Current.Request.Url.ToString();
                //exclude file extensions since it will mess up the binary data
                if (!path.Contains(".jpg") && !path.Contains(".png") && !path.Contains(".gif") && !path.Contains(".ico"))
                {
                    //Specify the filter which is used to modify the HTTP content before transmission
                    response.Filter = new LocaleStringsTranslator(response.Filter);

                }
            }
        }

        #endregion

        #region UpdateLanguageInCache

        /// <summary>
        /// //Update the language in the cache
        /// </summary>
        /// <param name="key">The language code used as a key in cache</param>
        /// <param name="value">The old value before the language is modified</param>
        /// <param name="reason">Specifies the reason an item was removed from cache.</param>
        private void UpdateLanguageInCache(string key, Object value, CacheItemRemovedReason reason)
        {
            //we want to update the language in cache only when the XML document of the languages is modified.
            if (reason == CacheItemRemovedReason.DependencyChanged)
            {
                CacheLanguage(key);
            }
        }


        #endregion

        #region GetLanguageDocument

        /// <summary>
        /// Get the XML Document where the locale strings of the language are stored.
        /// </summary>
        /// <param name="languageCode">The unique identifier of the language</param>
        /// <returns>An XML Document that contains  the locale strings of a given language</returns>
        private XDocument GetLanguageDocument(string languageCode)
        {
            Language lang = Languages.GetLanguage(languageCode);
            return XDocument.Load(lang.XmlFile);
        }

        #endregion

        #region CacheLanguage

        /// <summary>
        /// Store the language in application cache.
        /// </summary>
        /// <param name="languageCode">The unique identifier of the language</param>
        private void CacheLanguage(string languageCode)
        {
            Language lang = Languages.GetLanguage(languageCode);
            CacheManager _cache = new CacheManager();

            //make sure that the language doesn't exist in cache.
            if (!_cache.Contains(lang.Code))
            {
                //insert language in the cache and associate cache dependencies
                _cache.Insert(lang.Code, GetLanguageDocument(lang.Code), new CacheDependency(lang.XmlFile), DateTime.Now.AddYears(1), TimeSpan.Zero, CacheItemPriority.Default, OnLocalizationUpdated);
            }

        }

        #endregion

        #endregion        
    }
}