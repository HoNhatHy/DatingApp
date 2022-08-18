using System.Security.Cryptography;
using System.Text;
using API.Application.Application.Common.Interfaces;
using API.Application.Infrastructure.Persistence;
using Application.Application.Model;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Application.UserMediator.Query
{
    public record LoginUserQuery : IRequest<UserLoginResponse>
    {
        public string Username {get;set;}
        public string Password {get;set;}
    }

    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, UserLoginResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly ITokenService _tokenService;

        public LoginUserQueryHandler(ApplicationDbContext context, ITokenService tokenService) {
            _context = context;
            _tokenService = tokenService;
        }
        public async Task<UserLoginResponse> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync
                            (
                                user => user.Username == request.Username
                            );
            
            if(user == null) throw new UnauthorizedAccessException("Username doesn't exist");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));

            for(int i = 0; i < computedHash.Length; i++) {
                if(computedHash[i] != user.PasswordHash[i])
                    throw new UnauthorizedAccessException("Password is incorrect");
            }

            return new UserLoginResponse{
                Username = user.Username,
                Token = _tokenService.CreateToken(user),
            };
        }
    }

    public class LoginUserQueryValidator : AbstractValidator<LoginUserQuery> {
        public LoginUserQueryValidator() {
            RuleFor(x => x.Username).NotEmpty().WithMessage("{PropertyName} should not be empty");
            RuleFor(x => x.Password).NotEmpty().WithMessage("{PropertyName} should not be empty");
        }
    }
}