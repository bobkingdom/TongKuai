using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TongKuai.Web.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        public ActionResult Index(string error)
        {
            ViewBag.Title = "WebSite 网站内部错误";
            ViewBag.Description = error;
            return View("Index");
        }

        public ActionResult HttpError404(string error)
        {
            ViewBag.Title = "HTTP 404- 无法找到文件";
            ViewBag.Description = error;
            return View("Index");
        }

        public ActionResult HttpError500(string error)
        {
            ViewBag.Title = "HTTP 500 - 内部服务器错误";
            ViewBag.Description = error;
            return View("Index");
        }

        public ActionResult General(string error)
        {
            ViewBag.Title = "HTTP 发生错误";
            ViewBag.Description = error;
            return View("Index");
        }

    }
}
