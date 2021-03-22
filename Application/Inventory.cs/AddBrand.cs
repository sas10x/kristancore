
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
    public class AddBrand
    {
        public class Command : IRequest
        {
           public List<Brand> Brands { get; set; }
            // public string Brand { get; set; }
        
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
              
              foreach(var mail in request.Brands )
                {
                     var brand = new Brand
                    {
                        Name = mail.Name,
                    };
                    _context.Brands.Add(brand);
                }
                // var brand = new Brand
                // {
                //     Name = request.Brand,
                // };
                //  _context.Brands.Add(brand);
                var success = await _context.SaveChangesAsync() > 0;
                if (success) return Unit.Value;
                       throw new Exception("Problem saving changes");
               

            }
        }
    }
}