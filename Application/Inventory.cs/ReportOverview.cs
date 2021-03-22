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
    public class ReportOverview
    {
        public class Query : IRequest<ReportSummary> 
        {
            public string Article { get; set; }
         }

        public class Handler : IRequestHandler<Query, ReportSummary>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ReportSummary> Handle(Query request, CancellationToken cancellationToken)
            {
                var report = await _context.Reports
                    .FromSqlRaw("SELECT MAX(ConfQty) AS highest,MIN(ConfQty) AS lowest,AVG(ConfQty) AS average,SUM(ConfQty) AS total,COUNT(ConfQty) AS totalrecords FROM [STOCK10XCHANGE].[dbo].[Zva05n] WHERE (ArtNum=@Uno AND SType='ZPOS') OR (ArtNum=@Uno AND SType='ZCAS') OR (ArtNum=@Uno AND SType='ZOR')", new SqlParameter("Uno", request.Article))
                    .SingleAsync();
                    return report;
                }

            }

    }
}