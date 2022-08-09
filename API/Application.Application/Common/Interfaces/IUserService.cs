namespace API.Application.Application.Common.Interfaces
{
    public interface IUserService
    {
        public Task<bool> CheckUserExists(string username);
    }
}
