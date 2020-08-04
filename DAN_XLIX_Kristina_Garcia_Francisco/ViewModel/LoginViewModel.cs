using DAN_XLIX_Kristina_Garcia_Francisco.Commands;
using DAN_XLIX_Kristina_Garcia_Francisco.Model;
using DAN_XLIX_Kristina_Garcia_Francisco.View;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace DAN_XLIX_Kristina_Garcia_Francisco.ViewModel
{
    class LoginViewModel : BaseViewModel
    {
        Login view;
        Service service = new Service();
        FileReadWrite frw = new FileReadWrite();

        #region Constructor
        public LoginViewModel(Login loginView)
        {
            view = loginView;
            user = new tblUser();
            UserList = service.GetAllUsers().ToList();
            frw.ReadAdminFile();
        }
        #endregion

        #region Property
        /// <summary>
        /// Login info label
        /// </summary>
        private string infoLabel;
        public string InfoLabel
        {
            get
            {
                return infoLabel;
            }
            set
            {
                infoLabel = value;
                OnPropertyChanged("InfoLabel");
            }
        }

        /// <summary>
        /// Used for saving the current user
        /// </summary>
        private tblUser user;
        public tblUser User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        /// <summary>
        /// List of all users in the application
        /// </summary>
        private List<tblUser> userList;
        public List<tblUser> UserList
        {
            get
            {
                return userList;
            }
            set
            {
                userList = value;
                OnPropertyChanged("UserList");
            }
        }
        #endregion

        #region Commands
        /// <summary>
        /// Command used to log te user into the application
        /// </summary>
        private ICommand login;
        public ICommand Login
        {
            get
            {
                if (login == null)
                {
                    login = new RelayCommand(LoginExecute);
                }
                return login;
            }
        }

        /// <summary>
        /// Checks if its possible to login depending on the given username and password and saves the logged in user to a list
        /// </summary>
        /// <param name="obj"></param>
        private void LoginExecute(object obj)
        {
            string password = (obj as PasswordBox).Password;
            bool found = false;
            if (User.Username == Admin.AdminUsername && password == Admin.AdminPassword)
            {
                InfoLabel = "Logged in";

                AddUser addUser = new AddUser();
                view.Close();
                addUser.Show();
            }
            else if (UserList.Any())
            {
                for (int i = 0; i < UserList.Count; i++)
                {
                    if (User.Username == UserList[i].Username && password == UserList[i].UserPassword)
                    {
                        LoggedUser.CurrentUser = new tblUser
                        {
                            UserID = UserList[i].UserID,
                            FirstName = UserList[i].FirstName,
                            LastName = UserList[i].LastName,
                            DateOfBirth = UserList[i].DateOfBirth,
                            Email = UserList[i].Email,
                            Username = UserList[i].Username,
                            UserPassword = UserList[i].UserPassword
                        };
                        InfoLabel = "Logged in";
                        found = true;

                        if (User.UserID == int.Parse(service.GetAllManagers().Where(id => id.UserID == User.UserID).ToString()))
                        {
                            Manager man = new Manager();
                            view.Close();
                            man.Show();
                        }
                        else if(User.UserID == int.Parse(service.GetAllEmployees().Where(id => id.UserID == User.UserID).ToString()))
                        {
                            Employee emp = new Employee();
                            view.Close();
                            emp.Show();
                        }
                        break;
                    }
                }

                if (found == false)
                {
                    InfoLabel = "Wrong Username or Password";
                }
            }
        }
        #endregion
    }
}
