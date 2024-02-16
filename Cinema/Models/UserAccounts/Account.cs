using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Account 
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "User Name")]
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Display(Name = "Full Name")]
        public string? Name { get; set; }

        [Display(Name = "Email Address")]
        public string? Email { get; set; }

        [Display(Name = "Account Type")]
        public string AccountType { get; set; }

        public enum AccountTypeSelections
        {
            Admin,
            Customer
        }

    }
}
