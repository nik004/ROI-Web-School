using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Web.Mvc;

namespace AjaxTestApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BundleLoad()
        {
            return View();
        }

        public ActionResult AsyncLoad()
        {
            return View();
        }

        public ActionResult SyncLoad()
        {
            return View();
        }

        public ActionResult FullAsyncLoad()
        {
            return View();
        }

        public ActionResult InLineJavaScript()
        {
            return View();
        }

        public ActionResult JqueryShorthandMethods()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetPostDocumentation()
        {
            var result = new FilePathResult("~/Resources/jQueryLoadDocumentation.html", "text/html");
            return result;
        }

        public ActionResult AjaxEvents()
        {
            return View();
        }

        public JsonResult GetAjaxTipsWithDelay()
        {
            Thread.Sleep(5000);
            return Json(new
            {
                data = String.Join(String.Empty, new List<string>
                {
                    "<p>AJAX is <b>A</b>synchronous <b>J</b>avaScript <b>A</b>nd <b>X</b>ML</p>",
                    "<p>AJAX is not a language</p>",
                    "<p>AJAX is not a technology</p>",
                    "<p>AJAX is coined by Jesse James Garret </p>",
                    "<p>AJAX is a group of Web development techniques used on the client-side to create asynchronous Web applications</p>"
                })
            }, "application/javascript", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }
    }
}
