using DAN_XLIX_Kristina_Garcia_Francisco.Commands;
using DAN_XLIX_Kristina_Garcia_Francisco.Model;
using DAN_XLIX_Kristina_Garcia_Francisco.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace DAN_XLIX_Kristina_Garcia_Francisco.ViewModel
{
    /// <summary>
    /// Main Window view model
    /// </summary>
    class AllUsersViewModel : BaseViewModel
    {
        AllUsers allUsers;
        Service service = new Service();

        #region Constructor
        /// <summary>
        /// Constructor with AllUsers param
        /// </summary>
        /// <param name="AllUsers">opens the all uers window</param>
        public AllUsersViewModel(AllUsers usersOpen)
        {
            allUsers = usersOpen;
            AllInfoManagerList = service.GetAllManagersInfo().ToList();
            AllInfoEmployeeList = service.GetAllEmployeesInfo().ToList();
            ManagerList = service.GetAllManagers().ToList();
            EmployeeList = service.GetAllEmployees().ToList();
            UserList = service.GetAllUsers().ToList();
        }
        #endregion

        #region Property
        /// <summary>
        /// List of users
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

        /// <summary>
        /// List of managers
        /// </summary>
        private List<tblManager> managerList;
        public List<tblManager> ManagerList
        {
            get
            {
                return managerList;
            }
            set
            {
                managerList = value;
                OnPropertyChanged("ManagerList");
            }
        }

        /// <summary>
        /// List of employee
        /// </summary>
        private List<tblEmployee> employeeList;
        public List<tblEmployee> EmployeeList
        {
            get
            {
                return employeeList;
            }
            set
            {
                employeeList = value;
                OnPropertyChanged("EmployeeList");
            }
        }

        /// <summary>
        /// List of managers info view
        /// </summary>
        private List<vwManager> allInfoManagerList;
        public List<vwManager> AllInfoManagerList
        {
            get
            {
                return allInfoManagerList;
            }
            set
            {
                allInfoManagerList = value;
                OnPropertyChanged("AllInfoManagerList");
            }
        }

        /// <summary>
        /// List of employee info view
        /// </summary>
        private List<vwEmployee> allInfoEmployeeList;
        public List<vwEmployee> AllInfoEmployeeList
        {
            get
            {
                return allInfoEmployeeList;
            }
            set
            {
                allInfoEmployeeList = value;
                OnPropertyChanged("AllInfoEmployeeList");
            }
        }

        /// <summary>
        /// Specific Manager
        /// </summary>
        private vwManager manager;
        public vwManager Manager
        {
            get
            {
                return manager;
            }
            set
            {
                manager = value;
                OnPropertyChanged("Manager");
            }
        }

        /// <summary>
        /// Specific Employee
        /// </summary>
        private vwEmployee employee;
        public vwEmployee Employee
        {
            get
            {
                return employee;
            }
            set
            {
                employee = value;
                OnPropertyChanged("Employee");
            }
        }
        #endregion

        #region Commands
        /// <summary>
        /// Command that tries to delete the user
        /// </summary>
        private ICommand deleteUser;
        public ICommand DeleteUser
        {
            get
            {
                if (deleteUser == null)
                {
                    deleteUser = new RelayCommand(param => DeleteUserExecute(), param => CanDeleteUserExecute());
                }
                return deleteUser;
            }
        }

        /// <summary>
        /// Executes the delete command
        /// </summary>
        public void DeleteUserExecute()
        {
            // Checks if the user really wants to delete the user
            var result = MessageBox.Show("Are you sure you want to delete the user?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    if (Employee != null)
                    {
                        int userID = Employee.UserID;
                        service.DeleteUserEmployee(userID);
                        EmployeeList = service.GetAllEmployees().ToList();
                        AllInfoEmployeeList = service.GetAllEmployeesInfo().ToList();
                        UserList = service.GetAllUsers().ToList();

                    }
                    if (Manager != null)
                    {
                        int userID = Manager.UserID;
                        service.DeleteUserManager(userID);
                        ManagerList = service.GetAllManagers().ToList();
                        AllInfoManagerList = service.GetAllManagersInfo().ToList();
                        UserList = service.GetAllUsers().ToList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Checks if the user can be deleted
        /// </summary>
        /// <returns>true if possible</returns>
        public bool CanDeleteUserExecute()
        {
            if (UserList == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Command that tries to open the edit employee window
        /// </summary>
        private ICommand editUser;
        public ICommand EditUser
        {
            get
            {
                if (editUser == null)
                {
                    editUser = new RelayCommand(param => EditUserExecute(), param => CanEditUserExecute());
                }
                return editUser;
            }
        }

        /// <summary>
        /// Executes the edit command
        /// </summary>
        public void EditUserExecute()
        {
            try
            {
                if (Employee != null)
                {
                    AddEmployee addEmployee = new AddEmployee(Employee);
                    addEmployee.ShowDialog();

                    if ((addEmployee.DataContext as AddUserViewModel).IsUpdateEmployee == true)
                    {
                        EmployeeList = service.GetAllEmployees().ToList();
                        AllInfoEmployeeList = service.GetAllEmployeesInfo().ToList();
                        UserList = service.GetAllUsers().ToList();
                    }
                }
                if (Manager != null)
                {
                    AddManager addManager = new AddManager(Manager);
                    addManager.ShowDialog();

                    if ((addManager.DataContext as AddUserViewModel).IsUpdateManager == true)
                    {
                        ManagerList = service.GetAllManagers().ToList();
                        AllInfoManagerList = service.GetAllManagersInfo().ToList();
                        UserList = service.GetAllUsers().ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Checks if the report can be edited
        /// </summary>
        /// <returns>true if possible</returns>
        public bool CanEditUserExecute()
        {
            if (EmployeeList == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Command that tries to add a new employee
        /// </summary>
        private ICommand addNewEmployee;
        public ICommand AddNewEmployee
        {
            get
            {
                if (addNewEmployee == null)
                {
                    addNewEmployee = new RelayCommand(param => AddNewEmpoloyeeExecute(), param => CanAddNewEmployeeExecute());
                }
                return addNewEmployee;
            }
        }

        /// <summary>
        /// Executes the add Employee command
        /// </summary>
        private void AddNewEmpoloyeeExecute()
        {
            try
            {
                AddEmployee addEmployee = new AddEmployee();
                addEmployee.ShowDialog();
                if ((addEmployee.DataContext as AddUserViewModel).IsUpdateEmployee == true)
                {
                    EmployeeList = service.GetAllEmployees().ToList();
                    AllInfoEmployeeList = service.GetAllEmployeesInfo().ToList();
                    UserList = service.GetAllUsers().ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Checks if its possible to add the new employee
        /// </summary>
        /// <returns>true</returns>
        private bool CanAddNewEmployeeExecute()
        {
            return true;
        }

        /// <summary>
        /// Command that tries to add a new manager
        /// </summary>
        private ICommand addNewManager;
        public ICommand AddNewManager
        {
            get
            {
                if (addNewManager == null)
                {
                    addNewManager = new RelayCommand(param => AddNewManagerExecute(), param => CanAddNewManagerExecute());
                }
                return addNewManager;
            }
        }

        /// <summary>
        /// Executes the add Manager command
        /// </summary>
        private void AddNewManagerExecute()
        {
            try
            {
                AddManager addManager= new AddManager();
                addManager.ShowDialog();
                if ((addManager.DataContext as AddUserViewModel).IsUpdateManager == true)
                {
                    ManagerList = service.GetAllManagers().ToList();
                    AllInfoManagerList = service.GetAllManagersInfo().ToList();
                    UserList = service.GetAllUsers().ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Checks if its possible to add the new manager
        /// </summary>
        /// <returns>true</returns>
        private bool CanAddNewManagerExecute()
        {
            return true;
        }

        /// <summary>
        /// Command that logs off the user
        /// </summary>
        private ICommand logoff;
        public ICommand Logoff
        {
            get
            {
                if (logoff == null)
                {
                    logoff = new RelayCommand(param => LogoffExecute(), param => CanLogoffExecute());
                }
                return logoff;
            }
        }

        /// <summary>
        /// Executes the logoff command
        /// </summary>
        private void LogoffExecute()
        {
            try
            {
                Login login = new Login();
                allUsers.Close();
                login.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Checks if its possible to logoff
        /// </summary>
        /// <returns>true</returns>
        private bool CanLogoffExecute()
        {
            return true;
        }      
        #endregion
    }
}
