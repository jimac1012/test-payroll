using System;

namespace BusinessLogic
{
    public class ContractualEmployee : IEmployee
    {
        public ContractualEmployee(string name, DateTime birthDate, string tin, decimal basicSalary)
        {
            ID = Guid.NewGuid().ToString("N");
            Name = name;
            BasicSalary = basicSalary;
            BirthDate = birthDate;
            TIN = tin;
            EmployeeType = EmployeeType.Contractual;
        }

        public string ID { get; }

        public string Name { get; }

        public DateTime BirthDate { get; }

        public string TIN { get; }

        public decimal BasicSalary { get; }

        public EmployeeType EmployeeType { get; }

        public decimal ComputeSalary(decimal dayMultiplier)
        {
            return Math.Round(BasicSalary * dayMultiplier, 2);
        }
    }
}
