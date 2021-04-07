using Microsoft.Extensions.DependencyInjection;
using MSE.TaskProfile.Business.Concrete;
using MSE.TaskProfile.Business.Interfaces;
using MSE.TaskProfile.DataAccess.Concrete.EntityFramework.Context;
using MSE.TaskProfile.DataAccess.Concrete.EntityFramework.Repositories;
using MSE.TaskProfile.DataAccess.Interfaces;

namespace MSE.TaskProfile.Business.Containers.MicrosoftIoC
{
    public static class CustomIoCExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<TaskProfileContext>();
            services.AddScoped(typeof(IGenericDAL<>), typeof(EFGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
        }
    }
}
