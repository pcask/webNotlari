using Bootstrap_HelperMethods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Bootstrap_HelperMethods.Library
{
    public static class MyExtensions
    {

        public static MvcHtmlString Alert(this HtmlHelper helper, string id = "alert", string color = "success", string text = "")
        {
            // < div class="alert alert-primary" role="alert">
            //  Örnek Text Burada Yer Alacak
            // </div>

            TagBuilder tag = new TagBuilder("div");
            tag.GenerateId(id);
            tag.AddCssClass("alert alert-" + color);
            tag.Attributes.Add(new KeyValuePair<string, string>("role", "alert"));
            tag.SetInnerText(text);

            return MvcHtmlString.Create(tag.ToString());
        }

        public static MvcHtmlString AlertFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            TagBuilder tag = new TagBuilder("div");
            tag.AddCssClass("alert");
            tag.Attributes.Add(new KeyValuePair<string, string>("role", "alert"));

            var valueGetter = expression.Compile();
            Message message = valueGetter(helper.ViewData.Model) as Message;

            if (message.Id == Guid.Empty) message.Id = new Guid();

            tag.GenerateId(message.Id.ToString());

            if (message.Level < 1) message.Level = 1;
            if (message.Level > 4) message.Level = 4;

            switch (message.Level)
            {
                case 1:
                    tag.AddCssClass("alert-success");
                    break;
                case 2:
                    tag.AddCssClass("alert-info");
                    break;
                case 3:
                    tag.AddCssClass("alert-warning");
                    break;
                case 4:
                    tag.AddCssClass("alert-danger");
                    break;
                default:
                    break;
            }

            // MergeAttributes ile birden fazla attributes ikililerini tag'imize ekliyebiliyoruz.
            // MergeAttributes generic methodu bizden IDictionary interface'ini implement etmiş bir tip bekliyor.
            // Her attributes için teker teker Dictionary tanımlamak yerine RouteValueDictionary sınıfından yararlanıyoruz.
            // RouteValueDictionary object tipinden aldığı key - value ikililerini Dictionarye çevirmeyi sağlıyor.
            tag.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            tag.SetInnerText(message.Text);

            return MvcHtmlString.Create(tag.ToString());

        }

    }
}