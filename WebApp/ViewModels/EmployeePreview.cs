using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

// ReSharper disable InconsistentNaming

namespace WebApp.ViewModels
{
    public class EmployeePreview
    {
        public EmployeePreview(string id, string name, string employeeType)
        {
            ID = id;
            Name = name;
            EmployeeType = employeeType;
        }

        public string ID { get; }

        public string Name { get; }

        public string EmployeeType { get; }
    }
}