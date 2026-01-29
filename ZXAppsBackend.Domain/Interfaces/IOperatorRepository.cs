using ZXAppsBackend.Domain.Entities;

namespace ZXAppsBackend.Domain.Interfaces
{
    public interface IOperatorRepository
    {
        Task<IEnumerable<TmOperator>> GetAllAsync();
        Task<TmOperator?> GetByIdAsync(int id);
    }
}
