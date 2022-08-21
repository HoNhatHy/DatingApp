using API.Application.Infrastructure.Persistence;
using Application.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Application.PhotoMediatr
{
    public record DeletePhotoCommand : IRequest<string>
    {
        public int UserId { get;set; }
        public int PhotoId { get;set; }        
    }

    public class DeletePhotoCommandHandler : IRequestHandler<DeletePhotoCommand, string>
    {
        private readonly ApplicationDbContext _context;
        public DeletePhotoCommandHandler(ApplicationDbContext context) {
            _context = context;
        }
        public async Task<string> Handle(DeletePhotoCommand request, CancellationToken cancellationToken)
        {
            User user = await _context.Users.Where(user => user.Id == request.UserId)
                            .Include(user => user.Photos)
                            .SingleOrDefaultAsync();

            Photo photo = user.Photos.FirstOrDefault(photo => photo.Id == request.PhotoId);

            if (photo.IsMain == true) {
                throw new Exception("Cannot delete the main photo");
            }

            user.Photos.Remove(photo);
            await _context.SaveChangesAsync();

            return "Deleted successfully";
        }
    }
}