using AutoMapper;
using UsuariosAPI.Datas.Dtos;
using UsuariosAPI.Models;

namespace UsuariosAPI.Profiles;

public class UsuarioProdile : Profile
{
    public UsuarioProdile()
    {
        CreateMap<CreateUsuarioDTO, Usuario>();
    }
}
