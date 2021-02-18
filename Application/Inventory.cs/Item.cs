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
    public class Item
    {
        public class Query : IRequest<List<ItemDto>> 
        {
            public string Search { get; set; }
         }

        public class Handler : IRequestHandler<Query, List<ItemDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<ItemDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var isNumeric = int.TryParse(request.Search, out _);
                
                if (isNumeric)
                {   
                    var nfp = await _context.Zmpq25b
                        .Where(sap => sap.Article.Contains(request.Search)) 
                        .Where(site => site.SLoc == "")
                        .ToListAsync();  
                    // return nfp;
                    return _mapper.Map<List<Zmpq25b>, List<ItemDto>>(nfp);
                }

                else {
                    var nfp = await _context.Zmpq25b
                        .Where(sap => sap.Description.Contains(request.Search)) 
                        .Where(site => site.SLoc == "")
                        .ToListAsync();  
                    return _mapper.Map<List<Zmpq25b>, List<ItemDto>>(nfp);
                }

            }

        }
    }
}