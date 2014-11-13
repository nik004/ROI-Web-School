namespace Crm.Admin
{
	using System.Web.Mvc;
	using System.Web.Routing;

	internal static class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Authentication",
				url: "login",
				defaults: new { controller = "Authentication", action = "Login" }
			);

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "User", action = "List", id = UrlParameter.Optional }
			);
		}
	}
}