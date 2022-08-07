using Application.Application.Common.Interfaces;

namespace Application.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        public Task<string> GetUsername()
        {
            throw new NotImplementedException();
        }
    }
}