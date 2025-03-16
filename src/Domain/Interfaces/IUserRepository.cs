using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task RegisterAsync(User user);
        Task<bool> UserExistsAsync(string email);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByIdAsync(Guid id);
        Task DeleteUserAsync(User user);

    }
}
