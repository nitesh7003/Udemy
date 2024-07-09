namespace Udemy.Models
{
    public class InvoiceViewModel
    {
        public string InvoiceId { get; set; }
        public string CourseDetails { get; set; }
        public decimal Amount { get; set; }
        public decimal GST { get; set; }
        public decimal Total { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string UserEmail { get; set; }
    }
}
