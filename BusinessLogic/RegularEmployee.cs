using System;
// ReSharper disable InconsistentNaming

namespace BusinessLogic
{
    public class RegularEmployee : IEmployee
    {
        public RegularEmployee(string name, DateTime birthDate, string tin, decimal basicSalary)
        {
            ID = Guid.NewGuid().ToString("N");
            Name = name;
            BasicSalary = basicSalary;
            BirthDate = birthDate;
            TIN = tin;
            EmployeeType = EmployeeType.Regular;
        }

        public string ID { get; }

        public string Name { get; }

        public DateTime BirthDate { get; }

        public string TIN { get; }

        public decimal BasicSalary { get; }

        public EmployeeType EmployeeType { get; }

        public decimal ComputeSalary(decimal dayMultiplier)
        {
            var tax = BasicSalary * (decimal)0.12;
            var absence = dayMultiplier * (BasicSalary / 22);

            return Math.Round(BasicSalary - tax - absence, 2);
        }
    }
}
