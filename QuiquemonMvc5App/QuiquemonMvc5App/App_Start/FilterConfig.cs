using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QuiquemonMvc5App
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
			filters.Add(new AntiForgeryTokenFilter());
			filters.Add(new AuthorizeLoggedInUserAttribute());
		}
	}

	class AntiForgeryTokenFilter : FilterAttribute, IExceptionFilter
	{
		public void OnException(ExceptionContext context)
		{
			if (context.Exception.GetType() == typeof(HttpAntiForgeryException)) {
				context.ExceptionHandled = true;
				context.Result = new RedirectToRouteResult(new RouteValueDictionary {
					{ "Controller", "General" },
					{ "Action", "Forbidden" }
				});
			}
		}
	}

	class AuthorizeLoggedInUserAttribute : AuthorizeAttribute
	{
		protected override void HandleUnauthorizedRequest(AuthorizationContext context)
		{
			context.Result = new RedirectToRouteResult(new RouteValueDictionary {
				{ "Controller", "General" },
				{ "Action", "Forbidden" }
			});
		}

		protected override bool AuthorizeCore(HttpContextBase context)
		{
			return context.Session["User"] != null;
		}
	}
}