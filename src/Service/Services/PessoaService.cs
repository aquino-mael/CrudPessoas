using AutoMapper;
using Domain.Dtos.Pessoa;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.Users;
using Domain.Models;

namespace Service.Services;

public class PessoaService : IPessoaService
{
    private IRepository<PessoaEntity> _repository;

    private readonly IMapper _mapper;

    public PessoaService(IRepository<PessoaEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<PessoaDtoResult?> Get(Guid id)
    {
        var entity = await _repository.SelectAsync(id);

        if (entity == null)
        {
            return null;
        }

        return _mapper.Map<PessoaDtoResult>(entity);
    }

    public async Task<IEnumerable<PessoaDtoResult>?> GetAll()
    {
        var entities = await _repository.SelectAsync();

        if (entities == null)
        {
            return null;
        }

        return _mapper.Map<IEnumerable<PessoaDtoResult>>(entities);
    }

    public async Task<PessoaCreateResultDto?> Post(PessoaDto pessoa)
    {
        var model = _mapper.Map<PessoaModel>(pessoa);

        var entity = _mapper.Map<PessoaEntity>(model);
        
        var result = await _repository.InsertAsync(entity);

        return _mapper.Map<PessoaCreateResultDto>(result);
    }

    public async Task<PessoaUpdateResultDto?> Put(PessoaUpdateDto pessoa)
    {
        var model = _mapper.Map<PessoaModel>(pessoa);

        var entity = _mapper.Map<PessoaEntity>(model);
        
        var result = await _repository.UpdateAsync(entity);

        if (result == null)
        {
            return null;
        }

        return _mapper.Map<PessoaUpdateResultDto>(result);
    }

    public async Task<bool> Delete(Guid id)
    {
        return await _repository.DeleteAsync(id);
    }
}