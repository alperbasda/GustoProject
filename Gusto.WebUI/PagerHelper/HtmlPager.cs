using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gusto.WebUI.PagerHelper
{
    //Hazır pagerlar hoşuma gitmediği için ufak projelerde kendi yazdığım bu basit yapıyı kullanıyorum.
    public static class HtmlPager
    {
        private static string _pageLeftArrow = "<i class='la la-angle-left'></i>";
        private static string _pageRightArrow = "<i class='la la-angle-right'></i>";
        public static IHtmlString Pager(this HtmlHelper helper, int totalPage, NameValueCollection queryCollection)
        {
            string turnQuery = ToQueryString(queryCollection);
            string hasLeft = "";
            string hasRight = "";
            string parseOperator = queryCollection.Count <= 0 || (queryCollection.Count == 1 && queryCollection.Keys[0] == "Page") ? "" : "&";
            List<string> hrefList = new List<string>();
            int queryPage = 1;
            if (queryCollection["Page"] != null)
                queryPage = Convert.ToInt32(queryCollection["Page"]);
            if (queryPage <= 1)
            {
                hasLeft = "disabled";
                hrefList.Add("#");
                hrefList.Add("#");
            }
            else
            {
                hrefList.Add($"{turnQuery}{parseOperator}Page=1");
                hrefList.Add($"{turnQuery}{parseOperator}Page={queryPage - 1}");
            }


            if (queryPage >= totalPage)
            {
                hasRight = "disabled";
                hrefList.Add("#");
                hrefList.Add("#");
            }
            else
            {
                hrefList.Add($"{turnQuery}{parseOperator}Page={queryPage + 1}");
                hrefList.Add($"{turnQuery}{parseOperator}Page={totalPage}");
            }



            return new HtmlString(string.Format("<li class='page-item previous {3}'><a href='{5}' class='page-link'>{0}{0}</a></li>" +
                                                "<li class='page-item previous {3}'><a href='{6}' class='page-link'>{0}</a></li>" +
                                                "<li class='page-item disabled'><a href='#' class='page-link'>{1}</a></li>" +
                                                "<li class='page-item next {4}'><a href='{7}' class='page-link'>{2}</a></li>" +
                                                "<li class='page-item next {4}'><a href='{8}' class='page-link'>{2}{2}</a></li>", _pageLeftArrow, queryPage, _pageRightArrow, hasLeft, hasRight, hrefList[0], hrefList[1], hrefList[2], hrefList[3]));
        }


        private static string ToQueryString(NameValueCollection nvc)
        {
            var array = (from key in nvc.AllKeys
                         from value in nvc.GetValues(key)
                         where key != "Page"
                         select string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value)))
                .ToArray();
            return "?" + string.Join("&", array);
        }
    }
}