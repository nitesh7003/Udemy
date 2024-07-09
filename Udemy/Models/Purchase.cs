using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public string RazorpayPaymentId { get; set; }

        public DateTime Date { get; set; }

        public decimal TotalAmount { get; set; }

        public string PaymentStatus { get; set; } // E.g., "Completed", "Pending", etc.

        [ForeignKey("TopicId")]
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}
