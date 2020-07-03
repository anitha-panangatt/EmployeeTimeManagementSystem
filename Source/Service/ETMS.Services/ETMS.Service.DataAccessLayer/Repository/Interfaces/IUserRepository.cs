using ETMS.Service.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETMS.Service.DataAccessLayer.Repository
{
    public interface IUserRepository
    {
        IEnumerable<Users> GetAllEmployee();
        Users GetEmployee(int employeeId);

        Users GetEmployee(string employeeName);

        int CreateUser(Users user);

        int UpdateEmployee(Users user);

        int CreateEmployee(EmployeeInfo empInfo);
        Users GetUser(string userName, string password);
    }
}
