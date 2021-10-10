using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ToDoAPI.Command;
using ToDoAPI.Data;
using ToDoAPI.Models;

namespace ToDoAPI.Handlers
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand ,ToDoItemModel>
    {
        private readonly IDataAccess _dataaccess;

        public UpdateTaskHandler(IDataAccess dataaccess)
        {
            _dataaccess = dataaccess;
        }
       
        public Task<ToDoItemModel> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataaccess.UpdateTask(request.ItemId,request.ItemName, request.ItemDescription, request.ItemStatus, request.UserName, request.LastUpdated));

        }
    }
}
