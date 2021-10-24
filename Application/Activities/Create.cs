using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Presistence;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            public Command() { }
            public Activity Activity { get; set; }
            public Command(Activity activity)
            {
                this.Activity = activity;

            }

        }
        public class Handeler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handeler(DataContext context)
            {
                _context = context;

            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Activities.Add(request.Activity);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}