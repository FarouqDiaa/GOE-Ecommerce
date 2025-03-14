using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    class UserRepository : IUserRepository
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

        public async Task<User> LoginAsync(string username, string password)
        {
            return await _context.Set<User>()
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == username && u.Password == password);
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _context.Set<User>()
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _context.Set<User>().FindAsync(id);
            if (user != null)
            {
                _context.Set<User>().Remove(user);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
