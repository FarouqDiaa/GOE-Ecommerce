using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task RegisterAsync(User user);
        Task<User> LoginAsync(string username, string password);
        Task<User> GetUserByIdAsync(Guid id);
        Task DeleteUserAsync(Guid id);
    }
}
