using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using ETMS.Service.BuisinessLayer;
using ETMS.Service.DataAccessLayer.Models;
using ETMS.Service.DataAccessLayer.Repository;
using ETMS.Service.DomainEntity.Employee;
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
               // SendEmail();
                var employeeList = await _employeeService.GetAllEmployees();
                if (employeeList == null)
                {
                    return NotFound();
                }

                return Ok(employeeList);
            }
            catch (Exception ex)
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
        public async Task<IActionResult> CreateEmployee([FromBody] Employee emp)
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
        
        [HttpGet]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(string userName, string pwd)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var empID =  _employeeService.ResetPassword(userName, pwd);
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
        public void SendEmail()
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add("anithapp88@gmail.com");
                // mail.To.Add("Another Email ID where you wanna send same email");
                mail.From = new MailAddress("anithapp88@gmail.com");
                mail.Subject = "Email using Gmail";

                string Body = "Hi, this mail is to test sending mail" +
                              "using Gmail in ASP.NET";
                mail.Body = Body;

                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new System.Net.NetworkCredential
                     ("anithapp88@gmail.com", "test123456");
                //Or your Smtp Email ID and Password
                
                
                smtp.Timeout = 30000;

                smtp.Send(mail);

               


            }
            catch (Exception ex)
            {

            }
        }



    }
}
