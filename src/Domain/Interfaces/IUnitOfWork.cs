
using Microsoft.EntityFrameworkCore.Storage;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
        public Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
