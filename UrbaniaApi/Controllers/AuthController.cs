using System;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using UrbaniaApi.Data;
using UrbaniaApi.Dtos;
using UrbaniaApi.Models;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;

namespace UrbaniaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IauthRepositorio _repo { get; }
        public IConfiguration _config { get; }
       

        public AuthController(IauthRepositorio repo, IConfiguration config )//, IMapper mapper)
        {
           // _mapper = mapper;
            _config = config;
            _repo = repo;

        }

        [HttpPost("Registro")]

        public async Task<IActionResult> Registrar(UsuarioRegistro usuarioRegistro)
        {

            usuarioRegistro.UserName = usuarioRegistro.UserName.ToLower();

            if (await _repo.ExisteUsuario(usuarioRegistro.UserName))
                return BadRequest("Ya existe nombre de Usuario");
            var CrearUsuario = new Usuario
            {
                    UserName = usuarioRegistro.UserName
            };

            var usuarioCreado = await _repo.Registro(CrearUsuario, usuarioRegistro.Password);


            return NoContent();

        }

        [HttpPost("Login")]

        public async Task<IActionResult> Login(UsuarioLogin usuariologin)
        {
            var usuariorepo = await _repo.Login(usuariologin.Username.ToLower(), usuariologin.Password);
            if (usuariorepo == null)
            {
                return Unauthorized();
            }
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier , usuariorepo.Id.ToString()),
                new Claim(ClaimTypes.Name, usuariorepo.UserName)
                };

            var key = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(_config.GetSection("AppSettings:token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenhandler = new JwtSecurityTokenHandler();

            var token = tokenhandler.CreateToken(tokenDescriptor);
            return Ok(new
            {
                token = tokenhandler.WriteToken(token),
            });
        }
    }
}