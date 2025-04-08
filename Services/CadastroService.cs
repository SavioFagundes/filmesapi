using usuario.Data.Dtos;
using usuario.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace usuario.Services
{
    public class CadastroService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Usuario> _userManager;

        public CadastroService(IMapper mapper, UserManager<Usuario> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task Cadastra(CreateUsuarioDto dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);
            var resultado = await _userManager.CreateAsync(usuario, dto.Password);
            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Erro ao cadastrar usuário");
            }
        }
    }
}


