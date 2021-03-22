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
    public class GetBrand
    {
        public class Query : IRequest<List<Brand>> 
        {
            

         }

        public class Handler : IRequestHandler<Query, List<Brand>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<Brand>> Handle(Query request, CancellationToken cancellationToken)
            {
                    var nfp = await _context.Brands
                        .ToListAsync();  
                    return nfp;
                }

            }

    }
}