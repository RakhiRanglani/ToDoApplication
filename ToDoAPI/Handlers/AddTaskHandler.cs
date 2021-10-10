using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ToDoAPI.Command;
using ToDoAPI.Data;
using ToDoAPI.Models;

namespace ToDoAPI.Handlers
{
    public class AddTaskHandler : IRequestHandler<AddTaskCommand ,ToDoItemModel>
    {
        private readonly IDataAccess _dataaccess;

        public AddTaskHandler(IDataAccess dataaccess)
        {
            _dataaccess = dataaccess;
        }
        public Task<ToDoItemModel> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataaccess.AddTask(request.ItemName, request.ItemDescription, request.ItemStatus, request.UserName, request.LastUpdated));
        }
    }
}
