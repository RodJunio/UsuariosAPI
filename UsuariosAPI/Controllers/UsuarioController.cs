using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Datas.Dtos;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioService _usuarioService;

    public UsuarioController(UsuarioService cadastroService)
    {
        _usuarioService = cadastroService;
    }

    [HttpPost]
    public async Task<IActionResult> CadastraUsuario(CreateUsuarioDTO dto)
    {
        await _usuarioService.Cadastrar(dto);

        return Ok("Usuário Cadastrado!");
    }

    [HttpPost]
    public async Task<IActionResult> LoginAsync(LoginUsuarioDto dto)
    {
        await _usuarioService.Login(dto);

        return Ok("Usuário Autenticado!");
    }
}
