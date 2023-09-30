using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Datas.Dtos;
using UsuariosAPI.Models;

namespace UsuariosAPI.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{
    private IMapper _mapper;
    private UserManager<Usuario> _userManager;

    public UsuarioController(IMapper mapper, UserManager<Usuario> userManager = null)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    [HttpPost]
    public async IActionResult CadastraUsuario(CreateUsuarioDTO dto)
    {
        Usuario usuario = _mapper.Map<Usuario>(dto);
        IdentityResult result = await _userManager.CreateAsync(usuario, dto.Password);

        
    }
}
