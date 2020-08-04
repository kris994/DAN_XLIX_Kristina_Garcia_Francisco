using DAN_XLIX_Kristina_Garcia_Francisco.Commands;
using DAN_XLIX_Kristina_Garcia_Francisco.Model;
using DAN_XLIX_Kristina_Garcia_Francisco.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace DAN_XLIX_Kristina_Garcia_Francisco.ViewModel
{
    class AddUserViewModel : BaseViewModel
    {
        AddEmployee addEmployee;
        AddManager addManager;
        Service service = new Service();

        #region Constructor
        /// <summary>
        /// Constructor with the add employee info window opening
        /// </summary>
        /// <param name="addEmployeeOpen">opends the add employee window</param>
        public AddUserViewModel(AddEmployee addEmployeeOpen)
        {
            employee = new vwEmployee();
            addEmployee = addEmployeeOpen;
            AllInfoEmployeeList = service.GetAllEmployeesInfo().ToList();
            EmployeeList = service.GetAllEmployees().ToList();
            UserList = service.GetAllUsers().ToList();
        }

        /// <summary>
        /// Constructor with edit employee window opening
        /// </summary>
        /// <param name="addEmployeeOpen">opens the edit employee window</param>
        /// <param name="employeeEdit">gets the employee info that is being edited</param>
        public AddUserViewModel(AddEmployee addEmployeeOpen, vwEmployee employeeEdit)
        {
            employee = employeeEdit;
            addEmployee = addEmployeeOpen;
            AllInfoEmployeeList = service.GetAllEmployeesInfo().ToList();
            EmployeeList = service.GetAllEmployees().ToList();
            UserList = service.GetAllUsers().ToList();
        }

        /// <summary>
        /// Constructor with the add manager info window opening
        /// </summary>
        /// <param name="addManagerOpen">opends the add manager window</param>
        public AddUserViewModel(AddManager addManagerOpen)
        {
            manager = new vwManager();
            addManager = addManagerOpen;
            AllInfoManagerList = service.GetAllManagersInfo().ToList();
            ManagerList = service.GetAllManagers().ToList();
            UserList = service.GetAllUsers().ToList();
        }


        /// <summary>
        /// Constructor with edit manager window opening
        /// </summary>
        /// <param name="addManagerOpen">opens the edit manager window</param>
        /// <param name="managerEdit">gets the manager info that is being edited</param>
        public AddUserViewModel(AddManager addManagerOpen, vwManager managerEdit)
        {
            manager = managerEdit;
            addManager = addManagerOpen;
            AllInfoManagerList = service.GetAllManagersInfo().ToList();
            ManagerList = service.GetAllManagers().ToList();
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

        /// <summary>
        /// Cheks if its possible to execute the add and edit employee commands
        /// </summary>
        private bool isUpdateEmployee;
        public bool IsUpdateEmployee
        {
            get
            {
                return isUpdateEmployee;
            }
            set
            {
                isUpdateEmployee = value;
            }
        }

        /// <summary>
        /// Cheks if its possible to execute the add and edit manager commands
        /// </summary>
        private bool isUpdateManager;
        public bool IsUpdateManager
        {
            get
            {
                return isUpdateManager;
            }
            set
            {
                isUpdateManager = value;
            }
        }
        #endregion

        #region Commands
        /// <summary>
        /// Command that tries to save the new manager
        /// </summary>
        private ICommand saveManager;
        public ICommand SaveManager
        {
            get
            {
                if (saveManager == null)
                {
                    saveManager = new RelayCommand(param => SaveManagerExecute(), param => this.CanSaveManagerExecute);
                }
                return saveManager;
            }
        }

        /// <summary>
        /// Tries the execute the save command
        /// </summary>
        private void SaveManagerExecute()
        {
            try
            {
                service.AddManager(Manager);
                IsUpdateManager = true;

                addManager.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        /// <summary>
        /// Checks if its possible to save the manager
        /// </summary>
        protected bool CanSaveManagerExecute
        {
            get
            {
                return Manager.IsValid;
            }
        }

        /// <summary>
        /// Command that tries to save the new employee
        /// </summary>
        private ICommand saveEmployee;
        public ICommand SaveEmployee
        {
            get
            {
                if (saveEmployee == null)
                {
                    saveEmployee = new RelayCommand(param => SaveEmployeeExecute(), param => this.CanSaveEmployeeExecute);
                }
                return saveEmployee;
            }
        }

        /// <summary>
        /// Tries the execute the save command
        /// </summary>
        private void SaveEmployeeExecute()
        {
            try
            {
                service.AddEmployee(Employee);
                IsUpdateEmployee = true;

                addEmployee.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        /// <summary>
        /// Checks if its possible to save the employee
        /// </summary>
        protected bool CanSaveEmployeeExecute
        {
            get
            {
                return Employee.IsValid;
            }
        }

        /// <summary>
        /// Command that closes the add worker or edit worker window
        /// </summary>
        private ICommand cancel;
        public ICommand Cancel
        {
            get
            {
                if (cancel == null)
                {
                    cancel = new RelayCommand(param => CancelExecute(), param => CanCancelExecute());
                }
                return cancel;
            }
        }

        /// <summary>
        /// Executes the close command
        /// </summary>
        private void CancelExecute()
        {
            try
            {
                if (Application.Current.Windows.OfType<AddEmployee>().FirstOrDefault() != null)
                {
                    addEmployee.Close();
                }
                else if (Application.Current.Windows.OfType<AddManager>().FirstOrDefault() != null)
                {
                    addManager.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Checks if its possible to execute the close command
        /// </summary>
        /// <returns>true</returns>
        private bool CanCancelExecute()
        {
            return true;
        }
        #endregion
    }
}
