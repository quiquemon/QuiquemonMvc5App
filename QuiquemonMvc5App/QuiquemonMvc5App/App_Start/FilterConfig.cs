using System.Web.Routing;
using System.Web.Mvc;

namespace QuiquemonMvc5App
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
			filters.Add(new AntiForgeryTokenFilter());
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
}