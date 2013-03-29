using System;
using System.Web.Compilation;
using System.Web.Mvc;
using System.Web.WebPages;

namespace TongKuai.Utility
{
    public class RazorViewHelper : IView
    {
        private string template;
        private string layout;
        public RazorViewHelper(string _template, string _layout = "~/Views/{0}/Shared/_layout.cshtml")
        {
            template = _template;
            layout = string.Format(_layout, _template);
        }
        public void Render(ViewContext viewContext, System.IO.TextWriter writer)
        {
            if (string.IsNullOrEmpty(template))
            {
                template = "default";
            }
            string viewPath = "~/Views/" + template + "/" + viewContext.RouteData.GetRequiredString("controller") + "/" + viewContext.RouteData.GetRequiredString("action") + ".cshtml";
            Type viewType = BuildManager.GetCompiledType(viewPath);
            WebViewPage page = Activator.CreateInstance(viewType) as WebViewPage;
            page.Layout = layout;
            page.VirtualPath = viewPath;
            page.ViewContext = viewContext;
            page.ViewData = viewContext.ViewData;
            page.InitHelpers();
            WebPageContext pageContext = new WebPageContext(viewContext.HttpContext, null, null);
            WebPageRenderingBase startPage = StartPage.GetStartPage(page, "_ViewStart", new string[] { "cshtml", "vbhtml" });
            page.ExecutePageHierarchy(pageContext, writer, startPage);
        }
    }
}
