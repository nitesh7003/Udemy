using System.IO;
using System.Linq;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Udemy.Data;
using Udemy.Models;

namespace Udemy.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> UserDashboard(string language)
        {
            var viewModel = new UserDashboardViewModel();

            if (!string.IsNullOrEmpty(language))
            {
                viewModel.Language = language;
                viewModel.Topics = await _context.Topics
                    .Where(t => t.Language == language)
                    .ToListAsync();
            }
            else
            {
                viewModel.Topics = await _context.Topics.ToListAsync();
            }

            var userId = "current_user_id"; // Replace with actual user ID logic
            viewModel.PurchasedTopics = await _context.Purchases
                .Where(p => p.UserId == userId)
                .Select(p => p.TopicId)
                .ToListAsync();

            viewModel.CartItems = await _context.CartItems
                .Where(ci => ci.UserId == userId)
                .Include(ci => ci.Topic) // Ensure Topic is loaded
                .ToListAsync();

            return View(viewModel);
        }

        public async Task<IActionResult> AddToCart(int topicId)
        {
            var userId = "current_user_id"; // Replace with actual user ID logic
            var topic = await _context.Topics.FindAsync(topicId);

            if (topic == null)
            {
                return NotFound();
            }

            var cartItem = new CartItem
            {
                UserId = userId,
                TopicId = topicId
            };

            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();

            return RedirectToAction("UserDashboard");
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmPayment(string razorpayPaymentId)
        {
            var userId = "current_user_id"; // Replace with actual user ID logic
            var purchasedTopics = await _context.CartItems
                .Where(ci => ci.UserId == userId)
                .Include(ci => ci.Topic) // Ensure Topic is loaded
                .ToListAsync();

            foreach (var cartItem in purchasedTopics)
            {
                var purchase = new Purchase
                {
                    UserId = userId,
                    RazorpayPaymentId = razorpayPaymentId,
                    Date = DateTime.Now,
                    TotalAmount = cartItem.Topic.Price,
                    PaymentStatus = "Completed",
                    TopicId = cartItem.TopicId,
                    Topic = cartItem.Topic
                };
                _context.Purchases.Add(purchase);
            }

            _context.CartItems.RemoveRange(purchasedTopics);
            await _context.SaveChangesAsync();

            var purchasedVideos = purchasedTopics.Select(ci => new
            {
                ci.Topic.TopicName,
                ci.Topic.VideoUrl
            });

            return Json(new { purchasedVideos, paymentId = razorpayPaymentId });
        }

        public async Task<IActionResult> DownloadPaymentSlip(string paymentId)
        {
            var userId = "current_user_id"; // Replace with actual user ID logic
            var purchases = await _context.Purchases
                .Where(p => p.UserId == userId && p.RazorpayPaymentId == paymentId)
                .Include(p => p.Topic)
                .ToListAsync();

            if (purchases == null || purchases.Count == 0)
            {
                return NotFound();
            }

            using (var stream = new MemoryStream())
            {
                var document = new Document();
                PdfWriter.GetInstance(document, stream).CloseStream = false;
                document.Open();

                document.Add(new Paragraph("Payment Slip"));
                document.Add(new Paragraph($"Payment ID: {paymentId}"));
                document.Add(new Paragraph($"Date: {DateTime.Now}"));
                document.Add(new Paragraph("Purchased Topics:"));

                foreach (var purchase in purchases)
                {
                    document.Add(new Paragraph($"- {purchase.Topic.TopicName}: ₹{purchase.TotalAmount}"));
                }

                document.Close();
                stream.Position = 0;
                return File(stream.ToArray(), "application/pdf", "PaymentSlip.pdf");
            }
        }
    }
}
