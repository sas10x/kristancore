
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Inventory
{
    public class AddStockx
    {
        public class Command : IRequest
        {
            public string Article { get; set; }
            public string Gtin { get; set; }
            public string Description { get; set; }
            public string BUn { get; set; }
            public string Site { get; set; }
            public string SLoc { get; set; }
            public int Unrestricted { get; set; }
            public int Confirm { get; set; }
            public int ATP { get; set; }
            public string Brand { get; set; }
            public string Status { get; set; }
            public string Size { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
           
            public Handler(DataContext context)
            {
               _context = context;   
            }
        
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var product = new Zmpq25b
                {
                    Article = request.Article,
                    Gtin = request.Gtin,
                    Description = request.Description,
                    BUn = request.BUn,
                    Site = request.Site,
                    SLoc = request.SLoc,
                    Unrestricted = request.Unrestricted,
                    Confirm = request.Confirm,
                    ATP = request.ATP,
                    Brand = request.Brand,
                    Status = request.Status,
                    Size = request.Size
                };
                 _context.Zmpq25b.Add(product);
                var success = await _context.SaveChangesAsync() > 0;
                if (success) return Unit.Value;
                       throw new Exception("Problem saving changes");
               

            }
        }
    }
}