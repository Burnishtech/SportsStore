using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SportsStore.WebUI.Models;
using System.Text;

namespace SportsStore.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString Pagelinks(this HtmlHelper html, PagingInfo pageinginfo,Func<int, string> pageURL)
        {
            StringBuilder result = new StringBuilder();
            for( int i = 1; i <= pageinginfo.TotalPages; i++)
            {

                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageURL(i));
                tag.InnerHtml = i.ToString();
                if(i== pageinginfo.CurrentPages)
                {

                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primery");

                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());

        }
    }
}