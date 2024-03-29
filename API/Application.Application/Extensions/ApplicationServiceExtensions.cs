﻿using API.Application.API.Helpers;
using API.Application.Application.Common.Interfaces;
using API.Application.Infrastructure.Persistence;
using API.Application.Infrastructure.Services;
using CleanArchitecture.WebUI.Filters;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace API.Application.Application.Extensions
{
    public static class ApplicationServiceExtensions
    {
        [Obsolete]
        public static IServiceCollection AddApplicationServices
            (this IServiceCollection services, IConfiguration _configuration)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddControllersWithViews(options =>
                options.Filters.Add<ApiExceptionFilterAttribute>())
                .AddFluentValidation(x => x.AutomaticValidationEnabled = false);
            
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IPhotoService, PhotoService>();

            return services;
        }
    }
}
