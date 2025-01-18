using Category.Domain.CommanInterfaces;
using Category.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Category.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<CatalogDbContext>(options =>
                    options.UseSqlServer(connectionString));

            builder.Services.AddSingleton<UnitOfWork,EFUnitOfWork>();

            builder.Services.AddControllers();

            var app = builder.Build();


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
