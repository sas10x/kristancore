
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
            public decimal Unrestricted { get; set; }
            public decimal Confirm { get; set; }
            public decimal ATP { get; set; }
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
                // var stock = await _context.Zmpq25b
                //     .Where(sap => sap.Article == request.Article)
                //     .Where(sap => sap.SLoc == request.SLoc)
                //     .SingleAsync();
            
                // if (await _context.Zmpq25b.Where(x => x.Article == request.Article).Where(y => y.SLoc == request.SLoc).AnyAsync())
                // {
                //     _context.Zmpq25b.Remove(stock);
                // }
                var zmpq = new Zmpq25b
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
                        Size = request.Size,
                        GtrStatus = "pending"
                    };
                _context.Zmpq25b.Add(zmpq);
                var success = await _context.SaveChangesAsync() > 0;
                if (success) return Unit.Value;
                       throw new Exception("Problem saving changes");
               

            }
        }
    }
}