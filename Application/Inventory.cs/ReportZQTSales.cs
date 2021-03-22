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
    public class ReportZQTSales
    {
        public class Query : IRequest<List<Report>> 
        {
            public string Article { get; set; }
         }

        public class Handler : IRequestHandler<Query, List<Report>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<Report>> Handle(Query request, CancellationToken cancellationToken)
            {
                var report = await _context.DateReports
                    .FromSqlRaw("SELECT Docdate as Name,SUM(ConfQty) AS value FROM [STOCK10XCHANGE].[dbo].[Zva05n] WHERE (ArtNum=@Uno AND SType='ZQT') OR (ArtNum=@Uno AND SType='ZQTR') GROUP BY Docdate", new SqlParameter("Uno", request.Article))
                    .ToListAsync();  
                     return report; 
                }

            }

    }
}