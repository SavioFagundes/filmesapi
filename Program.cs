using Microsoft.EntityFrameworkCore;
using usuario.Data;
using Pomelo.EntityFrameworkCore.MySql;
using usuario.Models;
using Microsoft.AspNetCore.Identity;
using usuario.Services;
using usuario.Profiles;
using Microsoft.AspNetCore.Authorization;
using usuario.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace UsuariosApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var connectionString = builder.Configuration["SymmetricSecurityKey:UsuarioConnection"];
            builder.Services.AddDbContext<UsuarioDbContext>(opts => {
                opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
            builder.Services.AddIdentity<usuario.Models.Usuario, IdentityRole>()
                .AddEntityFrameworkStores<UsuarioDbContext>()
                .AddDefaultTokenProviders();
            builder.Services.AddScoped<SignInManager<usuario.Models.Usuario>>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddAuthorization(options =>{options.AddPolicy("IdadeMinima", policy => policy.AddRequirements(new IdadeMinima(18)));});
            builder.Services.AddSingleton<IAuthorizationHandler, IdadeAuthorization>();
            builder.Services.AddScoped<UsuarioService>();
            builder.Services.AddScoped<TokenService>();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SymmetricSecurityKey"])),
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
