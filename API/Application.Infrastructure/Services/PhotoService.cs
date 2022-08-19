using API.Application.Application.Common.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace API.Application.Infrastructure.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;
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
