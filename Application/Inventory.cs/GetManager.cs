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
    public class GetManager
    {
        public class Query : IRequest<List<Manager>> 
        {
            

         }

        public class Handler : IRequestHandler<Query, List<Manager>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<Manager>> Handle(Query request, CancellationToken cancellationToken)
            {
                    var nfp = await _context.Managers
                        .ToListAsync();  
                    return nfp;
                }

            }

    }
}