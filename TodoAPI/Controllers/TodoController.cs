using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase {
        private readonly TodoContext _context;

        public TodoController(TodoContext context) {
            _context = context;
        }

        // GET: api/<TodoController>
        [HttpGet]
        public List<TodoItem> Get() {

            var item = _context.Todos.ToList();


            return item;
        }

        // GET api/<TodoController>/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }

        // POST api/<TodoController>
        [HttpPost]
        public void Post([FromBody] string value) {
        }

        // PUT api/<TodoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<TodoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
