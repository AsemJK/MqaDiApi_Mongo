using MqaDiApi.Data.Models;

namespace MqaDiApi.Api.Services
{
    public interface IAuthService
    {
        Task<(int, string)> Register(User model, string role);
        Task<(int, string)> Login(LoginModel model);
    }
}
