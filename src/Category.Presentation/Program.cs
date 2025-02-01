using Category.Domain.CommanInterfaces;
using Category.Infrastructure;
using Category.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Category.Service.CatalogBrands;

namespace Category.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<CatalogDbContext>(options =>
                    options.UseSqlServer(connectionString));

            builder.Services.AddScoped<UnitOfWork,EFUnitOfWork>();

            builder.Services.AddControllers();

            builder.Services.AddSwaggerGen();

            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                containerBuilder.RegisterAssemblyTypes(typeof(EFCatalogBrandRepository).Assembly)
                    .AssignableTo<IRepository>()
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

                containerBuilder.RegisterAssemblyTypes(typeof(CatalogBrandAppService).Assembly)
                    .AssignableTo<IService>()
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
