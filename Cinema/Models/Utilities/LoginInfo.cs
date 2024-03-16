using Cinema.Models.UserAccounts;
using static Cinema.Models.Account;

namespace Cinema.Models.Utilities
{
    public static class LoginInfo
    {

        public static string RoleType { get; private set; }
        public static string UserName { get; private set; }
        public static string UserToken { get; private set; }

        #region BranchManager
        public static string BranchCode { get; private set; }
        #endregion

        public static bool IsLoggedIn => !string.IsNullOrEmpty(RoleType);

        // Method to set login information
        public static void SetLoginInfo(string roleType, string userName, string userToken)
        {
            RoleType = roleType;
            UserName = userName;
            UserToken = userToken;

        }
        public static void SetBranchManager(string branchToken)
        {
            BranchCode = branchToken; 
        }
    }


}
