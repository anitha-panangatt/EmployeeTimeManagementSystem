using ETMS.Service.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ETMS.Service.BuisinessLayer.Interfaces
{
    public interface ITimesheetService
    {
        int CreateTimeEntry(TimeEntry timeEntry);
        Task<IEnumerable<TimeEntry>> GetTimeEntries();
    }
}
