
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
    public class AddMb51
    {
        public class Command : IRequest
        {
            //  public List<Move> Moves { get; set; }
            public DateTime EntryDate { get; set; }
            public DateTime PstngDate { get; set; }
            public string Time { get; set; }
            public DateTime DocDate { get; set; }
            public string ArtDoc { get; set; }
            public string Article { get; set; }
            public string ArticleDescription { get; set; }
            public string BUn { get; set; }
            public decimal Quantity { get; set; }
            public string MvT { get; set; }
            public string Site { get; set; }
            public string SLoc { get; set; }
            public string Customer { get; set; }
            public string MvtTypeText { get; set; }
            public string Name1 { get; set; }
            public string Username { get; set; }
            public string GtrStatus { get; set; }
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
                // if (request.MvT == "311" || request.MvT == "301")
                // {
                //     var sap = await _context.Zmpq25b
                //     .Where(s => s.Article == request.Article && s.SLoc == request.SLoc)
                //     .SingleAsync();
                //     sap.ATP = sap.ATP + Int32.Parse(request.Quantity);
                //     sap.Unrestricted = sap.Unrestricted + Int32.Parse(request.Quantity);
                // }
                var movement = new Mb51
                {
                    EntryDate = request.EntryDate,
                    PstngDate = request.PstngDate,
                    Time = request.Time,
                    DocDate = request.DocDate,
                    ArtDoc = request.ArtDoc,
                    Article = request.Article,
                    ArticleDescription = request.ArticleDescription,
                    BUn = request.BUn,
                    Quantity = request.Quantity,
                    MvT =  request.MvT,
                    Site = request.Site,
                    SLoc = request.SLoc,
                    Customer = request.Customer,
                    MvtTypeText = request.MvtTypeText,
                    Name1 = request.Name1,
                    Username = request.Username,
                    GtrStatus = "pending"
                };
                 _context.Mb51.Add(movement);
                var success = await _context.SaveChangesAsync() > 0;
                if (success) return Unit.Value;
                       throw new Exception("Problem saving changes");
               

            }
        }
    }
}