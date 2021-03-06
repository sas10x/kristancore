using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Inventory
{
    public class Prime
    {
        public class Query : IRequest<List<Zmpq25b>> 
        {
           
        }

        public class Handler : IRequestHandler<Query, List<Zmpq25b>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<Zmpq25b>> Handle(Query request, CancellationToken cancellationToken)
            {
                var stocks = await _context.Zmpq25b
                    .Where(site => site.SLoc == "")
                    .Where(atp => atp.ATP < 200)
                    .OrderBy(x => x.ATP)
                    .Take(100)
                    .ToListAsync();
                return stocks;
                // return _mapper.Map<List<Activity>, List<ActivityDto>>(activities);
            }

        }
    }
}