using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Task_Manager.Helpers
{
    public static class Helpers
    {
        public static MvcHtmlString ImageActionLink(this HtmlHelper htmlHelper, string linkText, string action, string controller,
           object routeValues, object htmlAttributes, string imageSrc)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var img = new TagBuilder("img");
            img.AddCssClass("Images");

            img.Attributes.Add("src", VirtualPathUtility.ToAbsolute(imageSrc));

            var Tag_a = new TagBuilder("a")
            {
                InnerHtml = img.ToString(TagRenderMode.SelfClosing)
            };

            Tag_a.Attributes["href"] = urlHelper.Action(action, controller, routeValues);
            Tag_a.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            return new MvcHtmlString(Tag_a.ToString());
        }
    
        public static MvcHtmlString Card(this HtmlHelper helper, string Tittle, string Content, MvcHtmlString Delete, MvcHtmlString Edit)
        {
            string html = "<div class=\"Task\">" +
                                    "<div class=\"Tittle\"><div id=\"tittle\">" + Tittle + "</div>"+
                                    "<div class=\"Buttons\">" + Delete + Edit + "</div></div>" +
                                    "<div class=\"Content\">" + Content + "</div>" +
                            "</div>";

            return new MvcHtmlString(html);
        }
    }
}