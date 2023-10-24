using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Datas.Dtos;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services;

public class UsuarioService
{
    private IMapper _mapper;
    private UserManager<Usuario> _userManager;
    private SignInManager<Usuario> _signInManager;

    public UsuarioService(IMapper mapper,
        UserManager<Usuario> userManager,
        SignInManager<Usuario> signInManager)
    {
        _userManager = userManager;
        _mapper = mapper;
        _signInManager = signInManager;
    }

    public async Task Cadastrar(CreateUsuarioDTO dto)
    {
        Usuario usuario = _mapper.Map<Usuario>(dto);
        IdentityResult result = await _userManager.CreateAsync(usuario, dto.Password);

        if (!result.Succeeded)        
            throw new ApplicationException("Falha ao cadastrar usuário");
        
    }

    public async Task Login(LoginUsuarioDto dto)
    {
       var resultado =  await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

        if (!resultado.Succeeded) throw new ApplicationException("Usuario não autenticado");
    }
}
