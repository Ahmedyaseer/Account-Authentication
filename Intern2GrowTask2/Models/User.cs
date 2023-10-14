using System.ComponentModel.DataAnnotations;

namespace Intern2GrowTask2.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50, MinimumLength = 5)]
        
        public string UserName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, Compare(nameof(Password), ErrorMessage="Password Mismatch ")]
        [StringLength(20)]
        [DataType(DataType.Password)]

        public string ConfirnPassword { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }   
    }
}
