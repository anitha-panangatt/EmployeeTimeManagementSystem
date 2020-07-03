using ETMS.Service.BuisinessLayer.Interfaces;
using ETMS.Service.DataAccessLayer.Models;
using ETMS.Service.DataAccessLayer.Repository;
using ETMS.Service.DataAccessLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ETMS.Service.BuisinessLayer
{
    public class TimesheetService:ITimesheetService
    {
        ITimesheetRepository _timesheetRepository;
        public TimesheetService(ITimesheetRepository timesheetRepository)
        {
            _timesheetRepository = timesheetRepository;
        }
        public int CreateTimeEntry(TimeEntry timeEntry)
        {
            _timesheetRepository.CreateTimeEntry(timeEntry);
            return 1;
        }

        public async Task<IEnumerable<TimeEntry>> GetTimeEntries()
        {
            return _timesheetRepository.GetAllTimeEntry();
        }
    }
}
