namespace DAN_XLIX_Kristina_Garcia_Francisco.Model
{
    /// <summary>
    /// Current logged in user data
    /// </summary>
    public static class LoggedUser
    {
        /// <summary>
        /// Current User
        /// </summary>
        private static tblUser currentUser;
        public static tblUser CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
        }
    }
}
