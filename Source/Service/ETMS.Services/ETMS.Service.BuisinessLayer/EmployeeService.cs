using ETMS.Service.DataAccessLayer.Models;
using ETMS.Service.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ETMS.Service.BuisinessLayer
{
    public class EmployeeService : IEmployeeService
    {
        IUserRepository _userRepository;
        public EmployeeService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public int CreateEmployee(Users employee)
        {
            employee.PasswordText = CreateDefaultPassword(employee.UserName);
            return _userRepository.CreateUser(employee);
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

        private string CreateDefaultPassword(string empName)
        {
            return empName.Substring(0, Math.Min(empName.Length, 4));
        }
    }
}
