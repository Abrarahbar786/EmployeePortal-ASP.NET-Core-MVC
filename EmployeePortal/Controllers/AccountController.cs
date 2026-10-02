using Microsoft.AspNetCore.Mvc;

namespace EmployeePortal.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Demo login credentials
            if (username == "admin" && password == "123")
            {
                HttpContext.Session.SetString("IsLoggedIn", "true");
                HttpContext.Session.SetString("Username", username);

                return RedirectToAction("List", "Employee");
            }

            ViewBag.Error = "Invalid username or password.";

            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login", "Account");
        }
    }
}