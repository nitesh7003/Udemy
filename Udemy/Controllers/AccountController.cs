using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Udemy.Models;

namespace Udemy.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/SignUp
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        // POST: /Account/SignUp
        [HttpPost]
        public IActionResult SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                // TODO: Save user data to the database
                // Example: _userRepository.AddUser(model);

                // Redirect to login after signup
                return RedirectToAction("Login");
            }

            return View(model);
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Simulate user authentication (replace with actual logic)
                var isValidUser = true; // Example: _userRepository.ValidateUser(model);

                if (isValidUser)
                {
                    // Simulate admin check based on email (hardcoded example)
                    if (model.Email == "admin@example.com" && model.Password == "adminpassword")
                    {
                        // Redirect to admin dashboard
                        return RedirectToAction("AdminDashboard", "Admin");
                    }
                    else
                    {
                        // Redirect to user dashboard
                        return RedirectToAction("UserDashboard", "User"); 
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt");
                }
            }

            // If we got this far, something failed; redisplay form
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // Perform logout actions, such as clearing authentication cookies
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }

        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // TODO: Save user data to the database
                // Example: _userRepository.AddUser(model);

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        // GET: /Account/Index
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Account/SubscriptionPlans
        [HttpGet]
        public IActionResult SubscriptionPlans()
        {
            return View();
        }

        // GET: /Account/CSharp
        public IActionResult CSharp()
        {
            return View();
        }

        // GET: /Account/SQL
        public IActionResult SQL()
        {
            return View();
        }

        // GET: /Account/ASP
        public IActionResult ASP()
        {
            return View();
        }
    }
}
