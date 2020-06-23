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
            return _context.Users.OrderBy(e => e.UserName).ToList();

        }

        public Users GetEmployee(int employeeId)
        {
            return _context.Users.FirstOrDefault(e => e.UserId == employeeId);
        }

      

        public int CreateUser(Users user)
        {
           _context.Add(user);
           return _context.SaveChanges();
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
    }
}
