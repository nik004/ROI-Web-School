using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crm.Admin.Controllers
{
	using Models;

	public class HomeController : Controller
    {
		[HttpGet]
        public ActionResult Index()
        {
            return View(new UserListModel());
        }

	    [HttpPost]
	    public PartialViewResult UserList(UserListModel model)
	    {
		    return PartialView(model.Users);
	    }
    }
}
