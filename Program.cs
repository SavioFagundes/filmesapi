using Microsoft.EntityFrameworkCore;
using usuario.Data;
using Pomelo.EntityFrameworkCore.MySql;
using usuario.Models;
using Microsoft.AspNetCore.Identity;
using usuario.Services;
using usuario.Profiles;

namespace UsuariosApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var connectionString = builder.Configuration.GetConnectionString("UsuarioConnection");
            builder.Services.AddDbContext<UsuarioDbContext>(opts => {
                opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
            builder.Services.AddIdentity<usuario.Models.Usuario, IdentityRole>()
                .AddEntityFrameworkStores<UsuarioDbContext>()
                .AddDefaultTokenProviders();
            builder.Services.AddScoped<SignInManager<usuario.Models.Usuario>>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped<UsuarioService>();
            builder.Services.AddScoped<TokenService>();

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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
