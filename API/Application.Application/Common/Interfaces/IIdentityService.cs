namespace Application.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUsername();
    }
}