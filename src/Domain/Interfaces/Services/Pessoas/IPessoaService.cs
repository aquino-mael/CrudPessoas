using Domain.Dtos.Pessoa;

namespace Domain.Interfaces.Services.Users;

public interface IPessoaService
{
    Task<PessoaDtoResult?> Get(Guid id);
    Task<IEnumerable<PessoaDtoResult>?> GetAll();
    Task<PessoaCreateResultDto?> Post(PessoaDto pessoa);
    Task<PessoaUpdateResultDto?> Put(PessoaUpdateDto pessoa);
    Task<bool> Delete(Guid id);
}