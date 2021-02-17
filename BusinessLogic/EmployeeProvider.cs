using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public static class EmployeeProvider
    {
        public static IEmployee CreateEmployee(string name, DateTime birthDate, string tin, decimal basicSalary, EmployeeType employeeType)
        {
            var factory = new EmployeeFactory(name, birthDate, tin, basicSalary);

            return factory.CreateEmployee(employeeType);
        }
    }
}
