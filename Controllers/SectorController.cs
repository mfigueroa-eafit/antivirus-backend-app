namespace Antivirus.Controllers;

using Microsoft.AspNetCore.Mvc;
using Antivirus.Services;
using System.Threading.Tasks;
using Antivirus.Dtos;

[ApiController]
[Route("api/[controller]")]
public class SectorController : ControllerBase
{
    private readonly ISectorService _service;

    public SectorController(ISectorService service)
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
    public async Task<IActionResult> Create([FromBody] SectorDto sectorDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await _service.AddAsync(sectorDto);
        return CreatedAtAction(nameof(GetById), new { id = sectorDto.Id }, sectorDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] SectorDto sectorDto)
    {
        if (id != sectorDto.Id) return BadRequest();
        await _service.UpdateAsync(sectorDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
