using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using System.IO;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace DAL.Tests
{
    public class BaseRepositoryUnitTests
    {
        [Fact]
        public void Create_InputDepartmentInstance_CalledAddMethodOfDBSetWithDepartmentInstance()
        {
            DbContextOptions opt = new DbContextOptionsBuilder<DepartmentDbContext>().Options;

            // Arrange DbContextOptions opt = new DbContextOptionsBuilder<OSBBContext>() .Options;
            var mockContext = new Mock<DepartmentDbContext>(opt);
            var mockDbSet = new Mock<DbSet<Department>>();

            mockContext
            .Setup(context =>
            context.Set<Department>())
            .Returns(mockDbSet.Object);

            var repository = new TestDepartmentRepository(mockContext.Object);

            Department expectedEmployee = new Mock<Department>().Object;

            //Act
            repository.Create(expectedEmployee);

            // Assert
            mockDbSet.Verify( dbSet => dbSet.Add(expectedEmployee), Times. Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<DepartmentDbContext>().Options;

            var mockContext = new Mock<DepartmentDbContext>(opt);
            var mockDbSet = new Mock<DbSet<Department>>();

            mockContext
                .Setup(context => context.Set<Department>()).Returns(mockDbSet.Object);

            Department expectedStreet = new() { DepartmentID = 1 };

            mockDbSet.Setup(mock => mock.Find(expectedStreet.DepartmentID)).Returns(expectedStreet);

            var repository = new TestDepartmentRepository(mockContext.Object);

            //Act
            var actualStreet = repository.Get(expectedStreet.DepartmentID);

            // Assert
            mockDbSet.Verify(dbSet => dbSet.Find(expectedStreet.DepartmentID
            ), Times.Once()); Assert.Equal(expectedStreet, actualStreet);
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<DepartmentDbContext>().Options;

            var mockContext = new Mock<DepartmentDbContext>(opt);
            var mockDbSet = new Mock<DbSet<Department>>();

            mockContext
                .Setup(context => context.Set<Department>())
                .Returns(mockDbSet.Object);

            var repository = new TestDepartmentRepository(mockContext.Object);

            Department expectedEmployee = new() { DepartmentID = 1 };

            // Setup Find method to return expectedEmployee
            mockDbSet.Setup(mock => mock.Find(expectedEmployee.DepartmentID))
                .Returns(expectedEmployee);

            //Act
            repository.Delete(expectedEmployee.DepartmentID);

            // Assert
            // Verify that Find method is called with the correct argument
            mockDbSet.Verify(dbSet => dbSet.Find(expectedEmployee.DepartmentID), Times.Once());

            // Verify that Remove method is called with the correct argument (expectedEmployee)
            mockDbSet.Verify(dbSet => dbSet.Remove(It.Is<Department>(e => e == expectedEmployee)), Times.Once());
        }
    }
}
