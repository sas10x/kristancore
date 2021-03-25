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
    public class ReportPetsa
    {
        public class Query : IRequest<List<Bubble>> 
        {
        //    public string To { get; set; }
        //    public string From { get; set; }
        public Query(string to, string from)
            {
                To = to;
                From = from;
            }
            public string To { get; set; }
            public string From { get; set; }
           
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
                    .FromSqlRaw("SELECT ArticleDescription AS name, ArtNum as article, ATP as atp,COUNT(ArtNum) AS y,Convert(int, SUM(ConfQty)) AS x,3 AS r FROM [STOCK10XCHANGE].[dbo].[Zva05n] INNER JOIN Zmpq25b ON Zva05n.ArtNum = Zmpq25b.Article WHERE Zmpq25b.Site='8200' And Zmpq25b.SLoc='' And Docdate BETWEEN @From AND @To  GROUP BY ArticleDescription,ArtNum,ATP",new SqlParameter("From", request.From),new SqlParameter("To", request.To))
                    .ToListAsync();  
                     return report; 
                }
            }

    }
}