using System;
// ReSharper disable InconsistentNaming

namespace BusinessLogic
{
    public interface IEmployee
    {
        string Name { get; }

        DateTime BirthDate { get; }

        string TIN { get; }

        decimal BasicSalary { get; }

        decimal ComputeSalary(decimal dayMultiplier);
    }
}
