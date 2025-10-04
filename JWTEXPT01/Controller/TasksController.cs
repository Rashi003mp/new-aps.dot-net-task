using JwtApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // all endpoints require authentication
    public class TasksController : ControllerBase
    {
        private static List<TaskItem> tasks = new List<TaskItem>();

        // GET: all users
        [HttpGet]
        public IActionResult GetAll() => Ok(tasks);

        // POST: all users
        [HttpPost]
        public IActionResult Create([FromBody] TaskItem task)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            task.Id = tasks.Any() ? tasks.Max(t => t.Id) + 1 : 1;
            tasks.Add(task);
            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }

        // GET by id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        // PUT: all users
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TaskItem updatedTask)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound();

            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;

            return Ok(task);
        }

        // DELETE: only Admin
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound();

            tasks.Remove(task);
            return NoContent();
        }
    }
}
