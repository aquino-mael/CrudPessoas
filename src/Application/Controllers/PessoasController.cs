using System.Net;
using Domain.Dtos.Pessoa;
using Domain.Entities;
using Domain.Interfaces.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PessoasController : ControllerBase
{
    private readonly IPessoaService _service;

    public PessoasController(IPessoaService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            return Ok(await _service.GetAll());
        }
        catch (ArgumentException ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpGet]
    [Route("{id}", Name = "getWithId")]
    public async Task<ActionResult> GetById(Guid id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var pessoa = await _service.Get(id);

            if (pessoa == null)
            {
                return NotFound("Pessoa não encontrada na base dado");
            }

            return Ok();
        }
        catch (ArgumentException ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] PessoaDto pessoa)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            return Ok(await _service.Post(pessoa));
        }
        catch (ArgumentException ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] PessoaUpdateDto pessoa)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var updated = await _service.Put(pessoa);

            if (updated == null)
            {
                return NotFound("Não foi possível atualizar as informações desta pessoa!");
            }

            return Ok(updated);
        }
        catch (ArgumentException ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(Guid id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            return Ok(await _service.Delete(id) ? "Deletado com sucesso!" : "Não foi possível realizar a exclusão.");
        }
        catch (ArgumentException ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}