using JwtApi.Models;

namespace JwtApi.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        User Register(User user);
        User GetByUsername(string username);
    }
}
