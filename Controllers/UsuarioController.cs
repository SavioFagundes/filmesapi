using Microsoft.AspNetCore.Mvc;
using usuario.Data.Dtos;
using System;
using AutoMapper;
using usuario.Models;
using Microsoft.AspNetCore.Identity;
using usuario.Services;
using System.Threading.Tasks;

namespace usuario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {

        private CadastroService _cadastroService;

        public UsuarioController(CadastroService cadastroService)
        {

            _cadastroService = cadastroService;
        }
        [HttpPost]
        public async Task<IActionResult> CadastrarUsuario(CreateUsuarioDto dto)
        {
            await _cadastroService.Cadastra(dto);
            return Ok("Usuario cadastrado com sucesso");
        }
        }
    }
