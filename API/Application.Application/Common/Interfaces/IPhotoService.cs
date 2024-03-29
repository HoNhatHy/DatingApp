﻿using CloudinaryDotNet.Actions;

namespace API.Application.Application.Common.Interfaces
{
    public interface IPhotoService
    {
        public Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
    }
}
