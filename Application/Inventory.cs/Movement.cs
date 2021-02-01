
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Inventory
{
    public class Movement
    {
        public class Command : IRequest
        {
            //  public List<Move> Moves { get; set; }
            public int Id { get; set; }
            public string Document { get; set; }
            public string Article { get; set; }
            public string BUn { get; set; }
            public string Quantity { get; set; }
            public string MvT { get; set; }
            public string Site { get; set; }
            public string SLoc { get; set; }
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
                if (request.MvT == "311" || request.MvT == "301")
                {
                    var sap = await _context.Zmpq25b
                    .Where(s => s.Article == request.Article && s.SLoc == request.SLoc)
                    .SingleAsync();
                    sap.ATP = sap.ATP + Int32.Parse(request.Quantity);
                    sap.Unrestricted = sap.Unrestricted + Int32.Parse(request.Quantity);
                }
                var movement = new Move
                {
                    Document = request.Document,
                    Article = request.Article,
                    BUn = request.BUn,
                    Quantity = request.Quantity,
                    MvT = request.MvT,
                    Site = request.Site,
                    SLoc = request.SLoc,
                };
                 _context.Movements.Add(movement);
                var success = await _context.SaveChangesAsync() > 0;
                if (success) return Unit.Value;
                       throw new Exception("Problem saving changes");
               

            }
        }
    }
}