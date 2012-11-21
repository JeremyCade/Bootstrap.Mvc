// -----------------------------------------------------------------------
// <copyright file="InputExtensions.cs" company="Jeremy Cade">
//      No Copyright Intended. Use the code as you wish.
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
            return LabelCheckBoxFor(htmlHelper, expression, null, null);
        }

        public static MvcHtmlString LabelCheckBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            return LabelCheckBoxFor(htmlHelper, expression, null, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString LabelCheckBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes)
        {
            return LabelCheckBoxFor(htmlHelper, expression, null, htmlAttributes);
        }

        public static MvcHtmlString LabelCheckBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, string labelText)
        {
            return LabelCheckBoxFor(htmlHelper, expression, labelText, null);
        }

        public static MvcHtmlString LabelCheckBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, string labelText, object htmlAttributes)
        {
            return LabelCheckBoxFor(htmlHelper, expression, labelText, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString LabelCheckBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, string labelText = null, IDictionary<string, object> htmlAttributes = null)
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

            string resolvedLabelText = labelText ?? metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            if (String.IsNullOrEmpty(resolvedLabelText))
            {
                return MvcHtmlString.Empty;
            }

            TagBuilder label = new TagBuilder("label");
            label.MergeAttributes(htmlAttributes, replaceExisting: true);
            label.MergeAttribute("class", "checkbox"); // Add Twitter Bootstrap checkbox style to the label.
            label.Attributes.Add("for", htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
            label.InnerHtml = String.Format("{0}{1}", htmlHelper.CheckBox(htmlFieldName, isChecked).ToHtmlString(), resolvedLabelText);

            return label.ToMvcHtmlString(TagRenderMode.Normal);
        }
    }
}