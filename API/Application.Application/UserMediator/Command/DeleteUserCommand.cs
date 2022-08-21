using API.Application.Infrastructure.Persistence;
using Application.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Application.UserMediator.Command
{
    public record DeleteUserCommand : IRequest<string>
    {
        public string Username { get;set; }        
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, string>
    {   
        private readonly ApplicationDbContext _context;
        public DeleteUserCommandHandler(ApplicationDbContext context) {
            _context = context;
        }
        public async Task<string> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            User user = await _context.Users.FirstOrDefaultAsync(user => user.Username == request.Username);
            
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return "Successful";
        }
    }
}