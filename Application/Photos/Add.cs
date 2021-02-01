using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Photos
{
    public class Add
    {
        public class Command : IRequest<PhotoDto>
        {
            public IFormFile File { get; set; }
        }

        public class Handler : IRequestHandler<Command, PhotoDto>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IUserAccessor userAccessor, IMapper mapper)
            {
                _userAccessor = userAccessor;
                _context = context;
                _mapper = mapper;
            }

            public async Task<PhotoDto> Handle(Command request, CancellationToken cancellationToken)
            {
                var file = request.File;
                var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == _userAccessor.GetCurrentUsername());
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                // var photoUploadResult = _photoAccessor.AddPhoto(request.File);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fileType = fileName.Split(".")[1];
                    var newName = System.Guid.NewGuid().ToString() + "." + fileType;
                    var fullPath = Path.Combine(pathToSave, newName);
                    var dbPath = Path.Combine(folderName, newName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    var imgUrl = dbPath;
                    var photo = new Photo
                    {
                        Url = imgUrl,
                        Owner = user
                    };
                    _context.Photos.Add(photo);       
                    user.Avatar = imgUrl;
                    var success = await _context.SaveChangesAsync() > 0;
                    var photoReturn = _mapper.Map<Photo, PhotoDto>(photo);
                    if (success) return photoReturn;
                    throw new Exception("Problem saving changes");
                }
                throw new Exception("No attached file");
            }
        }
    }
}