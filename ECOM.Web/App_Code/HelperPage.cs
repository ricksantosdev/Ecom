using System.Web.Mvc;
using System.Web.WebPages;
namespace ECOM.Web.App_Code
{
    public static class HelperPage
    {
        public static HtmlHelper GetPageHelper(this System.Web.WebPages.Html.HtmlHelper html)
        {
            return ((System.Web.Mvc.WebViewPage)WebPageContext.Current.Page).Html;
        }
    }
}