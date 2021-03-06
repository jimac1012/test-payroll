﻿using System;
using Xunit;
// ReSharper disable InconsistentNaming

namespace BusinessLogic.Tests.Models
{
    public class ContractualEmployeeTest
    {
        public static readonly object[][] CreateEmployee_CorrectData =
        {
            new object[]
            {
                "Joey Smith",
                new DateTime(2017,3,1),
                "123-456-789-000",
                500.00m
            }
        };

        [Theory, MemberData(nameof(CreateEmployee_CorrectData))]
        public void Employee_Create(string name, DateTime birthDate, string tin, decimal basicSalary)
        {
            IEmployee employee = new ContractualEmployee
            (
                name,
                birthDate,
                tin,
                basicSalary
            );

            Assert.Equal(name, employee.Name);
            Assert.Equal(birthDate, employee.BirthDate);
            Assert.Equal(tin, employee.TIN);
            Assert.Equal(basicSalary, employee.BasicSalary);
        }

        public static readonly object[][] Employee_ComputeSalary_CorrectData =
        {
            new object[]
            {
                550m,
                20m,
                11000.00m
            },
            new object[]
            {
                750m,
                12.8m,
                9600m
            }
        };

        [Theory, MemberData(nameof(Employee_ComputeSalary_CorrectData))]
        public void Employee_ComputeSalary(decimal basicSalary, decimal dayMultiplier, decimal expected)
        {
            IEmployee employee = new ContractualEmployee
            (
                "test",
                DateTime.MaxValue,
                "test",
                basicSalary
            );

            var result = employee.ComputeSalary(dayMultiplier);
            Assert.Equal(expected, result);
        }
    }
}
