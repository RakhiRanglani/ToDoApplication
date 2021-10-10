using MediatR;
using System.Collections.Generic;
using ToDoAPI.Models;

namespace ToDoAPI.Command
{
    public record DeleteTaskCommand(int id) : IRequest<int>;
 
}
