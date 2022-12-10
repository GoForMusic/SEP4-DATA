using Entity;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Controllers;

[ApiController]
[Route("/api/v1/[controller]")]

public class PresetController : ControllerBase
{
    private IBoxService _boxService;

    public PresetController(IBoxService boxService)
    {
        _boxService = boxService;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<Preset>>> GetAllPresetsAsync()
    {
        try
        {
            ICollection<Preset> presets = await _boxService.GetPresets();
            return Ok(presets);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    

    [HttpPost]
    public async Task<ActionResult<Box>> AddBox([FromBody] Preset preset)
    {
        try
        {
            Preset newPreset = await _boxService.AddPreset(preset);
            return Ok(newPreset);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}