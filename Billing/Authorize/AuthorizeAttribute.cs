using BusinessLogicLayer.Implementation;
using BusinessLogicLayer.Interface;
using BusinessObjectLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using System.Web.Routing;

namespace Billing.Authorize
{
    public class BaseController : Controller
    {
        protected override void OnAuthorization(AuthorizationContext context)
        {
            context.Result = new RedirectToRouteResult(new
  RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {

            }
        }
    }
}