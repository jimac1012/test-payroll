using System;
// ReSharper disable InconsistentNaming

namespace BusinessLogic
{
    public class RegularEmployee : IEmployee
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string TIN { get; set; }

        public decimal ComputeSalary(decimal basicSalary, decimal dayMultiplier)
        {
            var tax = basicSalary * (decimal)0.12;
            var absence = dayMultiplier * (basicSalary / 22);

            return basicSalary - tax - absence;
        }
    }
}
