using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<ActivityDto>> { }

        public class Handler : IRequestHandler<Query, List<ActivityDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            private readonly IUserAccessor _userAccessor;
            public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<ActivityDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == _userAccessor.GetCurrentUsername());
                var followings = await _context.Followings
                        .Where(follow => follow.Observer.UserName == user.UserName)    
                        .Select(follow => follow.TargetId)   
                        .ToArrayAsync();     
                    
                var activities = await _context.Activities
                    // .Where(a => followings.Contains(a.Author.Id) || a.Author.Id == user.Id)
                    .OrderBy(x => x.UpdatedAt)
                    .ToListAsync();
                return _mapper.Map<List<Activity>, List<ActivityDto>>(activities);
            }
        }
    }
}