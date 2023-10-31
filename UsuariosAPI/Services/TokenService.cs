using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services;

public class TokenService
{
    public string GenerateToken(Usuario usuario)
    {
        Claim[] claims = new Claim[]
        {
            new Claim("username", usuario.UserName),
            new Claim("id", usuario.Id),
            new Claim(ClaimTypes.DateOfBirth, usuario.DataNascimento.ToString()),
            new Claim("loginTimestamp", DateTime.UtcNow.ToString())
        };

        // Gera uma chave de 256 bits (32 bytes) aleatória
        byte[] keyBytes = new byte[32];
        new Random().NextBytes(keyBytes);
        // Converte os bytes em uma string base64 para uso como chave
        string key = Convert.ToBase64String(keyBytes);

        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

        var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(expires: DateTime.Now.AddMinutes(10),
            claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}