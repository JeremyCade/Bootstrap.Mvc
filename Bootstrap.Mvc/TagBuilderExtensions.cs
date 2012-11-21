//-----------------------------------------------------------------------
// <copyright file="TagBuilderExtensions.cs" company="Jeremy Cade">
//      No Copyright Intended. Use the code as you wish.
// </copyright>
//-----------------------------------------------------------------------
namespace Bootstrap.Mvc
{
    using System.Web.Mvc;

    /// <summary>
    /// TagBuilder Extensions
    /// </summary>
    public static class TagBuilderExtensions
    {
        public static MvcHtmlString ToMvcHtmlString(this TagBuilder tagBuilder, TagRenderMode renderMode)
        {
            return new MvcHtmlString(tagBuilder.ToString(renderMode));
        }
    }
}