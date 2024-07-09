using Microsoft.AspNetCore.Mvc;
using Udemy.Data;
using Udemy.Models;

namespace Udemy.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult UploadTopic(AdminDashboardViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Topics.Add(model.NewTopic);
                _context.SaveChanges();
                return RedirectToAction("AdminDashboard");
            }
            return View("AdminDashboard", model);
        }

        public IActionResult AdminDashboard()
        {
            var viewModel = new AdminDashboardViewModel
            {
                Topics = _context.Topics.ToList(),
                VideoCount = _context.Topics.Count()
            };

            return View(viewModel);
        }
    }
}
