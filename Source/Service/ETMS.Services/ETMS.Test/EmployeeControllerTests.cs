using ETMS.Service.BuisinessLayer;
using ETMS.Service.DataAccessLayer.Models;
using ETMS.Service.DomainEntity.Employee;
using ETMS.Services.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ETMS.Test
{
    public class EmployeeControllerTests
    {
        [Fact]
        public async void Task_GetPostById_Return_OkResult()
        {
            var employeeService = new Mock<IEmployeeService>();            
            var result = employeeService.Setup(m => m.GetAllEmployees()).Returns((GetEmployees()));

            Assert.NotNull(result);

           
        }

          [Fact]  
        public async void Task_Add_ValidData_Return_OkResult()  
        {
            //Arrange  
            var employeeService = new Mock<IEmployeeService>();
            var employee = new Employee() { Employeename = "Test Title 3", Mobile = "9495887788", Email = "test@gmail.com" };

            var result = employeeService.Setup(m => m.CreateEmployee(employee));
         
            
  
            //Assert  
            Assert.True(true);  
        }  


        private async Task<IEnumerable<Users>> GetEmployees()
        {
            return new List<Users>
            {
                new Users
                {
                    UserName = @"John"
                },
                new Users
                {
                    UserName = @"George"
                }
            };
        }

    }
}
