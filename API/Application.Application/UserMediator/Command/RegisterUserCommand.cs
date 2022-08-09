using API.Application.Infrastructure.Persistence;
using Application.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Security.Cryptography;
using System.Text;

namespace API.Application.Application.UserMediator.Command
{
    public record class RegisterUserCommand : IRequest<User>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, User>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            using var hmac = new HMACSHA512();

            var user = new User
            {
                Username = request.UserName.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password)),
                PasswordSalt = hmac.Key,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();


        }
    }
}
