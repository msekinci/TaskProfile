using MSE.TaskProfile.Entities.Interfaces;
using System.Threading.Tasks;

namespace MSE.TaskProfile.Business.Interfaces
{
    public interface IGenericService<T> where T : class, IEntity, new()
    {
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> Read(long ID);
    }
}
