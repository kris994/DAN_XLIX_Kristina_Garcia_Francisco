using DAN_XLIX_Kristina_Garcia_Francisco.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DAN_XLIX_Kristina_Garcia_Francisco.Helper
{
    /// <summary>
    /// Validates the user inputs
    /// </summary>
    class Validation
    {
        /// <summary>
        /// Value has to be a double
        /// </summary>
        /// <param name="number">input value</param>
        /// <returns>null if the input is correct or string error message if its wrong</returns>
        public string IsDouble(string number)
        {
            if (double.TryParse(number, out double value) == false || value < 0)
            {
                return "Not a valid number";
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Checks if the degree is valid
        /// </summary>
        /// <param name="degree">degree we are checking</param>
        /// <returns>null if the input is correct or string error message if its wrong<</returns>
        public string DegreeChecker(string degree)
        {
            if(degree == null)
            {
                return "Degree cannot be empty.";
            }

            if (degree != "I" && degree != "II" && degree != "III" && degree != "IV" && degree != "V" && degree != "VI" && degree != "VII")
            {
                return "Invalid degree";
            }

            return null;
        }
        /// <summary>
        /// Checks if the Username is exists
        /// </summary>
        /// <param name="username">the username we are checking</param>
        /// <param name="id">for the specific user</param>
        /// <returns>null if the input is correct or string error message if its wrong</returns>
        public string UsernameChecker(string username, int id)
        {
            Service service = new Service();

            List<tblUser> AllUsers = service.GetAllUsers();
            string currectUsername = "";

            if (username == null)
            {
                return "Username cannot be empty.";
            }
            // Get the current users username
            for (int i = 0; i < AllUsers.Count; i++)
            {
                if (AllUsers[i].UserID == id)
                {
                    currectUsername = AllUsers[i].Username;
                    break;
                }
            }

            // Cannot be the same username as admins
            if (username == Admin.AdminUsername)
            {
                return "This Username already exists!";
            }

            // Check if the username already exists, but it is not the current user username
            for (int i = 0; i < AllUsers.Count; i++)
            {
                if ((AllUsers[i].Username == username && currectUsername != username))
                {
                    return "This Username already exists!";
                }
            }

            return null;
        }

        /// <summary>
        /// Validates the given string if its an email or not
        /// </summary>
        /// <param name="email">string that is validated</param>
        /// <param name="id">for the specific user</param>
        /// <returns>null if the input is correct or string error message if its wrong</returns>
        public string IsValidEmailAddress(string email, int id)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            Service service = new Service();

            List<tblUser> AllUsers = service.GetAllUsers();
            string currentEmail = "";

            if (email == null)
            {
                return "Email cannot be empty.";
            }

            // Get the current users email
            for (int i = 0; i < AllUsers.Count; i++)
            {
                if (AllUsers[i].UserID == id)
                {
                    currentEmail = AllUsers[i].Email;
                    break;
                }
            }

            // Check if the email already exists, but it is not the current user email
            for (int i = 0; i < AllUsers.Count; i++)
            {
                if (AllUsers[i].Email == email && currentEmail != email)
                {
                    return "This Email already exists!";
                }
            }

            if (regex.IsMatch(email) == false)
            {
                return "Invalid email";
            }

            return null;
        }
    }
}
