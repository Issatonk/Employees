using AutoFixture;
using Employees.Core;
using Employees.Core.Entity;
using Employees.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Employees.BusinessLogic.Tests
{
    public class EmployeeServiceTest
    {
        private readonly Mock<IEmployeeRepository> _employeeRepositoryMock;

        private readonly EmployeeService _service;

        public EmployeeServiceTest()
        {
            _employeeRepositoryMock = new Mock<IEmployeeRepository>();
            _service = new EmployeeService(_employeeRepositoryMock.Object);
        }
        [Fact]
        public void Create_EmployeeIsValid_ShouldCreateNewEmployee()
        {
            //arrange
            Fixture fixture = new Fixture();
            var employee = fixture.Create<Employee>();
            //act
            var result = _service.Create(employee);
            //assert
            _employeeRepositoryMock.Verify(x=>x.Add(employee), Times.Once);
        }
        [Fact]
        public void Create_EmployeeIsNull_ShouldThrowArgumentNullException()
        {
            //arrange
            Employee employee = null;
            //act
            var result = _service.Create(employee);
            //assert
            _employeeRepositoryMock.Verify(x => x.Add(employee), Times.Never);
            Assert.ThrowsAsync<ArgumentNullException>(()=>_service.Create(employee));
        }
        [Theory]
        [InlineData("", "")]
        [InlineData("test", "")]
        [InlineData("", "test")]

        public void Create_EmployeeIsInvalid_ShouldThrowArgumentException
            (string name, string surname)
        {
            //arrange
            Employee employee = new Employee 
            { 
                Name = name, 
                Surname = surname
            };
            //act
            var result = _service.Create(employee);
            //assert
            _employeeRepositoryMock.Verify(x => x.Add(employee), Times.Never);
            Assert.ThrowsAsync<ArgumentException>(() => _service.Create(employee));
        }
    }
}
