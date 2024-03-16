using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public string UserToken { get; set; }

        public enum AccountTypeSelections
        {
            [Description("Admin")]
            Admin,
            [Description("Customer")]
            Customer,
            [Description("Branch Manager")]
            BranchManager
        }
        [NotMapped]
        [Description("Manager's Branch")]
        public string BranchCode { get; set; }

    }
}
