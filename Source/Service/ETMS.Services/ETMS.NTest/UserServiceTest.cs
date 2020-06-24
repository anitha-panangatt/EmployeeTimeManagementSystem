using ETMS.Service.BuisinessLayer;
using ETMS.Services.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETMS.NTest
{
    public class UserServiceTest
    {
        EmployeeController controller;
        private Mock<IEmployeeService> employeeServiceMock;

        [SetUp]
        public void Setup()
        {
            employeeServiceMock = new Mock<IEmployeeService>();

        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
