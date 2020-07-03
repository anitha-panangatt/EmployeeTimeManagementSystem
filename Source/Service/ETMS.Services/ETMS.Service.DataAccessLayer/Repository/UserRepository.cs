using ETMS.Service.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ETMS.Service.DataAccessLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly EMTSDbContext _context;
        public UserRepository(EMTSDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Users> GetAllEmployee()
        {
            try
            {
                return _context.Users.OrderBy(e => e.UserName).ToList();
            }
            catch(Exception ex)
            {
                return null;
            }

        }

        public Users GetEmployee(int employeeId)
        {
            return _context.Users.FirstOrDefault(e => e.UserId == employeeId);
        }



        public int CreateUser(Users user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

            }
            return user.UserId;
        }

        public int CreateEmployee(EmployeeInfo empInfo)
        {
            try
            {
                _context.EmployeeInfo.Add(empInfo);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return empInfo.UserId;
        }

        public Users GetEmployee(string employeeName)
        {
            return _context.Users.FirstOrDefault(x => x.UserName == employeeName);
        }

        public int UpdateEmployee(Users user)
        {
            var userResponse = _context.Users.Update(user);
            return _context.SaveChanges();
        }

        public Users GetUser(string userName, string password)
        {
            return _context.Users.FirstOrDefault(x => x.UserName == userName && x.PasswordText == password);
        } 
    }
}
