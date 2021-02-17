using System;

// ReSharper disable InconsistentNaming

namespace WebApp.ViewModels
{
    public class EmployeeCreateJson
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string TIN { get; set; }

        public decimal BasicSalary { get; set; }

        public int EmployeeType { get; set; }
    }
}