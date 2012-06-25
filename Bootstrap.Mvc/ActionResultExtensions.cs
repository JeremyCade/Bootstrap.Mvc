// -----------------------------------------------------------------------
// <copyright file="ActionResultExtensions.cs" company="Jeremy Cade">
//      No Copyright Intended. Use the code as you wish. 
// </copyright>
// -----------------------------------------------------------------------

namespace Bootstrap.Mvc
{
    using System.Web;
    using System.Web.Mvc;
    using System.Collections.Generic;
    using System.Collections.Specialized;


    /// <summary>
    /// Extension Methods for writing messages to cookies when using the PRG pattern.
    /// Requires client JavaScript to display messages. 
    /// </summary>
    public static class ActionResultExtensions
    {
        /// <summary>
        /// Error Flash Message for Twitter Bootstrap
        /// </summary>
        /// <param name="result">ActionResult Object being Extended</param>
        /// <param name="message">Message to display in view. Messaged is written into a cookie.</param>
        /// <returns></returns>
        public static ActionResult Error(this ActionResult result, string message)
        {
            CreateCookieWithFlashMessage("alert-error", null, message);
            return result;
        }

        /// <summary>
        /// Error Flash Message for Twitter Bootstrap
        /// </summary>
        /// <param name="result">ActionResult Object being Extended</param>
        /// <param name="heading">Message Heading to display in view. Heading is written into a cookie.</param>
        /// <param name="message">Message to display in view. Messaged is written into a cookie.</param>
        /// <returns></returns>
        public static ActionResult Error(this ActionResult result, string heading, string message)
        {
            CreateCookieWithFlashMessage("alert-error", heading, message);
            return result;
        }

        /// <summary>
        /// Warning Flash Message for Twitter Bootstrap
        /// </summary>
        /// <param name="result">ActionResult Object being Extended</param>        
        /// <param name="message">Message to display in view. Messaged is written into a cookie.</param>
        /// <returns></returns>
        public static ActionResult Warning(this ActionResult result, string message)
        {
            CreateCookieWithFlashMessage("alert", null, message);
            return result;
        }

        /// <summary>
        /// Warning Flash Message for Twitter Bootstrap
        /// </summary>
        /// <param name="result">ActionResult Object being Extended</param>
        /// <param name="heading">Message Heading to display in view. Heading is written into a cookie.</param>
        /// <param name="message">Message to display in view. Messaged is written into a cookie.</param>
        /// <returns></returns>
        public static ActionResult Warning(this ActionResult result, string heading, string message)
        {
            CreateCookieWithFlashMessage("alert", heading, message);
            return result;
        }

        /// <summary>
        /// Success Flash Message for Twitter Bootstrap
        /// </summary>
        /// <param name="result">ActionResult Object being Extended</param>        
        /// <param name="message">Message to display in view. Messaged is written into a cookie.</param>
        /// <returns></returns>
        public static ActionResult Success(this ActionResult result, string message)
        {
            CreateCookieWithFlashMessage("alert-success", null, message);
            return result;
        }

        /// <summary>
        /// Success Flash Message for Twitter Bootstrap
        /// </summary>
        /// <param name="result">ActionResult Object being Extended</param>
        /// <param name="heading">Message Heading to display in view. Heading is written into a cookie.</param>
        /// <param name="message">Message to display in view. Messaged is written into a cookie.</param>
        /// <returns></returns>
        public static ActionResult Success(this ActionResult result, string heading, string message)
        {
            CreateCookieWithFlashMessage("alert-success", heading, message);
            return result;
        }

        /// <summary>
        /// Information Flash Message for Twitter Bootstrap
        /// </summary>
        /// <param name="result">ActionResult Object being Extended</param>        
        /// <param name="message">Message to display in view. Messaged is written into a cookie.</param>
        /// <returns></returns>
        public static ActionResult Information(this ActionResult result, string message)
        {
            CreateCookieWithFlashMessage("alert-info", null, message);
            return result;
        }

        /// <summary>
        /// Information Flash Message for Twitter Bootstrap
        /// </summary>
        /// <param name="result">ActionResult Object being Extended</param>
        /// <param name="heading">Message Heading to display in view. Heading is written into a cookie.</param>
        /// <param name="message">Message to display in view. Messaged is written into a cookie.</param>
        /// <returns></returns>
        public static ActionResult Information(this ActionResult result, string heading, string message)
        {
            CreateCookieWithFlashMessage("alert-info", heading, message);
            return result;
        }

        /// <summary>
        /// Creates a cookie with the the Twitter Bootstrap alert class, heading and message.
        /// </summary>
        /// <param name="alertClass">Twitter Bootstrap Alert Class</param>
        /// <param name="heading">Message Heading</param>
        /// <param name="message">Message Text</param>
        private static void CreateCookieWithFlashMessage(string alertClass, string heading, string message)
        {
            HttpCookie cookie = new HttpCookie(string.Format("Alert.{0}", alertClass));
            cookie.Values.Add("Heading", heading ?? string.Empty);
            cookie.Values.Add("Message", message ?? string.Empty);
            cookie.Path = "/";

            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}
