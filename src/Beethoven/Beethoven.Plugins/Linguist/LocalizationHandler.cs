using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Xml;
using System.Web.Configuration;
using System.Xml.Linq;
using Beethoven.Plugins.Linguist;
using Beethoven.Configuration;


namespace KEK.Linguist
{
    /// <summary>
    /// An Http Handler designed to process HTTP web requests
    /// Purpose: In order to avoid depenencies between Linguist and Application, this http handler is used to display supported languages.
    /// </summary>
    public class LocalizationHandler : IHttpHandler
    {
        #region IHttpHandler Members

        /// <summary>
        /// Make sure that the same instance can be pooled and used by concurrent requests.
        /// </summary>
        public bool IsReusable
        {
            get { return true; }
        }

        /// <summary>
        /// Enables processing of HTTP Web requests 
        /// </summary>
        /// <param name="context">The current context</param>
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml";
            //get the XML languages file.
            XDocument doc = XDocument.Load(((BeethovenConfiguration)WebConfigurationManager.GetSection("BeethovenConfiguration")).Languages.Path);
            context.Response.Write(doc);
        }

        #endregion
    }
}