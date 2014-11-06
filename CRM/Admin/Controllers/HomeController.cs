namespace Crm.Admin.Controllers
{
    using System;
	using System.Web.Mvc;
	using Models;

	public class HomeController : Controller
    {
		[HttpGet]
        public ActionResult Index()
        {
            return View(new UserListModel());
        }

	    [HttpPost]
	    public ViewResult List(UserListModel model)
	    {
		    if (ModelState.IsValid)
		    {
				if (model.DeleteId.HasValue)
					UserModel.Delete(model.DeleteId.Value);
		    }
		    return View("Index", model);
	    }

	    [HttpPost]
	    public PartialViewResult ListAjax(UserListModel model)
	    {
		    if (ModelState.IsValid)
		    {
			    if (model.DeleteId.HasValue)
					UserModel.Delete(model.DeleteId.Value);
		    }
		    return PartialView("UserList", model);
	    }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(NewUserModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                model.Save();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex);
                return View(model);
            }

            return RedirectToAction("Index");
        }
	}
}