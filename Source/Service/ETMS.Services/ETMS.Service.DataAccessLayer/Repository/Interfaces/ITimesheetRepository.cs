using ETMS.Service.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETMS.Service.DataAccessLayer.Repository.Interfaces
{
    public interface ITimesheetRepository
    {
        IEnumerable<TimeEntry> GetAllTimeEntry();
        TimeEntry GetTimeEntry(int employeeId);       

        int CreateTimeEntry(TimeEntry timeEntry);

        int UpdateTimeEntry(TimeEntry timeEntry);
    }
}
