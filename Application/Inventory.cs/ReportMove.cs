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
    public class ReportMove
    {
        public class Query : IRequest<List<ReportBar>> 
        {
            public string Article { get; set; }
         }

        public class Handler : IRequestHandler<Query, List<ReportBar>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<ReportBar>> Handle(Query request, CancellationToken cancellationToken)
            {
                var report = await _context.ReportBars
                    .FromSqlRaw("SELECT PstngDate,MvT,Convert(int, Quantity) as Quantity,SLoc FROM dbo.Mb51 WHERE Article=@Uno AND Username LIKE 'DC8200%' GROUP BY PstngDate, MvT,SLoc, Quantity", new SqlParameter("Uno", request.Article))
                    .ToListAsync();  
                     return report; 
                }

            }

    }
}