using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
