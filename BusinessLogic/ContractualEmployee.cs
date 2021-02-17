using System;

namespace BusinessLogic
{
    public class ContractualEmployee : IEmployee
    {
        public ContractualEmployee(string name, DateTime birthDate, string tin, decimal basicSalary)
        {
            Name = name;
            BasicSalary = basicSalary;
            BirthDate = birthDate;
            TIN = tin;
        }

        public string Name { get; }

        public DateTime BirthDate { get; }

        public string TIN { get; }

        public decimal BasicSalary { get; }

        public decimal ComputeSalary(decimal dayMultiplier)
        {
            return Math.Round(BasicSalary * dayMultiplier, 2);
        }
    }
}
