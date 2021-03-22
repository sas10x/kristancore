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
    public class GetCategory
    {
        public class Query : IRequest<List<Category>> 
        {
            
        }

        public class Handler : IRequestHandler<Query, List<Category>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<Category>> Handle(Query request, CancellationToken cancellationToken)
            {
                    var nfp = await _context.Categories
                        .ToListAsync();  
                    return nfp;
                }

            }

    }
}