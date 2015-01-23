using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Crm.Data;

namespace Crm.Controllers
{
    public class ClientsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(new ClientViewModel(id));
            // @{Html.RenderAction("Contacts", new { m = Model.Contacts });}
        }

        [HttpGet]
        public ActionResult PartialContacts(ContactsViewModel Contacts)
        {

            return PartialView(Contacts);
           
        }
        
        [HttpGet]
        public ActionResult Add()
        {
            return View(new ClientViewModel());
            //
        }

        [HttpPost]
        public ActionResult Add(ClientViewModel model)
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

            return RedirectToAction("Index", "Home"); 
        }

        [HttpPost]
        public ActionResult Save(ClientViewModel model)
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

            return RedirectToAction("Index", "Home");
        }

   

    }
}
