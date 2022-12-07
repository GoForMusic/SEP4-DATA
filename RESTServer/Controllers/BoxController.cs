using Entity;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Controllers;

[ApiController]
[Route("/api/v1/[controller]")]

public class BoxController : ControllerBase
{
    private IBoxService _boxService;

    public BoxController(IBoxService boxService)
    {
        _boxService = boxService;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Box>> GetBox([FromRoute] string id)
    {
        try
        {
            Box box = await _boxService.GetBoxAsync(id);
            return Ok(box);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Box>> AddBox([FromBody] Box box)
    {
        try
        {
            Box newBox = await _boxService.AddBoxAsync(box);
            return Ok(newBox);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<User>> DeleteBox([FromRoute] string id)
    {
        try
        {
            await _boxService.DeleteBoxAsync(id);
            return Ok(id);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPatch]
    public async Task<ActionResult> UpdateBox([FromBody] Box box)
    {
        try
        {
            await _boxService.UpdateBoxAsync(box);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
}