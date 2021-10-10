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
    public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, ToDoItemModel>
    {
        private readonly IMediator _mediator;

        public GetTaskByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<ToDoItemModel> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _mediator.Send(new GetTaskListQuery());
            var searchtask = task.FirstOrDefault(x => x.ItemId == request.Id);
            return searchtask;
        }
    }

}
