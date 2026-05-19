using Microsoft.AspNetCore.Mvc;
using PJATK_APBD_Cw7_s33103.DTOs;
using PJATK_APBD_Cw7_s33103.Exceptions;
using PJATK_APBD_Cw7_s33103.Service;

namespace PJATK_APBD_Cw7_s33103.Controllers;


[ApiController]
[Route("api/[controller]")]
public class PcsController(IPcService pcService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPcs(CancellationToken cancellationToken)
    {
        var pcs = await pcService.GetPcsAsync(cancellationToken);
        return Ok(pcs);
    }

    [HttpGet("{id:int}/components")]
    public async Task<IActionResult> GetPcComponents([FromRoute] int id, CancellationToken cancellationToken)
    {
        try
        {
            var pcWithComponents = await pcService.GetPcComponentsAsync(id, cancellationToken);
            return Ok(pcWithComponents);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddPc([FromBody] CreateUpdatePcDto dto, CancellationToken cancellationToken)
    {
        var createdPc = await pcService.AddPcAsync(dto, cancellationToken);
    
        return CreatedAtAction(nameof(GetPcComponents), new { id = createdPc.Id }, createdPc);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdatePc([FromRoute] int id, [FromBody] CreateUpdatePcDto dto, CancellationToken cancellationToken)
    {
        try
        {
            await pcService.UpdatePcAsync(id, dto, cancellationToken);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePc([FromRoute] int id, CancellationToken cancellationToken)
    {
        try
        {
            await pcService.DeletePcAsync(id, cancellationToken);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}