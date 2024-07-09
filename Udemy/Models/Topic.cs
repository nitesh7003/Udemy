using System.ComponentModel.DataAnnotations;

namespace Udemy.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string TopicName { get; set; }
        public string Language { get; set; }
        public string VideoUrl { get; set; }
        public decimal Price { get; set; } = 200m; // Default price set to 200
    }

}
