using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETMS.Service.BuisinessLayer;
using ETMS.Service.DataAccessLayer.Models;
using ETMS.Service.DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ETMS.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        

        [HttpGet]
        [Route("GetEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employeeList = await _employeeService.GetAllEmployees();
                if (employeeList == null)
                {
                    return NotFound();
                }

                return Ok(employeeList);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("GetEmployeeByName")]
        public async Task<IActionResult> GetEmployeeByName(string empName)
        {
            try
            {
                var employeeList = _employeeService.GetEmployeeByName(empName);
                if (employeeList == null)
                {
                    return NotFound();
                }

                return Ok(employeeList);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int empId)
        {
            try
            {
                var employeeList = _employeeService.GetEmployeeById(empId);
                if (employeeList == null)
                {
                    return NotFound();
                }

                return Ok(employeeList);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee([FromBody] Users emp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var empID = _employeeService.CreateEmployee(emp);
                    if (empID > 0)
                    {
                        return Ok(empID);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpPost]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] Users emp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var empID = _employeeService.UpdateEmployeeInfo(emp);
                    if (empID > 0)
                    {
                        return Ok(empID);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpGet]
        [Route("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int empId)
        {
            try
            {
                var status = _employeeService.DeleteEmployee(empId);
                if (status <=0 )
                {
                    return NotFound();
                }

                return Ok(status);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }





    }
}
