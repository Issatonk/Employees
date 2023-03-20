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
    public class DepartmentServiceTests
    {
        private readonly Mock<IDepartmentRepository> _departmentRepositoryMock;
        private readonly DepartmentService _service;

        public DepartmentServiceTests()
        {
            _departmentRepositoryMock = new Mock<IDepartmentRepository>();
            

            _service = new DepartmentService(_departmentRepositoryMock.Object);
        }

#region Create
        [Fact]
        public async Task Create_DepartmentIsValid_ShouldCreateNewDepartment()
        {
            //arrange
            var fixture = new Fixture();
            
            var department = fixture.Create<Department>();

            
            //act
            await _service.Create(department);
            //assert
            _departmentRepositoryMock.Verify(x=>x.Add(department), Times.Once());


        }
        [Fact]
        public void Create_DepartmentIsNull_ShouldThrowArgumentNullException()
        {
            //arrange
            Department department = null;
            //act
             _service.Create(department);
            //assert
             _departmentRepositoryMock.Verify(x => x.Add(department), Times.Never);
            //var test =  await Assert.ThrowsAsync<ArgumentNullException>(() => _service.Create(department));
        }
        [Theory]
        [InlineData("", 1)]
        [InlineData("test", 0)]
        [InlineData("test", -1)]
        public void Create_DepartmentIsInvalid_ShouldThrowArgumentException(string name, int floor)
        {
            //arrange
            var department = new Department { Name = name, Floor = floor };
            //act
             _service.Create(department);
            //assert
            _departmentRepositoryMock.Verify(x => x.Add(department), Times.Never);
             Assert.ThrowsAsync<ArgumentException>(() => _service.Create(department));
        }
        #endregion
        [Fact]
        public void Update_DepartmentIsValid_ShouldUpdateDepartment()
        {
            //arrange
            var fixture = new Fixture();
            var department = fixture.Create<Department>();
            //act
            var result = _service.Update(department);
            //assert
            _departmentRepositoryMock.Verify(x=>x.Update(department), Times.Once());
            Assert.Equal(result.Result, department.Id);
        }


        [Fact]
        public void ReadAll_ShouldReturnAllDepartment()
        {
            //arrange
           
            var fixture = new Fixture();
            var testData = new List<Department>
                {
                    new Department { Id = 1, Floor = 8, Name = "dep1" } ,
                    fixture.Create<Department>(),
                    fixture.Create<Department>(),
                    fixture.Create<Department>(),
                    fixture.Create<Department>()
                };
           _departmentRepositoryMock.Setup(x => x.GetAll()).Returns(Task.FromResult(testData as IEnumerable<Department>));
            //act
            var result = _service.ReadAll();
            //assert
            _departmentRepositoryMock.Verify(x => x.GetAll(), Times.Once());
        }
    }
}
