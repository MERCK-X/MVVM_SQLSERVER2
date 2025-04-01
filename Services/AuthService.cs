using Microsoft.EntityFrameworkCore;
using MVVM_SQLSERVER2.Data;
using MVVM_SQLSERVER2.Models;
using MVVM_SQLSERVER2.Services.Interfaces;

namespace MVVM_SQLSERVER2.Services
{
    public class AuthService : IAuthService
    {
        private readonly LocalDbContext _db;

        public AuthService(LocalDbContext db)
        {
            _db = db;
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            _db.Database.EnsureCreated();
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            return await _db.Users
                .AnyAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<bool> RegisterAsync(User user)
        {
            await _db.Users.AddAsync(user);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _db.Users.ToListAsync();
        }
    }
}