using System.ComponentModel.DataAnnotations;

namespace Udemy.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        public string WorkEmail { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string CompanySize { get; set; } = string.Empty;

        [Required]
        public string Location { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public int NumberOfLearners { get; set; } = 0;

        [Required]
        public string JobTitle { get; set; } = string.Empty;

        [Required]
        public string JobLevel { get; set; } = string.Empty;

        [Required]
        public string TrainingNeeds { get; set; } = string.Empty;
    }
}
