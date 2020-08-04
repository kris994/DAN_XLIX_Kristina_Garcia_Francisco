using DAN_XLIX_Kristina_Garcia_Francisco.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace DAN_XLIX_Kristina_Garcia_Francisco
{
    /// <summary>
    /// Class that includes all CRUD functions of the application
    /// </summary>
    class Service
    {
        /// <summary>
        /// Gets all information about users
        /// </summary>
        /// <returns>a list of found users</returns>
        public List<tblUser> GetAllUsers()
        {
            try
            {
                using (HotelDBEntities context = new HotelDBEntities())
                {
                    List<tblUser> list = new List<tblUser>();
                    list = (from x in context.tblUsers select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Gets all managers
        /// </summary>
        /// <returns>a list of found managers</returns>
        public List<tblManager> GetAllManagers()
        {
            try
            {
                using (HotelDBEntities context = new HotelDBEntities())
                {
                    List<tblManager> list = new List<tblManager>();
                    list = (from x in context.tblManagers select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Gets all employees
        /// </summary>
        /// <returns>a list of found employees</returns>
        public List<tblEmployee> GetAllEmployees()
        {
            try
            {
                using (HotelDBEntities context = new HotelDBEntities())
                {
                    List<tblEmployee> list = new List<tblEmployee>();
                    list = (from x in context.tblEmployees select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Gets all information about managers
        /// </summary>
        /// <returns>a list of found managers</returns>
        public List<vwManager> GetAllManagersInfo()
        {
            try
            {
                using (HotelDBEntities context = new HotelDBEntities())
                {
                    List<vwManager> list = new List<vwManager>();
                    list = (from x in context.vwManagers select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Gets all information about employees
        /// </summary>
        /// <returns>a list of found employees</returns>
        public List<vwEmployee> GetAllEmployeesInfo()
        {
            try
            {
                using (HotelDBEntities context = new HotelDBEntities())
                {
                    List<vwEmployee> list = new List<vwEmployee>();
                    list = (from x in context.vwEmployees select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Search if user with that ID exists in the user table
        /// </summary>
        /// <param name="userID">Takes the user id that we want to search for</param>
        /// <returns>True if the user exists</returns>
        public bool IsUserID(int userID)
        {
            try
            {
                using (HotelDBEntities context = new HotelDBEntities())
                {
                    int result = (from x in context.tblUsers where x.UserID == userID select x.UserID).FirstOrDefault();

                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception " + ex.Message.ToString());
                return false;
            }
        }

        /// <summary>
        /// Creates or edits an employee
        /// </summary>
        /// <param name="employee">the employee that is being added</param>
        /// <returns>a new or edited employee</returns>
        public vwEmployee AddEmployee(vwEmployee employee)
        {
            try
            {
                using (HotelDBEntities context = new HotelDBEntities())
                {
                    if (employee.UserID == 0)
                    {
                        tblUser newUser = new tblUser
                        {
                            FirstName = employee.FirstName,
                            LastName = employee.LastName,
                            DateOfBirth = employee.DateOfBirth,
                            Email = employee.Email,
                            Username = employee.Username,
                            UserPassword = employee.UserPassword
                        };

                        context.tblUsers.Add(newUser);
                        context.SaveChanges();
                        employee.UserID = newUser.UserID;

                        tblEmployee newEmployee = new tblEmployee
                        {
                            FloorNumber = employee.FloorNumber,
                            Gender = employee.Gender,
                            Citizenship = employee.Citizenship,
                            Responsibility = employee.Responsibility,
                            Salary = employee.Salary,
                            UserID = employee.UserID
                        };

                        context.tblEmployees.Add(newEmployee);
                        context.SaveChanges();
                        employee.EmployeeID = newEmployee.EmployeeID;

                        return employee;
                    }
                    else
                    {
                        tblUser userToEdit = (from ss in context.tblUsers where ss.UserID == employee.UserID select ss).First();

                        userToEdit.FirstName = employee.FirstName;
                        userToEdit.LastName = employee.LastName;
                        userToEdit.DateOfBirth = employee.DateOfBirth;
                        userToEdit.Email = employee.Email;
                        userToEdit.Username = employee.Username;
                        userToEdit.UserPassword = employee.UserPassword;

                        userToEdit.UserID = employee.UserID;

                        tblUser userEdit = (from ss in context.tblUsers
                                            where ss.UserID == employee.UserID
                                            select ss).First();
                        context.SaveChanges();

                        tblEmployee employeeToEdit = (from ss in context.tblEmployees where ss.UserID == employee.UserID select ss).First();

                        employeeToEdit.FloorNumber = employee.FloorNumber;
                        employeeToEdit.Gender = employee.Gender;
                        employeeToEdit.Citizenship = employee.Citizenship;
                        employeeToEdit.Responsibility = employee.Responsibility;
                        employeeToEdit.Salary = employee.Salary;

                        employeeToEdit.EmployeeID = employee.EmployeeID;

                        tblEmployee employeeEdit = (from ss in context.tblEmployees
                                                  where ss.EmployeeID == employee.EmployeeID
                                                  select ss).First();
                        context.SaveChanges();
                        return employee;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Creates or edits a manager
        /// </summary>
        /// <param name="manager">the manager that is esing added</param>
        /// <returns>a new or edited manager</returns>
        public vwManager AddManager(vwManager manager)
        {
            try
            {
                using (HotelDBEntities context = new HotelDBEntities())
                {
                    if (manager.UserID == 0)
                    {
                        tblUser newUser = new tblUser
                        {
                            FirstName = manager.FirstName,
                            LastName = manager.LastName,
                            DateOfBirth = manager.DateOfBirth,
                            Email = manager.Email,
                            Username = manager.Username,
                            UserPassword = manager.UserPassword
                        };

                        context.tblUsers.Add(newUser);
                        context.SaveChanges();
                        manager.UserID = newUser.UserID;

                        tblManager newManager = new tblManager
                        {
                            FloorNumber = manager.FloorNumber,
                            YearsOfExperience = manager.YearsOfExperience,
                            EducationDegree = manager.EducationDegree,
                            UserID = manager.UserID
                        };

                        context.tblManagers.Add(newManager);
                        context.SaveChanges();
                        manager.ManagerID = newManager.ManagerID;

                        return manager;
                    }
                    else
                    {
                        tblUser userToEdit = (from ss in context.tblUsers where ss.UserID == manager.UserID select ss).First();

                        userToEdit.FirstName = manager.FirstName;
                        userToEdit.LastName = manager.LastName;
                        userToEdit.DateOfBirth = manager.DateOfBirth;
                        userToEdit.Email = manager.Email;
                        userToEdit.Username = manager.Username;
                        userToEdit.UserPassword = manager.UserPassword;

                        userToEdit.UserID = manager.UserID;

                        tblUser userEdit = (from ss in context.tblUsers
                                               where ss.UserID == manager.UserID
                                               select ss).First();
                        context.SaveChanges();

                        tblManager managerToEdit = (from ss in context.tblManagers where ss.UserID == manager.UserID select ss).First();

                        managerToEdit.FloorNumber = manager.FloorNumber;
                        managerToEdit.YearsOfExperience = manager.YearsOfExperience;
                        managerToEdit.EducationDegree = manager.EducationDegree;

                        managerToEdit.ManagerID = manager.ManagerID;

                        tblManager managerEdit = (from ss in context.tblManagers
                                                  where ss.ManagerID == manager.ManagerID
                                                  select ss).First();
                        context.SaveChanges();
                        return manager;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Deletes manager user depending if the uderID already exists
        /// </summary>
        /// <param name="userID">the user that is being deleted</param>
        /// <returns>list of users</returns>
        public void DeleteUserManager(int userID)
        {
            try
            {
                using (HotelDBEntities context = new HotelDBEntities())
                {
                    bool isUser = IsUserID(userID);

                    // Deletes the manager
                    for (int i = 0; i < GetAllManagers().Count; i++)
                    {
                        if (GetAllManagers()[i].UserID == userID)
                        {
                            tblManager man = (from r in context.tblManagers where r.UserID == userID select r).First();
                            context.tblManagers.Remove(man);
                            context.SaveChanges();
                        }
                    }
                    if (isUser == true)
                    {
                        tblUser userToDelete = (from r in context.tblUsers where r.UserID == userID select r).First();

                        context.tblUsers.Remove(userToDelete);
                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Cannot delete the user");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        /// <summary>
        /// Deletes employee user depending if the uderID already exists
        /// </summary>
        /// <param name="userID">the user that is being deleted</param>
        /// <returns>list of users</returns>
        public void DeleteUserEmployee(int userID)
        {
            try
            {
                using (HotelDBEntities context = new HotelDBEntities())
                {
                    bool isUser = IsUserID(userID);
                    // Deletes the employee
                    for (int i = 0; i < GetAllEmployees().Count; i++)
                    {
                        if (GetAllEmployees()[i].UserID == userID)
                        {
                            tblEmployee emp = (from r in context.tblEmployees where r.UserID == userID select r).First();
                            context.tblEmployees.Remove(emp);
                            context.SaveChanges();
                        }
                    }
                    if (isUser == true)
                    {
                        tblUser userToDelete = (from r in context.tblUsers where r.UserID == userID select r).First();

                        context.tblUsers.Remove(userToDelete);
                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Cannot delete the user");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }
    }
}
