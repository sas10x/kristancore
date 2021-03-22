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
    public class ReportBubble
    {
        public class Query : IRequest<List<Bubble>> 
        {
           public string Category { get; set; }
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
                    .FromSqlRaw("SELECT ArticleDescription AS name, COUNT(ArtNum) AS y,Convert(int, SUM(ConfQty)) AS x,COUNT(ArtNum)+10 AS r FROM [STOCK10XCHANGE].[dbo].[Zva05n]  WHERE ArtNum IN (SELECT Article FROM dbo.Materials WHERE Category=@Uno) GROUP BY ArticleDescription",new SqlParameter("Uno", request.Category))
                    .ToListAsync();  
                     return report; 
                }
            }

    }
}