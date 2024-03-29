﻿using API.Application.Application.Common.Interfaces;
using API.Application.Application.Model;
using API.Application.Infrastructure.Persistence;
using Application.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace API.Application.Application.UserMediator.Command
{
    public record RegisterUserCommand : IRequest<UserRegisterResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserRegisterResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly ITokenService _tokenService;

        public RegisterUserCommandHandler(ApplicationDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<UserRegisterResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userFound = await _context.Users.AnyAsync(user => user.Username == request.Username);

            if(userFound) throw new UnauthorizedAccessException("User already exists");

            using var hmac = new HMACSHA512();

            var user = new User
            {
                Username = request.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password)),
                PasswordSalt = hmac.Key,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserRegisterResponse
            {
                Username = user.Username,
                Token = _tokenService.CreateToken(user)
            };
        }
    }

    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("{PropertyName} should not be empty")
                .Length(6, 25).WithMessage("Length of {PropertyName} has to be between 5 and 26");
        }
    }
}
