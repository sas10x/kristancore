using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Inventory
{
    public class DetailMb51
    {
        public class Query : IRequest<List<Mb51>> 
        {
            public string Article { get; set; }
         }

        public class Handler : IRequestHandler<Query, List<Mb51>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<Mb51>> Handle(Query request, CancellationToken cancellationToken)
            {
                    var nfp = await _context.Mb51
                        .Where(x => x.Article == request.Article)
                        .ToListAsync();  
                    return nfp;
                }

            }

    }
}