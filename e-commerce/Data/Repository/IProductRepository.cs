using Microsoft.AspNetCore.WebSockets;

namespace e_commerce.Data.Repository
{
    public interface IProductRepository<TEntity>
    {
        Task <IEnumerable<TEntity>> GetAllAsync();

        Task <TEntity?> GetByIdAsync(string id);

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void DeletebyId(string id);

        Task SaveChangesAsync();

    }
}
