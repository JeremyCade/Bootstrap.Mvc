﻿// -----------------------------------------------------------------------
// <copyright file="FormExtensions.cs" company="Jeremy Cade">
//      No Copyright Intended. Use the code as you wish.
// </copyright>
// -----------------------------------------------------------------------

namespace Bootstrap.Mvc
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    /// <summary>
    /// Form Extensions to make working with Twitter Bootstrap a little easier.
    /// </summary>
    public static class FormExtensions
    {
        public static MvcForm BeginForm(this HtmlHelper htmlHelper, string formId, string cssClass)
        {
            string actionName = (string)htmlHelper.ViewContext.RouteData.Values["action"];
            string controllerName = (string)htmlHelper.ViewContext.RouteData.Values["controller"];
            IDictionary<string, object> htmlAttributes = new Dictionary<string, object>();
            htmlAttributes.Add("id", formId ?? string.Empty);
            htmlAttributes.Add("class", cssClass ?? string.Empty);
            return htmlHelper.BeginForm(actionName, controllerName, FormMethod.Post, htmlAttributes);
        }

        public static MvcForm BeginForm(this HtmlHelper htmlHelper, string cssClass)
        {
            string actionName = (string)htmlHelper.ViewContext.RouteData.Values["action"];
            string controllerName = (string)htmlHelper.ViewContext.RouteData.Values["controller"];
            IDictionary<string, object> htmlAttributes = new Dictionary<string, object>();
            htmlAttributes.Add("class", cssClass ?? string.Empty);
            return htmlHelper.BeginForm(actionName, controllerName, FormMethod.Post, htmlAttributes);
        }

        #region Bootstrap Specific Form Types

        public static MvcForm BeginHorizontalForm(this HtmlHelper htmlHelper)
        {
            return htmlHelper.BeginForm("form-horizontal");
        }

        public static MvcForm BeginInlineForm(this HtmlHelper htmlHelper)
        {
            return htmlHelper.BeginForm("form-inline");
        }

        public static MvcForm BeginSearchForm(this HtmlHelper htmlHelper)
        {
            return htmlHelper.BeginForm("form-search");
        }

        public static MvcForm BeginVerticalForm(this HtmlHelper htmlHelper)
        {
            return htmlHelper.BeginForm("form-vertical");
        }

        #endregion Bootstrap Specific Form Types
    }
}