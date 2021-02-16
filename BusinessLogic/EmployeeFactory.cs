using System;
// ReSharper disable RedundantCaseLabel

namespace BusinessLogic
{
    public class EmployeeFactory
    {
        private readonly string _name;
        private readonly DateTime _birthDate;
        private readonly string _tin;
        private readonly decimal _basicSalary;

        public EmployeeFactory(string name, DateTime birthDate, string tin, decimal basicSalary)
        {
            _name = name;
            _birthDate = birthDate;
            _tin = tin;
            _basicSalary = basicSalary;
        }

        public IEmployee CreateEmployee(EmployeeType employeeType)
        {
            switch (employeeType)
            {
                case EmployeeType.Regular:
                    return new RegularEmployee(_name, _birthDate, _tin, _basicSalary);
                case EmployeeType.Contractual:
                    return new ContractualEmployee(_name, _birthDate, _tin, _basicSalary);
                default:
                    throw new ArgumentOutOfRangeException(nameof(employeeType), employeeType, null);
            }
        }
    }
}
