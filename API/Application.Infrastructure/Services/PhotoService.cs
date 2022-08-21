using API.Application.Application.Common.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace API.Application.Infrastructure.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;
        public PhotoService(IConfiguration config) {
            _cloudinary = new Cloudinary(
                new Account (
                    config["CloudinarySettings:CloudName"],
                    config["CloudinarySettings:APIKey"],
                    config["CloudinarySettings:APISecret"]
                )
            );
        }
        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            using var stream = file.OpenReadStream();

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Transformation = new Transformation().Width(500).Height(500).Crop("fill").Gravity("face")
            };

            return await _cloudinary.UploadAsync(uploadParams);
        }
    }
}
