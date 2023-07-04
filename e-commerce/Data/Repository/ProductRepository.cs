using e_commerce.Data.Context;
using e_commerce.Models.asbstractClasses;
using e_commerce.Models.interfaces;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data.Common;

namespace e_commerce.Data.Repository
{
    public class ProductRepository<TEntity> : IProductRepository<TEntity> where TEntity : AbstractProduct
    {
        private readonly ProductContext _context;
        private readonly DbSet<TEntity> _dbset;

        public  ProductRepository(ProductContext context)
        {
            _context = context;

            _dbset =  _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity data)
        {
            try
            {
                data.Id = Guid.NewGuid().ToString();

                await _context.Set<TEntity>().AddAsync(data);
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("Failed to add  to the database.");
            }
        }

        public void  DeletebyId(string id)
        {
            TEntity? dataToDelete = _context.Set<TEntity>().Find(id);
            if (dataToDelete != null)
            {
                 _context.Set<TEntity>().Remove(dataToDelete);
            }
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().AsNoTracking()
            .ToListAsync();
        }
        public async Task<TEntity?> GetByIdAsync(string id)
        {
            TEntity? entity = await _context.Set<TEntity>().FindAsync(id);
            return entity; 
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void  Update(TEntity data)
        {
            _dbset.Attach(data);
            _context.Entry(data).State = EntityState.Modified;
        }
    }
}
