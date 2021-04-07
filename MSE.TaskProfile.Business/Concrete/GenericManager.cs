using MSE.TaskProfile.Business.Interfaces;
using MSE.TaskProfile.DataAccess.Interfaces;
using MSE.TaskProfile.Entities.Interfaces;
using System.Threading.Tasks;

namespace MSE.TaskProfile.Business.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class, IEntity, new()
    {
        private readonly IGenericDAL<T> _genericDal;
        public GenericManager(IGenericDAL<T> genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task Create(T entity)
        {
            await _genericDal.Create(entity);
        }

        public async Task Delete(T entity)
        {
            await _genericDal.Delete(entity);
        }

        public async Task<T> Read(long ID)
        {
            return await _genericDal.Read(ID);
        }

        public async Task Update(T entity)
        {
            await _genericDal.Update(entity);
        }
    }
}
