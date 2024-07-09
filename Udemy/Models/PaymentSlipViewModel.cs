using System;

namespace Udemy.Models
{
    public class PaymentSlipViewModel
    {
        public int PurchaseId { get; set; }
        public string RazorpayPaymentId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; }
    }
}
