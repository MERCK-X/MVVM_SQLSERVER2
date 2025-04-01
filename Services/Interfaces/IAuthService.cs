using MVVM_SQLSERVER2.Models;

namespace MVVM_SQLSERVER2.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(User user);
        Task<bool> LoginAsync(string email, string password);
        Task<bool> DeleteUserAsync(int id);
        Task<List<User>> GetAllUsersAsync();
    }
}