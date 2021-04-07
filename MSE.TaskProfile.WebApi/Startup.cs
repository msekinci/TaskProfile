using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MSE.TaskProfile.Business.Containers.MicrosoftIoC;
using System;

namespace MSE.TaskProfile.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("doc", new OpenApiInfo
                {
                    Title = "TaskProfile",
                    Description = "Task Profile Document",
                    Contact = new OpenApiContact
                    {
                        Name = "Mehmet Serkan Ekinci",
                        Url = new Uri("https://www.linkedin.com/in/mehmet-serkan-ekinci-b231a412a/")
                    }
                });
            });
            services.AddControllers();
            services.AddDependencies();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(opt => { opt.SwaggerEndpoint("/swagger/doc/swagger.json", "TaskProfile"); });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
