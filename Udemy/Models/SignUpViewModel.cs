using System.ComponentModel.DataAnnotations;

namespace Udemy.Models
{
    public class SignUpViewModel
    {
        [Key]
        public int Id { get; set; }  // Primary key

        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool SpecialOffers { get; set; }
    }
}
