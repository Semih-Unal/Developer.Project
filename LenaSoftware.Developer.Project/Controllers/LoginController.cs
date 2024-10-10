using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace LenaSoftware.Developer.Project.Controllers
{
    public class LoginController : BaseController
    {
        private readonly ILogger<LoginController> _logger;

        private readonly IUserService userService;
        public LoginController(IUserService userService, ILogger<LoginController> logger)
        {
            this.userService = userService;
            _logger = logger;
        }
        public IActionResult Index()
        {
            this.SetAuthenticationRequired(false);
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string userName, string password)
        {
            var user = userService.GetUser(userName);
            if (user == null)
            {
                return this.RedirectWithAlertMessage("Kullanıcı Adı Hatalı", "Login");
            }
            else
            {
                if (user != null && user.Password == password)
                {
                    HttpContext.Session.SetString(UserSessionKey, user.Id.ToString());
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return this.RedirectWithAlertMessage("Şifre Hatalı", "Index");
                }
            }
        }
    }
}
