


using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Fasil", Position = "Developer", Age = 25 },
            new Employee { Id = 2, Name = "Ameer", Position = "Tester", Age = 23 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAll()
        {
            return employees;
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetById(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();
            return emp;
        }

        [HttpPost]
        public ActionResult<Employee> Create(Employee employee)
        {
            int newId = employees.Any() ? employees.Max(e => e.Id) + 1 : 1;
            employee.Id = newId;
            employees.Add(employee);
            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee updatedEmployee)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();

            emp.Name = updatedEmployee.Name;
            emp.Position = updatedEmployee.Position;
            emp.Age = updatedEmployee.Age;

            return NoContent();
        }

        // delet
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();

            employees.Remove(emp);
            return NoContent();
        }
    }
}
