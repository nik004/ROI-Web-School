using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Crm.Data;

namespace Crm.Controllers
{
    public class CallsController : Controller
    {
        

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Calls (int ClientId)
        {
            
            return View(new CallsModelView(ClientId));
        }

    }
}
