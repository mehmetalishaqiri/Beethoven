using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;
using System.Collections.Specialized;

namespace Beethoven.Plugins.Linguist
{
    /// <summary>
    /// Read the HTML content a stream into a data structure, such as an array of bytes.
    /// </summary>
    public class LocaleStringsTranslator : Stream
    {
        #region Private Members

        /// <summary>
        /// 
        /// </summary>
        Stream responseStream;

        /// <summary>
        /// The position within the current stream.
        /// </summary>
        long position;

        /// <summary>
        /// Stores the modified HTML content
        /// </summary>
        StringBuilder responseHtml;

        #endregion

        #region Class Constructors

        /// <summary>
        /// The LocaleStringsTranslator class constructor
        /// </summary>
        /// <param name="inputStream"></param>
        public LocaleStringsTranslator(Stream inputStream)
        {
            responseStream = inputStream;            
            responseHtml = new StringBuilder();
        }

        #endregion

        #region Stream Members

        /// <summary>
        /// Gets a value indicating whether the current stream supports reading.
        /// </summary>
        public override bool CanRead
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether the current stream supports seeking.
        /// </summary>
        public override bool CanSeek
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether the current stream supports writing
        /// </summary>
        public override bool CanWrite
        {
            get { return true; }
        }


        /// <summary>
        /// Closes the current stream and releases any resources associated with the current stream.
        /// </summary>
        public override void Close()
        {
            responseStream.Close();
        }

        /// <summary>
        /// Clear any internal buffers and ensure that all data has been written 
        /// </summary>
        public override void Flush()
        {
            responseStream.Flush();
        }

        /// <summary>
        /// Gets the length in bytes of the stream.
        /// </summary>
        public override long Length
        {
            get { return 0; }
        }

        /// <summary>
        /// Gets or sets the position within the current stream.
        /// </summary>
        public override long Position
        {
            get { return position; }
            set { position = value; }
        }


        /// <summary>
        /// Sets the position within the current stream.
        /// </summary>
        /// <param name="offset">A byte offset relative to the origin parameter</param>
        /// <param name="origin">The reference point used to obtain the position</param>
        /// <returns></returns>
        public override long Seek(long offset, SeekOrigin origin)
        {
            return responseStream.Seek(offset, origin);
        }

        /// <summary>        
        /// Sets the length of the current stream in bytes.
        /// </summary>
        /// <param name="value">The desired lenth of the </param>
        public override void SetLength(long value)
        {
            responseStream.SetLength(Length);
        }


        /// <summary>
        /// Read a sequence of bytes from current stream
        /// </summary>
        /// <param name="buffer">An array of bytes</param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public override int Read(byte[] buffer, int offset, int count)
        {
            return responseStream.Read(buffer, offset, count);
        }

        #region Dirty Dishes

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        public override void Write(byte[] buffer, int offset, int count)
        {

            byte[] data = new byte[count];
            
            //accesses the bytes in the src parameter array using offsets into memory
            Buffer.BlockCopy(buffer, offset, data, 0, count);

            
            //decode all the bytes in the specified byte array into string
            string html = System.Text.Encoding.UTF8.GetString(buffer);

            //Regex expHTML = new Regex(@"</html>", RegexOptions.IgnoreCase);
            //if (expHTML.IsMatch(html))
            
           // {
           
                //extract all items to translate
                Regex exp = new Regex(@"\{Linguist.(.*?)\}", RegexOptions.IgnoreCase);
                MatchCollection MatchList = exp.Matches(html);

                //iterate through matched items
                foreach (Match oneMatch in MatchList)
                {
                    //get the current item value
                    string currentValue = oneMatch.Value.Trim();
                    string resourceName = currentValue.Replace('{', ' ').Replace('}', ' ').Trim();

                    string newValue = String.Empty;
                    //determine the language code for translation
                    //string languageCode = (HttpContext.Current.Items["lang"] == null) ? Languages.DefaultLanguage.Code : HttpContext.Current.Items["lang"].ToString();

                    string languageCode = String.IsNullOrEmpty(HttpContext.Current.Request.QueryString["lang"]) ? Languages.DefaultLanguage.Code : HttpContext.Current.Request.QueryString["lang"].ToString();
                    Translator translator = new Translator(languageCode);

                    //translate the locale string
                    newValue = translator.TranslateLocaleString(resourceName);
                    if (String.IsNullOrEmpty(newValue))
                        newValue = currentValue;
                    html = html.Replace(currentValue, newValue);
                
                //  }
            }
            //encode all characters into a sequence of bytes.
            byte[] output = System.Text.Encoding.UTF8.GetBytes(html);

            //write output back to user
            
            responseStream.Write(output, 0, output.GetLength(0));

        }

        #endregion

        #endregion
    }
}