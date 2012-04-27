// -----------------------------------------------------------------------
// <copyright file="LabelExtensions.cs" company="AussieWeb Pty Ltd">
//  No Copyright Intended. Use the code as you wish.
//  LabelHelper Method from Microsofts MVC Source
//  Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Bootstrap.Mvc
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// Twitter Bootstrap Friendly Label Extensions
    /// </summary>
    public static class LabelExtensions
    {

        public static MvcHtmlString ControlLabel(this HtmlHelper html, string expression)
        {
            Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
            htmlAttributes.Add("class", "control-label");

            return LabelHelper(html,
                   ModelMetadata.FromStringExpression(expression, html.ViewData),
                   expression,
                   null,
                   htmlAttributes);
        }
        
        public static MvcHtmlString ControlLabel(this HtmlHelper html, string expression, string labelText) 
        {
            Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
            htmlAttributes.Add("class", "control-label");

            return LabelHelper(html,
                   ModelMetadata.FromStringExpression(expression, html.ViewData),
                   expression,
                   labelText,
                   htmlAttributes);            
        }

        public static MvcHtmlString ControlLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
            htmlAttributes.Add("class", "control-label");

            return html.LabelFor(expression, null, htmlAttributes);            
        }

        public static MvcHtmlString ControlLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string labelText)
        {
            Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
            htmlAttributes.Add("class", "control-label");

            return html.LabelFor(expression, labelText, htmlAttributes);
        }
        
        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            return html.LabelFor(expression, null, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string labelText, object htmlAttributes)
        {
            return html.LabelFor(expression, labelText, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string labelText, IDictionary<string, object> htmlAttributes)
        {
            return LabelHelper(html,
                     ModelMetadata.FromLambdaExpression(expression, html.ViewData),
                     ExpressionHelper.GetExpressionText(expression),
                     labelText,
                     htmlAttributes);              
        }

        /// <summary>
        /// Microsofts Internal Label Helper
        /// </summary>
        /// <param name="html">Html Helper</param>
        /// <param name="metadata">Model Meta Data</param>
        /// <param name="htmlFieldName">Html Field Name</param>
        /// <param name="labelText">Label Text</param>
        /// <param name="htmlAttributes">Additional Html Attributes</param>
        /// <returns>Label Element</returns>
        internal static MvcHtmlString LabelHelper(HtmlHelper html, ModelMetadata metadata, string htmlFieldName, string labelText = null, IDictionary<string, object> htmlAttributes = null)
        {
            string resolvedLabelText = labelText ?? metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            if (String.IsNullOrEmpty(resolvedLabelText))
            {
                return MvcHtmlString.Empty;
            }

            TagBuilder tag = new TagBuilder("label");
            tag.Attributes.Add("for", TagBuilder.CreateSanitizedId(html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName)));
            tag.SetInnerText(resolvedLabelText);
            tag.MergeAttributes(htmlAttributes, replaceExisting: true);
            return tag.ToMvcHtmlString(TagRenderMode.Normal);
        }        
    }
}
