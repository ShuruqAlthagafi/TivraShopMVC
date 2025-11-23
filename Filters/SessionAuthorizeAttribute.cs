//using Microsoft.AspNetCore.Mvc.Filters;

//namespace TivraShopMVC.Filters
//{
//    public class SessionAuthorizeAttribute: ActionFilterAttribute
//    {
//        public override void OnActionExecuting(ActionExecutingContext context)
//        {
//            var email = context.HttpContext.Session.GetString("UserEmail");
//            var role = context.HttpContext.Session.GetString("UserRole");

//            if (email == null)
//            {
//                context.HttpContext.Response.Redirect("/Account/Login");
//            }
//            else {
//                if (role != "Admin")
//                {
//                    context.HttpContext.Response.Redirect("/Account/Login");
//                }

//            }
//            base.OnActionExecuting(context);
//        }

//    }
//}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TivraShopMVC.Filters
{
    public class SessionAuthorizeAttribute : ActionFilterAttribute
    {
        public string AllowedRole { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var email = context.HttpContext.Session.GetString("UserEmail");
            var role = context.HttpContext.Session.GetString("UserRole");

            if (email == null)
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
                return;
            }

            if (!string.IsNullOrEmpty(AllowedRole) && role != AllowedRole)
            {
                context.Result = new RedirectToActionResult("AccessDenied", "Account", null);
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
