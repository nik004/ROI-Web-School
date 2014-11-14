namespace Crm.Admin.Controllers
{
	using System.Web.Mvc;
	using System.Web.Security;
	using Models;

	public class AuthenticationController : Controller
    {
		[HttpGet]
        public ActionResult Login(string returnUrl)
        {
            return View(new AuthenticationModel { ReturnUrl = returnUrl ?? string.Empty });
        }

	    [HttpPost, ValidateAntiForgeryToken]
	    public ActionResult Login(AuthenticationModel model)
	    {
		    if (!ModelState.IsValid)
			    return View(model);

			var user = model.Logon();
		    if (user != null)
		    {
				FormsAuthentication.SetAuthCookie(user.Login, model.Remember);
			    return Redirect(string.IsNullOrEmpty(model.ReturnUrl) ? FormsAuthentication.DefaultUrl : model.ReturnUrl);
		    }

		    ModelState.AddModelError("Key", "Invalid login or password.");
		    return View(model);
	    }
    }
}
