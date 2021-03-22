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
        public Query(string? to, string? from)
            {
                To = to;
                From = from;
            }
            public string? To { get; set; }
            public string? From { get; set; }
           
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
                    .FromSqlRaw("SELECT ArticleDescription AS description,COUNT(ArtNum) AS frequency,SUM(ConfQty) AS total FROM [STOCK10XCHANGE].[dbo].[Zva05n] WHERE Docdate BETWEEN @From AND @To GROUP BY ArticleDescription",new SqlParameter("To", request.To),new SqlParameter("From", request.From))
                    .ToListAsync();  
                     return report; 
                }
            }

    }
}