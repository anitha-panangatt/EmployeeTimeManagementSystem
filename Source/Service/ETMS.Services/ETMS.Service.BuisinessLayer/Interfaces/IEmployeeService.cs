using ETMS.Service.DataAccessLayer.Models;
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

        int CreateEmployee(Users employee);

        int UpdateEmployeeInfo(Users employee);

        int DeleteEmployee(int employeeID);
       
    }
}
