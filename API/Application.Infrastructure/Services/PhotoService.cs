using API.Application.Application.Common.Interfaces;
using CloudinaryDotNet;

namespace API.Application.Infrastructure.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IConfiguration _configuration;
        private readonly Cloudinary _cloudinary;
        public PhotoService(IConfiguration configuration, Cloudinary cloudinary)
        {
            _configuration = configuration;
            _cloudinary = new Cloudinary(new Account(
                _configuration["CloudinarySettings:CloudName"],
                _configuration["CloudinarySettings:APIKey"],
                _configuration["CloudinarySettings:APISecret"]
            ));
        }
    }
}
