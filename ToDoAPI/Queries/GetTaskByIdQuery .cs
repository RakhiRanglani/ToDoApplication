using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoAPI.Models;

namespace ToDoAPI.Queries
{
    public record GetTaskByIdQuery(int Id) : IRequest<ToDoItemModel>;

}
