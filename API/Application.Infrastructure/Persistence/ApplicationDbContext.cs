using Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
