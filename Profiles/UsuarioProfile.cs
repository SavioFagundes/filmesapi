using AutoMapper;
using usuario.Data.Dtos;
using usuario.Models;

namespace usuario.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
            
        }
    }
}
