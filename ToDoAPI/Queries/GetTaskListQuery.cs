using MediatR;
using System.Collections.Generic;
using ToDoAPI.Models;

namespace ToDoAPI.Queries
{
    public record GetTaskListQuery(string user):IRequest<List<ToDoItemModel>>;
   
}
