using API.Application.Application.Common.Interfaces;
using API.Application.Application.Model;
using API.Application.Infrastructure.Persistence;
using Application.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Application.PhotoMediatr
{
    public record AddPhotoCommand : IRequest<AddPhotoResponse>
    {
        public IFormFile File { get; set; }
        public int UserId { get; set; }
    }

    public class AddPhotoCommandHandler : IRequestHandler<AddPhotoCommand, AddPhotoResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly IPhotoService _photoService;
        private readonly IMapper _mapper;
        public AddPhotoCommandHandler(ApplicationDbContext context, IPhotoService photoService, IMapper mapper)
        {
            _context = context;
            _photoService = photoService;
            _mapper = mapper;
        }

        public async Task<AddPhotoResponse> Handle(AddPhotoCommand request, CancellationToken cancellationToken)
        {
            var resultAfterAddPhotoToCloudinary = await _photoService.AddPhotoAsync(request.File);

            User user = await _context.Users.Where(user => user.Id == request.UserId)
                                .Include(user => user.Photos)
                                .FirstOrDefaultAsync();

            Photo photo = new Photo {
                Url = resultAfterAddPhotoToCloudinary.SecureUrl.AbsoluteUri,
                PublicId = resultAfterAddPhotoToCloudinary.PublicId,
                IsMain = false
            };

            if (user.Photos.Count == 0) {
                photo.IsMain = true;
            }

            user.Photos.Add(photo);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<AddPhotoResponse>(photo);

            return result;
        }
    }
}
