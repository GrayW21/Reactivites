using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext __context;
            public Handler(DataContext _context)
            {
                __context = _context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                __context.Activities.Add(request.Activity);

                await __context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}