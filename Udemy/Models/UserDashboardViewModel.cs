using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Udemy.Models
{
    public class UserDashboardViewModel
    {
        public List<Topic> Topics { get; set; } = new List<Topic>();
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public string Language { get; set; } = string.Empty;
        public List<int> PurchasedTopics { get; set; } = new List<int>();

        // Calculate the total price of items in the cart
        public decimal TotalAmount => CartItems.Sum(item => item.Topic?.Price ?? 0);
    }

}
