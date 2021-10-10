using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Command;
using ToDoAPI.Models;
using ToDoAPI.Queries;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunctionalController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FunctionalController(IMediator mediater)
        {
            _mediator = mediater;
        }

        // GET: api/Functional
        [HttpGet("{user}")]
        public async Task<ActionResult<IEnumerable<ToDoItemModel>>> GetToDoItems(string user)
        {
            return await _mediator.Send(new GetTaskListQuery(user));
        }
        // PUT: api/Functional/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ToDoItemModel> PutToDoItemModel(int id, ToDoItemModel toDoItemModel)
        {

            return await _mediator.Send(new UpdateTaskCommand(id, toDoItemModel.ItemName, toDoItemModel.ItemDescription, toDoItemModel.ItemStatus, toDoItemModel.UserName, toDoItemModel.LastUpdated));

        }

        // POST: api/Functional
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ToDoItemModel>> PostToDoItemModel([FromBody]ToDoItemModel taskModel)
        {
            return await _mediator.Send(new AddTaskCommand(taskModel.ItemName, taskModel.ItemDescription, taskModel.ItemStatus, taskModel.UserName, taskModel.LastUpdated));
        
        }

        // DELETE: api/Functional/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItemModel(int id)
        {
            var toDoItemModel = await _mediator.Send(new DeleteTaskCommand(id));
           
            return NoContent();
        }

      
    }
}
