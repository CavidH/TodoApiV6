using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApiV6.Data;
using TodoApiV6.Models;

namespace TodoApiV6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TodoController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<List<Todo>> Get() =>
          await _context.Todos.ToListAsync();

        [HttpPost]
        public async Task<Todo> Add([FromBody] TodoDto todo)
        {
            Todo newTodo = new Todo { Title = todo.Title, Body = todo.Body };
            await _context.Todos.AddAsync(newTodo);
            await _context.SaveChangesAsync();
            return newTodo;
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            Todo? todo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);
            if (todo is null)
                return BadRequest("Bele Todo Movcud Deyil");
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            return Ok(todo);
        }

        [HttpPut]
        public async Task<IActionResult> Add([FromBody] TodoPutDto todo)
        {
            Todo? upTodo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == todo.Id);
            if (upTodo is null)
                return BadRequest("Bele Todo Movcud Deyil");
            upTodo.Title = todo.Title;
            upTodo.Body = todo.Body;
            await _context.SaveChangesAsync();
            return Ok(upTodo);
        }


    }
}