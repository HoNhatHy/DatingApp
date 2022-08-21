using API.Application.Infrastructure.Persistence;
using Application.Application.Model;
using Application.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Application.PhotoMediatr
{
    public record SetMainPhotoCommand : IRequest<SetMainPhotoResponse>
    {
        public int UserId { get;set; }
        public int PhotoId { get;set; }
    }

    public class SetMainPhotoCommandHandler : IRequestHandler<SetMainPhotoCommand, SetMainPhotoResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public SetMainPhotoCommandHandler(ApplicationDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public async Task<SetMainPhotoResponse> Handle(SetMainPhotoCommand request, CancellationToken cancellationToken)
        {
            User user = await _context.Users.Where(user => user.Id == request.UserId).Include(user => user.Photos).FirstOrDefaultAsync();

            Photo photo = user.Photos.SingleOrDefault(photo => photo.Id == request.PhotoId);

            if (photo.IsMain == true) {
                throw new Exception("Photo is already the main photo");
            }

            photo.IsMain = true;
            await _context.SaveChangesAsync();

            var response = _mapper.Map<SetMainPhotoResponse>(photo);

            return response;
        }
    }
}