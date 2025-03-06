namespace Antivirus.Controllers;

using Microsoft.AspNetCore.Mvc;
using Antivirus.Services;
using System.Threading.Tasks;
using Antivirus.Dtos;

[ApiController]
[Route("api/[controller]")]
public class TipoOportunidadController : ControllerBase
{
    private readonly ITipoOportunidadService _service;

    public TipoOportunidadController(ITipoOportunidadService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tipos = await _service.GetAllAsync();
        return Ok(tipos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var tipo = await _service.GetByIdAsync(id);
        if (tipo == null) return NotFound();
        return Ok(tipo);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TipoOportunidadDto tipoOportunidadDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await _service.AddAsync(tipoOportunidadDto);
        return CreatedAtAction(nameof(GetById), new { id = tipoOportunidadDto.Id }, tipoOportunidadDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] TipoOportunidadDto tipoOportunidadDto)
    {
        if (id != tipoOportunidadDto.Id) return BadRequest();
        await _service.UpdateAsync(tipoOportunidadDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
