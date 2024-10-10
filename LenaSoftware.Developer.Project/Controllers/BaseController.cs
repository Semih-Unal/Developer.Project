using Business.Abstract;
using Data;
using LenaSoftware.Developer.Project.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace LenaSoftware.Developer.Project.Controllers
{
    public class BaseController : Controller
    {
        public string ApplicationName = "BackOffice";
        public static string UserSessionKey = "Session_User";
        public static string DefaultPageSessionKey = "Session_DefaultPage";
        public static string RedirectPageSessionKey = "Session_RedirectPage";

        private string redirectPage = string.Empty;
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (this.AuthenticationRequired(filterContext))
            {
                bool HasLogin = HttpContext.Session.Get(UserSessionKey) != null;
                if (!HasLogin)
                {
                    redirectPage = "/Login/Index";
                }
            }
            if (!string.IsNullOrWhiteSpace(redirectPage))
            {
                filterContext.Result = new RedirectResult(redirectPage);
            }
            base.OnActionExecuted(filterContext);
        }
        public void SetPageTitle(string value)
        {
            ViewBag.PageTitle = value;
        }
        public void SetAuthenticationRequired(bool value)
        {
            ViewBag.AuthenticationRequired = value;
        }

        public ActionResult RedirectWithAlertMessage(string message, string actionName, string controllerName, object values)
        {
            TempData["alertMessage"] = message;
            return RedirectToAction(actionName, controllerName, values);
        }

        public ActionResult RedirectWithAlertMessage(string message, string actionName)
        {
            return RedirectWithAlertMessage(message, actionName, null);
        }

        public ActionResult RedirectWithAlertMessage(string message, string actionName, object values)
        {
            return RedirectWithAlertMessage(message, actionName, null, values);
        }
        private bool AuthenticationRequired(ActionExecutedContext filterContext)
        {
            var controller = filterContext.Controller as Controller;
            if (controller.ViewBag.AuthenticationRequired == null)
                return true;
            else
                return Convert.ToBoolean(controller.ViewBag.AuthenticationRequired);
        }
    }
}
