using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BusinessLogic;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private static IList<IEmployee> GetEmployees()
        {
            if (System.Web.HttpContext.Current.Application["emplyees"] is IList<IEmployee> employees)
                return employees;

            var newEmployees = new List<IEmployee>();

            return newEmployees;
        }

        private void SaveEmployees(IList<IEmployee> employees)
        {
            System.Web.HttpContext.Current.Application["emplyees"] = employees;
        }

        private string GetMultiplierText(EmployeeType employeeType)
        {
            switch (employeeType)
            {
                case EmployeeType.Regular:
                    return "Days absent";
                case EmployeeType.Contractual:
                    return "Days present";
                default:
                    throw new ArgumentOutOfRangeException(nameof(employeeType), employeeType, null);
            }
        }

        public ActionResult Index()
        {
            var employees = GetEmployees();
            
            SaveEmployees(employees);

            var preview = employees.Select(x =>
                new EmployeePreview(x.ID, x.Name, x.EmployeeType.ToString()));

            return View(preview);
        }

        [HttpGet]
        public JsonResult GetEmployeeTypes()
        {
            var lotteryTypes = Enum.GetValues(typeof(EmployeeType))
                .Cast<EmployeeType>()
                .Select(x => new
                {
                    id = (int)x,
                    text = x.ToString()
                });

            return Json(lotteryTypes, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CreateEmployee(EmployeeCreateJson data)
        {
            var employees = GetEmployees();
            var newEmployee = EmployeeProvider.CreateEmployee(
                data.Name, data.BirthDate, data.TIN, data.BasicSalary, (EmployeeType) data.EmployeeType);

            employees.Add(newEmployee);
            SaveEmployees(employees);

            var newEmployeePreview =
                new EmployeePreview(newEmployee.ID, newEmployee.Name, newEmployee.EmployeeType.ToString());

            return Json(newEmployeePreview, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetEmployeeDetails(string id)
        {
            try
            {
                var detail = GetEmployee(id);

                return Json(new EmployeeDetail
                {
                    ID = detail.ID,
                    Name =  detail.Name,
                    BirthDate = detail.BirthDate.ToString("dd-MM-yyyy"),
                    TIN = detail.TIN,
                    BasicSalary = detail.BasicSalary,
                    EmployeeType = detail.EmployeeType.ToString(),
                    MultiplierText = GetMultiplierText(detail.EmployeeType)
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                Response.Write(ex.Message);
                return null;
            }
        }

        [HttpPost]
        public JsonResult ComputeSalary(EmployeeComputeSalaryJson data)
        {
            try
            {
                var employee = GetEmployee(data.ID);

                var computedSalary = employee.ComputeSalary(data.DayMultiplier).ToString("N");

                return Json(computedSalary, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                Response.Write(ex.Message);
                return null;
            }
        }

        private IEmployee GetEmployee(string id)
        {
            try
            {
                return GetEmployees().First(x => x.ID == id);
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                Response.Write("Employee does not exists");
                throw;
            }
        }
    }
} 