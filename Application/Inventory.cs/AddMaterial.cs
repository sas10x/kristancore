
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
    public class AddMaterial
    {
        public class Command : IRequest
        {
            //  public List<Move> Moves { get; set; }
            public string Article { get; set; }
            public string Description { get; set; }
            public string Uom { get; set; }
            public string Gtin { get; set; }
            public string Status { get; set; }
            public string Brand { get; set; }
            public string Category { get; set; }
            public string Manager { get; set; }
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
                var nfp = await _context.Materials
                        .Where(sap => sap.Article == request.Article) 
                        .SingleAsync();
                if (nfp == null)
                    throw new RestException(HttpStatusCode.NotFound, new {Material = "Already Exist"});
                
                var product = new Material
                {
                    Article = request.Article,
                    Description = request.Description,
                    Uom = request.Uom,
                    Gtin = request.Gtin,
                    Status = request.Status,
                    Brand = request.Brand,
                    Category = request.Category,
                    Manager = request.Manager,
                };
                 _context.Materials.Add(product);
                var success = await _context.SaveChangesAsync() > 0;
                if (success) return Unit.Value;
                       throw new Exception("Problem saving changes");
               
            }
        }
    }
}