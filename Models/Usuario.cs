using Microsoft.AspNetCore.Identity;

namespace usuario.Models
{
    public class Usuario : IdentityUser
    {
        public DateTime DataNascimento { get; set; }
        public Usuario() : base()
        {

        }
    }
}
