
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RepositoryNetAPI.Data;
using RepositoryNetAPI.Repositories.EF;
using RepositoryNetAPI.Repositories.Interfaces;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace RepositoryNetAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))); // initialise DB Context
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); // Register Repository

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Authentication
            // JWT Authenticaton
            /*
             * dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
             * dotnet add package Microsoft.IdentityModel.Tokens
             * dotnet add package System.IdentityModel.Tokens.Jwt
             */

            var jwtKey = builder.Configuration["Jwt:Key"]; 
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));


            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            builder.Services.AddAuthorization();
            #endregion Authentication


            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
