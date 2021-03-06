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
    public class ReportBrand
    {
        public class Query : IRequest<List<Bubble>> 
        {
           public string Brand { get; set; }
         }

        public class Handler : IRequestHandler<Query, List<Bubble>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<Bubble>> Handle(Query request, CancellationToken cancellationToken)
            {
                var report = await _context.Bubbles
                    .FromSqlRaw("SELECT ArticleDescription AS name, ArtNum AS Article,  ATP as atp, COUNT(ArtNum) AS y,Convert(int, SUM(ConfQty)) AS x,3 AS r FROM [STOCK10XCHANGE].[dbo].[Zva05n] INNER JOIN Zmpq25b ON Zva05n.ArtNum = Zmpq25b.Article WHERE ArtNum IN (SELECT Article FROM dbo.Materials WHERE Brand=@Uno) AND Zmpq25b.Site!='' GROUP BY ArticleDescription,ArtNum,ATP",new SqlParameter("Uno", request.Brand))
                    .ToListAsync();  
                     return report; 
                }
            }

    }
}