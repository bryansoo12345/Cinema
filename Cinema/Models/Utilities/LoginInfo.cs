namespace Cinema.Models.Utilities
{
    public static class LoginInfo
    {
        private static string _roleType;
        private static bool _isLoggedIn;

        public static string RoleType
        {
            get { return _roleType; }
            set
            {
                _roleType = value;
                _isLoggedIn = true; // Set _IsLoggedIn to true when RoleType is set
            }
        }

        public static bool IsLoggedIn
        {
            get { return _isLoggedIn; }
        }
    }

}
