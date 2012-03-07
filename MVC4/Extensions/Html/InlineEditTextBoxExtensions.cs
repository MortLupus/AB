using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MVC4.Extensions.Html
{
    public static class InlineEditTextBoxExtensions
    {
        public static MvcHtmlString InlineEditTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.DisplayFor(expression, "InlineEditTextBox");
        }
    }
}