using System;
using Xunit;

namespace BusinessLogic.Tests.Models
{
    public class RegularEmployeeTest
    {
        [Fact]
        public void CreateEmployee()
        {
            var name = "John Doe";
            var birthDate = new DateTime(2000, 1, 1);
            var tin = "123-456-789-000";

            var employee = new RegularEmployee
            {
                Name = name,
                BirthDate = birthDate,
                TIN = tin
            };

            Assert.Equal(name,  employee.Name);
            Assert.Equal(birthDate, employee.BirthDate);
            Assert.Equal(tin, employee.TIN);
        }
    }
}
