using MSE.TaskProfile.DataAccess.Concrete.EntityFramework.Context;
using MSE.TaskProfile.DataAccess.Interfaces;
using MSE.TaskProfile.Entities.Interfaces;
using System.Threading.Tasks;

namespace MSE.TaskProfile.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EFGenericRepository<T> : IGenericDAL<T> where T : class, IEntity, new()
    {
        private readonly TaskProfileContext _context;
        public EFGenericRepository(TaskProfileContext context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Read(long ID)
        {
            return await _context.FindAsync<T>(ID);
        }

        public async Task Update(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
