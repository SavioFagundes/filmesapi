using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using usuario.Data.Dtos;
using usuario.Models;
using AutoMapper;

namespace usuario.Services
{
    public class UsuarioService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Models.Usuario> _userManager;
        private readonly SignInManager<Models.Usuario> _signInManager;
        private readonly TokenService _tokenService;
 
        public UsuarioService(IMapper mapper, UserManager<Models.Usuario> userManager, SignInManager<Models.Usuario> signInManager, TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task Cadastra(CreateUsuarioDto dto)
        {
            Models.Usuario usuario = _mapper.Map<Models.Usuario>(dto);
            var resultado = await _userManager.CreateAsync(usuario, dto.Password);
            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Erro ao cadastrar usuário");
            }
        }

        public async Task<string> Login(LoginUsuarioDto dto)
        {
            var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);
            if (!resultado.Succeeded)
                throw new ApplicationException("Usuário ou senha inválidos"
                );

            var usuario = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());
            var token = _tokenService.GenerateToken(usuario);
            return token;
        }
    }
} 