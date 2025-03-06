


namespace Antivirus.Controllers;

using Microsoft.AspNetCore.Mvc;
using Antivirus.Services;
using System.Threading.Tasks;
using Antivirus.Dtos;
using System.Collections.Generic;

[ApiController]
[Route("api/oportunidades")]
public class OportunidadController : ControllerBase {
    private readonly IOportunidadService _service;

    public OportunidadController(IOportunidadService service) {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OportunidadDto>>> GetAll() {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OportunidadDto>> GetById(int id) {
        var oportunidad = await _service.GetByIdAsync(id);
        if (oportunidad == null) return NotFound();
        return Ok(oportunidad);
    }

    [HttpPost]
    public async Task<ActionResult> Create(OportunidadDto oportunidadDto) {
        await _service.AddAsync(oportunidadDto);
        return CreatedAtAction(nameof(GetById), new { id = oportunidadDto.Id }, oportunidadDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, OportunidadDto oportunidadDto) {
        await _service.UpdateAsync(id, oportunidadDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id) {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}