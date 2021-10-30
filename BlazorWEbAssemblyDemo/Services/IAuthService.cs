

using BlazorWEbAssemblyDemo.Models;
using System.Threading.Tasks;

namespace BlazorWEbAssemblyDemo.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
        Task Logout();
    }
}
