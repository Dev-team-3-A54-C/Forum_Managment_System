using AutoMapper;
using ForumManagmentSystem.Core.Helpers;
using ForumManagmentSystem.Core.Helpers.MappingConfig;
using ForumManagmentSystem.Core.Services;
using ForumManagmentSystem.Core.Services.Contracts;
using ForumManagmentSystem.Infrastructure.Data;
using ForumManagmentSystem.Infrastructure.Repositories;
using ForumManagmentSystem.Infrastructure.Repositories.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace ForumManagmentSystem.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            //Repositories
            builder.Services.AddScoped<IUsersRepository, UsersRepository>();
            builder.Services.AddScoped<IPostsRepository, PostRepository>();
            builder.Services.AddScoped<IReplyRepository, ReplyRepository>();
            builder.Services.AddScoped<ITagRepository, TagRepository>();
            //Services
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IPostService, PostService>();
            builder.Services.AddScoped<IReplyService, ReplyService>();
            builder.Services.AddScoped<ITagService, TagService>();

            builder.Services.AddScoped<IModelMapper, ModelMapper>();
            builder.Services.AddScoped<AuthManager>();

            //Solution 1 for AutoMapper
            //builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            //Solution 2 for AutoMapper
            builder.Services.AddAutoMapper(typeof(Program));
            AutoMapper.IConfigurationProvider cfg = new MapperConfiguration(cfg => { cfg.AddProfile<MapperProfiles>(); });
            builder.Services.AddSingleton(cfg);

            builder.Services.AddSwaggerGen();

            //builder.Services.AddHttpContextAccessor();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            builder.Services.AddDbContext<FMSContext>(options =>
            {
                // A connection string for establishing a connection to the locally installed SQL Server.
                // Set serverName to your local instance; databaseName is the name of the database
                string connectionString = @"Server=localhost\SQLEXPRESS;Database=ForumManagementSystem;Trusted_Connection=True;";
                //string connectionString = @"Server=localhost;Database=ForumManagementSystem;Trusted_Connection=True;";
                // Configure the application to use the locally installed SQL Server.
                options.UseSqlServer(connectionString);
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
            });

            builder.Services.AddControllersWithViews();
			builder.Services.AddSession(options =>
			{
				options.IdleTimeout = TimeSpan.FromHours(2);
				options.Cookie.HttpOnly = true;
				options.Cookie.IsEssential = true;
			});

			var app = builder.Build();
			app.UseSession();
			app.UseRouting();
            app.UseStaticFiles();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            app.Run();
        }
    }
}
