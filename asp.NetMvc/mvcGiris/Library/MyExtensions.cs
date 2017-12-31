using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace mvcGiris.Library
{
    public static class MyExtensions
    {
        // Yazılan extension methodun hangi sınıf içerisinde çıkmasını istiyorsak methoda ilk parametre olarak this anahtar kelimesi ile o sınıfın tipinden bir parametre belirtilmelidir.
        public static MvcHtmlString Button(this HtmlHelper helper, string id = "", ButtonType type = ButtonType.button, string text = "")
        {
            string html = $"<button id={id} name={id} type={type.ToString()}>{text}</button>";

            return MvcHtmlString.Create(html);
        }

        public static MvcHtmlString ButtonWithTagBuilder(this HtmlHelper helper, string id = "", ButtonType type = ButtonType.button, string text = "")
        {
            TagBuilder tag = new TagBuilder("button");
            tag.AddCssClass("btn btn-success");
            tag.GenerateId(id);
            tag.Attributes.Add(new KeyValuePair<string, string>("name", id));
            tag.Attributes.Add(new KeyValuePair<string, string>("type", type.ToString()));
            tag.SetInnerText(text);

            return MvcHtmlString.Create(tag.ToString());
        }

        // Html içinde html yazabileceğimiz method örneği
        public static MvcHtmlString Paragraph(this HtmlHelper helper, string id = "", Func<object, HelperResult> template = null)
        {
            string html = $"<p id={id} name={id}>{template.Invoke(null)}</p>";

            return MvcHtmlString.Create(html);
        }
    }

    public enum ButtonType
    {
        button,
        submit,
        reset
    }
}