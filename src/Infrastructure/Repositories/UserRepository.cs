using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public UserRepository(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task RegisterAsync(User user)
        {
            await _context.Set<User>().AddAsync(user);
            await _unitOfWork.CommitAsync();
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _context.Set<User>()
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Set<User>()
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task DeleteUserAsync(User user)
        {
            _context.Set<User>().Remove(user);
            await _unitOfWork.CommitAsync();
        }

        public async Task<bool> UserExistsAsync(string email)
        {
            return await _context.Set<User>().AsNoTracking().AnyAsync(u => u.Email == email);
        }
    }
}
