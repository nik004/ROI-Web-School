namespace Crm.Controllers
{
	using System.Web.Mvc;
	using Domain;

	public class HomeController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			return View(ServiceFactory.Resolve<IUserService>().GetAll());
		}
	}
}