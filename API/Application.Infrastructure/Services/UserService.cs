using API.Application.Application.Common.Interfaces;
using API.Application.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CheckUserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.Username == username.ToLower());
        }
    }
}
