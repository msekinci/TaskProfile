using MSE.TaskProfile.Entities.Concrete;
using MSE.TaskProfile.Entities.Interfaces;
using System.Threading.Tasks;

namespace MSE.TaskProfile.DataAccess.Interfaces
{
    public interface IGenericDAL<T> where T : class, IEntity, new()
    {
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> Read(long ID);
    }
}
