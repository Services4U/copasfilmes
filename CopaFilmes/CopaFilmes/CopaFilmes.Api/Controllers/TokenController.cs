using CopaFilmes.Infrastructure.CrossCutting.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CopaFilmes.Api.Controllers
{
    [Route("token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IOptions<KeysConfig> ChaveConfiguracao;

        public TokenController(IOptions<KeysConfig> chaveConfiguracao)
        {
            ChaveConfiguracao = chaveConfiguracao;
        }

        [HttpPost]
        public IActionResult Create(string username, string password) 
        {
            if (IsValidUserAndPasswordCombination(username, password))
                return new ObjectResult(GenerateToken(username));
            return BadRequest();
        }

        private static bool IsValidUserAndPasswordCombination(string username, string password) =>
            ///Logica do login para validar e gerar Token. Exemplo abaixo: usuario igual a senha gera o token
           !string.IsNullOrEmpty(username) && username == password;

        private string GenerateToken(string username)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
            };

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    //the secret that needs to be at least 16 characters long for HmacSha256
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ChaveConfiguracao.Value.SecretKey)),
                                             SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}