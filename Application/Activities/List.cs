using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Presistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> { }
        public class Handeler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;
            public Handeler(DataContext context)
            {

                _context = context;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {

                return await _context.Activities.ToListAsync(cancellationToken);
            }
        }
    }
}