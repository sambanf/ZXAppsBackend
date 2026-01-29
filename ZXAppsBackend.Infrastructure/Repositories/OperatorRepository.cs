using Microsoft.EntityFrameworkCore;
using ZXAppsBackend.Domain.Entities;
using ZXAppsBackend.Domain.Interfaces;

namespace ZXAppsBackend.Infrastructure.Repositories
{
    public class OperatorRepository : IOperatorRepository
    {
        private readonly AppDbContext _db;

        public OperatorRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TmOperator>> GetAllAsync()
        {
            return await _db.Operators.ToListAsync();
        }

        public async Task<TmOperator?> GetByIdAsync(int id)
        {
            return await _db.Operators.FindAsync(id);
        }
    }
}
