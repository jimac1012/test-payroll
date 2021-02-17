using System;
// ReSharper disable InconsistentNaming

namespace WebApp.ViewModels
{
    public class EmployeeDetail
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string BirthDate { get; set; }

        public string TIN { get; set; }

        public decimal BasicSalary { get; set; }

        public string EmployeeType { get; set; }

        public string MultiplierText { get; set; }
    }
}