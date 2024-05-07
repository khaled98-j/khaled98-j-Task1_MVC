using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public IActionResult Index()
        {
            var employee = context.Employees.ToList();
            return View("Index",employee);
        }

        public IActionResult Details(int id)
        {
            //return Content($"id = {id}");

            var employee = context.Employees.Find(id);
            return View("Details", employee);
        }
        
        public IActionResult Create()
        {
            
            return View("Create");
        }

        public IActionResult Store(Employee employee)
        {
            var changeEmployee = context.Employees.Find(employee.Id);
            if (changeEmployee == null)
            {
                context.Employees.Add(employee);
                
            }
            else
            {
                changeEmployee.Name = employee.Name;
                changeEmployee.Title = employee.Title;
                changeEmployee.Age   = employee.Age;
            
            }

            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var employee = context.Employees.Find(id);  
            context.Employees.Remove(employee);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var employee = context.Employees.Find(id);
            return View("Update", employee);
        }


    }
}
