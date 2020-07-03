using ETMS.Service.DataAccessLayer.Models;
using ETMS.Service.DomainEntity.Employee;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ETMS.Service.BuisinessLayer
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Users>> GetAllEmployees();

        Users GetEmployeeByName(string employeeName);

        Users GetEmployeeById(int empId);

        int CreateEmployee(Employee employee);

        int UpdateEmployeeInfo(Users employee);

        int DeleteEmployee(int employeeID);
        Users ValidateEmployee(string userName, string password);
        int ResetPassword(string userName, string pwd);
    }
}
