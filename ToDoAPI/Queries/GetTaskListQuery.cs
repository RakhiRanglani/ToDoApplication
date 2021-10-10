using MediatR;
using System.Collections.Generic;
using ToDoAPI.Models;

namespace ToDoAPI.Queries
{
    public record GetTaskListQuery():IRequest<List<ToDoItemModel>>;
   
}
