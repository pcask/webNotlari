using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF_CodeFirst.Library
{
    public static class MyExtensions
    {

        public static MvcHtmlString ActionLinkWithIcon(this HtmlHelper helper, string actionName, string controllerName, string linkClass, string iconClass, string parameters = "", string id = "link")
        {
            //< a href = "/Kisi/Duzenle" class="float-right"><span class="ion ion-location"></span></a>

            TagBuilder spanTag = new TagBuilder("span");
            spanTag.AddCssClass(iconClass);

            TagBuilder atag = new TagBuilder("a");
            atag.AddCssClass(linkClass);
            atag.GenerateId(id);
            atag.Attributes.Add(new KeyValuePair<string, string>("href", $"/{controllerName}/{actionName}{parameters}"));

            atag.InnerHtml = spanTag.ToString();

            return MvcHtmlString.Create(atag.ToString());
        }
    }
}