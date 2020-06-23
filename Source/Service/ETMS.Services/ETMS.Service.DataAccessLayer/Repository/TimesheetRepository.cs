using ETMS.Service.DataAccessLayer.Models;
using ETMS.Service.DataAccessLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETMS.Service.DataAccessLayer.Repository
{
    public class TimesheetRepository : ITimesheetRepository
    {
        public readonly EMTSDbContext _context;
        public TimesheetRepository(EMTSDbContext context)
        {
            _context = context;
        }

        public int CreateTimeEntry(TimeEntry timeEntry)
        {
            _context.Add(timeEntry);
            return _context.SaveChanges();
        }

        public IEnumerable<TimeEntry> GetAllTimeEntry()
        {
            return _context.TimeEntry.OrderBy(e => e.ProjectDate).ToList();
        }

        public TimeEntry GetTimeEntry(int employeeId)
        {
            throw new NotImplementedException();
        }

        public int UpdateTimeEntry(TimeEntry timeEntry)
        {
            throw new NotImplementedException();
        }
    }
}
