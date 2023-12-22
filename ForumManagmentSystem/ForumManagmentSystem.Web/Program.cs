using ForumManagmentSystem.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace ForumManagmentSystem.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<IUserService, UserService>();
            var app = builder.Build();
            app.MapGet("/", () => "Home Page");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
            */

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<IUserService, UserService>();

           // builder.Services.AddScoped<ModelMapper>();

            builder.Services.AddControllers();

            var app = builder.Build();

            app.MapControllers();

            app.Run();
        }
    }
 }
