using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IEmployee
    {
        string Name { get; set; }

        DateTime BirthDate { get; set; }

        string TIN { get; set; }

        decimal ComputeSalary(decimal basicSalary, decimal dayMultiplier);
    }
}
