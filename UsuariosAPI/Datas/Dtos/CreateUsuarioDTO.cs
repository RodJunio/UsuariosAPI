﻿using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Datas.Dtos;

public class CreateUsuarioDTO
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public DateTime DataNascimento { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [Compare("Password")]
    public string PasswordConfirmation { get; set; }
}
