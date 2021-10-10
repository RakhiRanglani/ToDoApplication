using System.Threading.Tasks;
using ToDoAPI.Command;
using ToDoAPI.Data;
using MediatR;
using System;
using System.Threading;
using ToDoAPI.Models;

namespace ToDoAPI.Handlers
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, int>
    {
        private readonly IDataAccess _dataaccess;

        public DeleteTaskHandler(IDataAccess dataaccess)
        {
            _dataaccess = dataaccess;
        }
        public Task<int> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            return _dataaccess.DeleteTask(request.id);
        }

      
    }
}
