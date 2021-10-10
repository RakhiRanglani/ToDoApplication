using MediatR;
using System;
using System.Collections.Generic;
using ToDoAPI.Models;

namespace ToDoAPI.Command
{
    public record UpdateTaskCommand(int ItemId, string ItemName, string ItemDescription, bool ItemStatus, string UserName, DateTime LastUpdated) : IRequest<ToDoItemModel>;
    
}
