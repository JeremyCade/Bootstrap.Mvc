// -----------------------------------------------------------------------
// <copyright file="InputExtensions.cs" company="">
//  No Copyright Intended. Use the code as you wish. 
// </copyright>
// -----------------------------------------------------------------------

namespace Bootstrap.Mvc
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;    

    /// <summary>
    /// Set of Bootstrap Friendly Input Extensions
    /// </summary>
    public static class InputExtensions
    {
        public static MvcHtmlString LabelCheckBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression)
        {
            return LabelCheckBoxFor(htmlHelper, expression, null);
        }

        public static MvcHtmlString LabelCheckBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            return LabelCheckBoxFor(htmlHelper, expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString LabelCheckBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);

            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            bool? isChecked = null;
            if (metadata.Model != null)
            {
                bool modelChecked;
                if (Boolean.TryParse(metadata.Model.ToString(), out modelChecked))
                {
                    isChecked = modelChecked;
                }
            }

            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            if (string.IsNullOrEmpty(labelText))
            {
                return MvcHtmlString.Empty;
            }            
            
            TagBuilder label = new TagBuilder("label");
            label.MergeAttributes(htmlAttributes);
            label.MergeAttribute("class","checkbox"); // Add Twitter Bootstrap checkbox style to the label.
            label.Attributes.Add("for", htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
            label.InnerHtml = htmlHelper.CheckBox(htmlFieldName, isChecked).ToString();
            label.SetInnerText(labelText);

            return label.ToMvcHtmlString(TagRenderMode.Normal);
        }
    }
}
