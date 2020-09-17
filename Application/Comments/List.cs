using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Comments
{
    public class List
    {
        public class Query : IRequest<List<CommentDto>> 
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<CommentDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<CommentDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var comments = await _context.Comments
                    .Where(s => s.Activity.Id == request.Id)
                    .ToListAsync();
                    
                return _mapper.Map<List<Comment>, List<CommentDto>>(comments);
            }

        }
    }
}