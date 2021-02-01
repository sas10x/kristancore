
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Inventory
{
    public class Sap
    {
        public class Query : IRequest<List<Zmpq25b>> 
        {
            public string Barcode { get; set; }
         }

        public class Handler : IRequestHandler<Query, List<Zmpq25b>>
        {
            private readonly DataContext _context;
            // private readonly IMapper _mapper;

            public Handler(DataContext context)
            {
                _context = context;
                // _mapper = mapper;
            }

            public async Task<List<Zmpq25b>> Handle(Query request, CancellationToken cancellationToken)
            {
                // var nfp = await _context.Zmpq25b
                //         .ToListAsync();
                var nfp = await _context.Zmpq25b
                        .Where(sap => sap.Gtin == request.Barcode) 
                        .ToListAsync();      
                // if (nfp == null)  
                // {
                //     zmpq = new Zmpq25b
                // {
                //     Activity = activity,
                //     AppUser = user,
                //     IsHost = false,
                //     DateJoined = DateTime.Now
                // };
                // }
                return nfp;
            }

        }
    }
}