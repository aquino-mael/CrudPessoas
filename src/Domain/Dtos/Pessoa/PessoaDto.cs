using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Pessoa;

public class PessoaDto
{
    [Required(ErrorMessage = "Nome é um campo obrigatório.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email é um campo obrigatório.")]
    [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "CPF é um campo obrigatório.")]
    [StringLength(14, ErrorMessage = "CPF deve ter um tamanho máximo de {1} caracteres.")]
    public string Cpf { get; set; }
}
