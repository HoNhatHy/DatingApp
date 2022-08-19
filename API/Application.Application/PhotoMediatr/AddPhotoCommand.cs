using API.Application.Application.Common.Interfaces;
using API.Application.Application.Model;
using API.Application.Infrastructure.Persistence;
using MediatR;

namespace API.Application.Application.PhotoMediatr
{
    public record AddPhotoCommand : IRequest<AddPhotoResponse>
    {
        public IFormFile File { get; set; }
    }

    public class AddPhotoCommandHandler : IRequestHandler<AddPhotoCommand, AddPhotoResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly IPhotoService _photoService;
        public AddPhotoCommandHandler(ApplicationDbContext context, IPhotoService photoService)
        {
            _context = context;
            _photoService = photoService;
        }

        public Task<AddPhotoResponse> Handle(AddPhotoCommand request, CancellationToken cancellationToken)
        {
            var resultAfterAddPhotoToCloudinary = _photoService.AddPhotoAsync(request.File);

            
        }
    }
}
