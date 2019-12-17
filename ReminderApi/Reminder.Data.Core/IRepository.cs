using System.Threading.Tasks;

namespace Reminder.Data.Core
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>
        where TEntity : Entity
    {
        void Create(TEntity entity);
        Task CreateAsync(TEntity entity);
        void Update(TEntity entity);
        TEntity Delete(object id);
        Task<TEntity> DeleteAsync(object id);
        void Delete(TEntity entity);
        void Save();
        Task SaveAsync();
    }
}