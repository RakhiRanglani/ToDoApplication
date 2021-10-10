using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToDoAPI.Data;
using ToDoAPI.Models;
using ToDoAPI.Queries;

namespace ToDoAPI.Handlers
{
    public class GetTaskListHandler : IRequestHandler<GetTaskListQuery, List<ToDoItemModel>>
    {
        private readonly IDataAccess _dataaccess;

        public GetTaskListHandler(IDataAccess dataAccess)
        {
            _dataaccess = dataAccess;
        }
        public Task<List<ToDoItemModel>> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataaccess.GetTask(request.user));
        }
    }
}
