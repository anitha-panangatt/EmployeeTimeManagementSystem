using ETMS.Service.DataAccessLayer.Models;
using ETMS.Service.DataAccessLayer.Repository;
using ETMS.Service.DomainEntity.Employee;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static ETMS.Service.BuisinessLayer.Common.Constants;

namespace ETMS.Service.BuisinessLayer
{
    public class EmployeeService : IEmployeeService
    {
        IUserRepository _userRepository;
        public EmployeeService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public int CreateEmployee(Employee employee)
        {
            employee.Employeename = employee.FirstName + " " + employee.LastName;

            Users user = new Users();
            user.PasswordText = CreateDefaultPassword(employee.Employeename);
            user.UserName = employee.Employeename;
            user.Role = UserRole.Employee.ToString();
            user.IsActive = true;

            var userId = _userRepository.CreateUser(user);

            if (userId > 0)
            {
                EmployeeInfo empInfo = new EmployeeInfo();
                empInfo.UserId = userId;
                empInfo.EmployeeName = employee.Employeename;
                empInfo.MobileNumber = employee.MobileNumber;
                empInfo.Email = employee.Email;
                empInfo.CreatedDateTime = DateTime.Now;
                empInfo.FirstName = employee.FirstName;
                empInfo.LastName = employee.LastName;
                empInfo.State = employee.State;
                empInfo.City = employee.City;
                return _userRepository.CreateEmployee(empInfo);
            }

            return userId;
        }

        public int DeleteEmployee(int employeeID)
        {
            var employee = _userRepository.GetEmployee(employeeID);
            if (employee != null)
            {
                employee.IsActive = false;
                _userRepository.UpdateEmployee(employee);
                return 1;
            }
            return 0;
        }

        public async Task<IEnumerable<Users>> GetAllEmployees()
        {
           return  _userRepository.GetAllEmployee();
        }

        public Users GetEmployeeByName(string employeeName)
        {
            return _userRepository.GetEmployee(employeeName);
        }

        public Users GetEmployeeById(int empId)
        {
            return _userRepository.GetEmployee(empId);
        }

        public int UpdateEmployeeInfo(Users employee)
        {
            return _userRepository.UpdateEmployee(employee);
        }

        public Users ValidateEmployee(string userName, string password)
        {
            return _userRepository.GetUser(userName, password);
        }

        private string CreateDefaultPassword(string empName)
        {
            return empName.Substring(0, Math.Min(empName.Length, 4));
        }

        public int ResetPassword(string userName, string pwd)
        {
            var user = _userRepository.GetEmployee(userName);
            if(user!=null && user.IsActive.Value)
            {
                user.PasswordText = pwd;
               return _userRepository.UpdateEmployee(user);
            }
            return 0;
        }
    }
}
