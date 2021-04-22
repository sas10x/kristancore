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
    public class PendingZva
    {
        public class Query : IRequest<List<Zva05n>> 
        {
            
         }

        public class Handler : IRequestHandler<Query, List<Zva05n>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<Zva05n>> Handle(Query request, CancellationToken cancellationToken)
            {
                    var nfp = await _context.Zva05n
                        .Where(x => x.SType == "ZOR" ||  x.SType == "ZCAS" ||  x.SType == "ZINH" ||  x.SType == "FD")
                        .Where(x => x.DeliveryStatus == "Pending Delivery" || x.DeliveryStatus == "Partially Delivered")
                        .ToListAsync();  
                    return nfp;
                }

            }

    }
}