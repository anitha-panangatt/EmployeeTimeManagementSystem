using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETMS.Service.BuisinessLayer.Interfaces;
using ETMS.Service.DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace ETMS.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSheetController : ControllerBase
    {
        private readonly ITimesheetService _timesheetService;
        public TimeSheetController(ITimesheetService timesheetService)
        {
            _timesheetService = timesheetService;
        }

        [HttpPost]
        [Route("CreateTimeEntry")]
        public async Task<IActionResult> CreateTimeEntry([FromBody] TimeEntry timeEntry)
        {
            timeEntry.AllocationId = 2;
            timeEntry.IsApproved = false;
            if (ModelState.IsValid)
            {
                try
                {
                    var entryID = _timesheetService.CreateTimeEntry(timeEntry);
                    if (entryID > 0)
                    {
                        return Ok(entryID);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

       
        [HttpGet]
        [Route("GetTimeEntry")]
        public async Task<IActionResult> GetTimeEntry()
        {
            try
            {
                // SendEmail();
                var timeEntryList = await _timesheetService.GetTimeEntries();
                if (timeEntryList == null)
                {
                    return NotFound();
                }

                return Ok(timeEntryList);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }


    }
}
