using Confitec.Application.MappingProfile;
using Confitec.Application.Service;
using Confitec.Infrastructure.Data.Context;
using Confitec.Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

[assembly: ApiController]
namespace Confitec.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Confitec - Usuários CRUD", Version = "v1" }));

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });

            services.AddAutoMapper(typeof(UserProfile));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(config =>
            {
                config.AllowAnyOrigin();
                config.AllowAnyMethod();
                config.AllowAnyHeader();
            });


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Confitec - Usuários CRUD");
            });

            var applicationContext = serviceProvider.GetService<DatabaseContext>();
            applicationContext.Database.Migrate();
        }
    }
}
