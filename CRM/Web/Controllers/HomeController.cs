namespace Crm.Controllers
{
	using System.Web.Mvc;
	using Domain;
    using Data;
    using Data.Entities;

	public class HomeController : Controller
	{
        [HttpGet]
        public ActionResult Index()
        {
            var model = new CrmViewModel();
            return View(model); 
        }

        [HttpGet]
        public ActionResult Edit(int _id)
        {
            return RedirectToAction("Edit", "Clients", new { id = _id });    
        }

        [HttpGet]
        public ActionResult Add()
        {
            return RedirectToAction("Add", "Clients");
        }
	}
}