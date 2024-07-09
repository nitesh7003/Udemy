using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Udemy.Models
{

        public class CartItem
        {
            [Key]
            public int Id { get; set; }
            public string UserId { get; set; }
            public int TopicId { get; set; }
            [ForeignKey("TopicId")]
            public Topic Topic { get; set; }
        }
    }



