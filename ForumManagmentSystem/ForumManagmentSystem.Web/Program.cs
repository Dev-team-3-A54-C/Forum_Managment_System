using ForumManagmentSystem.Core.Services;
using ForumManagmentSystem.Infrastructure.Data;
using ForumManagmentSystem.Infrastructure.Repositories;
using ForumManagmentSystem.Infrastructure.Repositories.Contracts;
using ForumManagmentSystem.Web.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace ForumManagmentSystem.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IUsersRepository, UsersRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddDbContext<FMSContext>(options =>
            {
                // A connection string for establishing a connection to the locally installed SQL Server.
                // Set serverName to your local instance; databaseName is the name of the database
                //string connectionString = @"Server=localhost\SQLEXPRESS;Database=ForumManagementSystem;Trusted_Connection=True;";
                string connectionString = @"Server=localhost;Database=ForumManagementSystem;Trusted_Connection=True;";
                // Configure the application to use the locally installed SQL Server.
                options.UseSqlServer(connectionString);
                options.EnableSensitiveDataLogging();
            });

            builder.Services.AddControllers();

            var app = builder.Build();

            //app.MapConnections();

            app.Run();
        }
    }
}
