using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTodo.Data;
using MyTodo.Dto;
using MyTodo.Models;
using MyTodo.Data.Repository.Interface;

namespace MyTodo.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ITodoRepository _repository;

        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var todos = await _repository.GetAllAsync();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var todo = await _repository.GetByIdAsync(id);

            return todo == null ? NotFound() : Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateTodoDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var todo = new Todo
                {
                    Date = DateTime.Now,
                    Done = false,
                    Title = model.Title
                };

                await _repository.AddAsync(todo);
                // await _context.SaveChangesAsync();

                return Created(uri: $"v1/todos/{todo.Id}", todo);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(
            [FromBody] CreateTodoDto model,
            [FromRoute] int id
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var todo = await _repository.GetByIdAsync(id);

                if (todo == null)
                {
                    return NotFound();
                }

                todo.Title = model.Title;

                await _repository.UpdateAsync(todo);
                // await _context.SaveChangesAsync();

                return Ok(todo);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteAsnyc([FromRoute] int id)
        {
            var todo = await _repository.GetByIdAsync(id);

            if (todo == null)
                return NotFound();

            await _repository.DeleteAsnyc(todo);
            // await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
