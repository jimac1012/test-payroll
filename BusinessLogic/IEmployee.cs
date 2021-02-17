using System;
// ReSharper disable InconsistentNaming

namespace BusinessLogic
{
    public interface IEmployee
    {
        string ID { get; }

        string Name { get; }

        DateTime BirthDate { get; }

        string TIN { get; }

        decimal BasicSalary { get; }

        EmployeeType EmployeeType { get; }

        decimal ComputeSalary(decimal dayMultiplier);
    }
}
