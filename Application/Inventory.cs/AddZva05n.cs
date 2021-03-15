
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
    public class AddZva05n
    {
        public class Command : IRequest
        {
            public string DeliveryStatus { get; set; }
            public string SO { get; set; }
            public string Rfr { get; set; }
            public string Site { get; set; }
            public string SLoc { get; set; }
            public string ShpTyp { get; set; }
            public DateTime Docdate { get; set; }
            public string ItemNum { get; set; }
            public string ArtNum { get; set; }
            public string ArticleDescription { get; set; }
            public string UoM { get; set; }
            public decimal OrderedQty { get; set; }
            public decimal ConfQty { get; set; }
            public decimal PgiQty { get; set; }
            public decimal QtyToDeliv { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal NetAmt { get; set; }
            public decimal NetTax { get; set; }
            public decimal InvoiceAmt { get; set; }
            public decimal TotalPending { get; set; }
            public string SalesOrg { get; set; }
            public string SType { get; set; }
            public string Salesman { get; set; }
            public string CustCode { get; set; }
            public string SalGrp { get; set; }
            public string CreatedBy { get; set; }
            public string Entrytime { get; set; }
            public string CCodeToBeBilled { get; set; }
            public string DistChan { get; set; }
    
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
                var zva = new Zva05n
                {
                    DeliveryStatus = request.DeliveryStatus,
                    SO = request.SO,
                    Rfr = request.Rfr,
                    Site = request.Site,
                    SLoc = request.SLoc,
                    ShpTyp = request.ShpTyp,
                    Docdate = request.Docdate,
                    ItemNum = request.ItemNum,
                    ArtNum = request.ArtNum,
                    ArticleDescription = request.ArticleDescription,
                    UoM = request.UoM,
                    OrderedQty = request.OrderedQty,
                    ConfQty = request.ConfQty,
                    PgiQty = request.PgiQty,
                    QtyToDeliv = request.QtyToDeliv,
                    UnitPrice = request.UnitPrice,
                    NetAmt = request.NetAmt,
                    NetTax = request.NetTax,
                    InvoiceAmt = request.InvoiceAmt,
                    TotalPending = request.TotalPending,
                    SalesOrg = request.SalesOrg,
                    SType = request.SType,
                    Salesman = request.SLoc,
                    CustCode = request.CustCode,
                    SalGrp = request.SalGrp,
                    CreatedBy = request.CreatedBy,
                    Entrytime = request.Entrytime,
                    CCodeToBeBilled = request.CCodeToBeBilled,
                    DistChan = request.DistChan,
                    GtrStatus = "pending",
                };
                 _context.Zva05n.Add(zva);
                var success = await _context.SaveChangesAsync() > 0;
                if (success) return Unit.Value;
                       throw new Exception("Problem saving changes");
               

            }
        }
    }
}