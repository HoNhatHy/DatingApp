using Application.Domain.Entities;

namespace API.Application.Application.Common.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
