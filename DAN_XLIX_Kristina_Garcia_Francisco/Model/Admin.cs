namespace DAN_XLIX_Kristina_Garcia_Francisco.Model
{
    /// <summary>
    /// Current logged in admin data
    /// </summary>
    public static class Admin
    {
        /// <summary>
        /// Admin Username
        /// </summary>
        private static string adminUsername;
        public static string AdminUsername
        {
            get { return adminUsername; }
            set { adminUsername = value; }
        }

        /// <summary>
        /// Admin Password
        /// </summary>
        private static string adminPassword;
        public static string AdminPassword
        {
            get { return adminPassword; }
            set { adminPassword = value; }
        }
    }
}
