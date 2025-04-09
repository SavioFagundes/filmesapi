using Microsoft.AspNetCore.Mvc;
using usuario.Data.Dtos;
using System;
using AutoMapper;
using usuario.Models;
using Microsoft.AspNetCore.Identity;
using usuario.Services;
using System.Threading.Tasks;

namespace Usuario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {

        private UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {

            _usuarioService = usuarioService;
        }
        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)
        {
            await _usuarioService.Cadastra(dto);
            return Ok("Usuario cadastrado com sucesso");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUsuarioDto dto)
        {
            var token = await _usuarioService.Login(dto);
            return Ok(token);
        }
    }
}
