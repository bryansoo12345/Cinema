using System.ComponentModel.DataAnnotations;

namespace Cinema.Models.UserAccounts
{
    //Admin will have all the privilleges
    public class BranchManager 
    {
        [Key]
        public int Id { get; set; }

        public string UserToken { get; set; }

        public string BranchCode { get; set; }

    }
}
