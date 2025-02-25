


namespace Antivirus.Controllers;

using Microsoft.AspNetCore.Mvc;
using Antivirus.Services;
using System.Security.Cryptography;
using System.Text;
using Antivirus.Dtos;
using Antivirus.Mappers;
using Antivirus.Models;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;



[ApiController]
[Route("api/[controller]")]
public class InstitucionController : ControllerBase
{
    private readonly IInstitucionService _service;

    public InstitucionController(IInstitucionService service)
    {
        _service = service;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        var instituciones = await _service.GetAllAsync();
        return Ok(instituciones);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id)
    {
        var institucion = await _service.GetByIdAsync(id);
        if (institucion == null)
            return NotFound();
        return Ok(institucion);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] InstitucionDto institucionDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdInstitucion = await _service.AddAsync(institucionDto);
        return CreatedAtAction(nameof(GetById), new { id = createdInstitucion.Id }, createdInstitucion);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id, [FromBody] InstitucionDto institucionDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updatedInstitucion = await _service.UpdateAsync(id, institucionDto);
        if (updatedInstitucion == null)
            return NotFound();

        return Ok(updatedInstitucion);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
