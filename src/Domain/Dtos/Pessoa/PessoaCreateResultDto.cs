﻿namespace Domain.Dtos.Pessoa;

public class PessoaCreateResultDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Cpf { get; set; }
    public DateTime CreatedAt { get; set; }
}