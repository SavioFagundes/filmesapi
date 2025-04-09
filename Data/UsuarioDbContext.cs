using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using usuario.Models;

namespace usuario.Data
{
    public class UsuarioDbContext : IdentityDbContext<Models.Usuario>
    {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> opts) : base(opts)
        {
            
        }
    }
}
