using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AcquireLunch.Helpers
{
    public static class HtmlHelpers
    {
        public static string Truncate(this HtmlHelper helper, string input, int length)
        {
            if (input.Length <= length)
            {
                return input;
            }
            else
            {
                return input.Substring(0, length) + "...";
            }
        }

        public static MvcHtmlString AutocompleteFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            string fullHtmlFieldName = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);

            var selectBuilder = new TagBuilder("select");
            selectBuilder.MergeAttribute("name", fullHtmlFieldName);
            selectBuilder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            selectBuilder.MergeAttribute("autocorrect", "off");
            selectBuilder.MergeAttribute("autocomplete", "off");

            var selectListBuilder = new TagBuilder("option");
            selectListBuilder.MergeAttribute("value", "");
            selectListBuilder.MergeAttribute("selected", "selected");

            var innerHtmlBuilder = new StringBuilder();
            innerHtmlBuilder.Append(selectListBuilder.ToString(TagRenderMode.Normal));

            foreach (var item in selectList)
            {
                selectListBuilder = new TagBuilder("option");
                selectListBuilder.MergeAttribute("value", item.Value);
                selectListBuilder.InnerHtml = item.Text;
                innerHtmlBuilder.Append(selectListBuilder.ToString(TagRenderMode.Normal));
            }

            selectBuilder.InnerHtml = innerHtmlBuilder.ToString();
            selectBuilder.MergeAttributes(helper.GetUnobtrusiveValidationAttributes(name));

            return MvcHtmlString.Create(selectBuilder.ToString(TagRenderMode.Normal));
            //return output.ToString();
        }
    }
}