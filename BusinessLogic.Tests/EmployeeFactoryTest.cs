using System;
using Xunit;

namespace BusinessLogic.Tests
{
    public class EmployeeFactoryTest
    {
        [Theory]
        [InlineData(EmployeeType.Regular, 25000, 0, 22000)]
        public void Create_Regular(EmployeeType employeeType, decimal salary, decimal dayMultiplier, decimal expectedSalary)
        {
            var factory = new EmployeeFactory(
                "test",DateTime.MaxValue,"test", salary);

            var employee = factory.CreateEmployee(employeeType);

            var result = employee.ComputeSalary(dayMultiplier);
            
            Assert.Equal(expectedSalary, result);
        }

        [Theory]
        [InlineData(EmployeeType.Contractual, 500, 10, 5000)]
        public void Create_Contractual(EmployeeType employeeType, decimal salary, decimal dayMultiplier, decimal expectedSalary)
        {
            var factory = new EmployeeFactory(
                "test", DateTime.MaxValue, "test", salary);

            var employee = factory.CreateEmployee(employeeType);

            var result = employee.ComputeSalary(dayMultiplier);

            Assert.Equal(expectedSalary, result);
        }
    }
}
