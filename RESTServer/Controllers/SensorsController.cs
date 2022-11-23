using Entity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class SensorsController : ControllerBase
{
    private ISensorsService _sensorsService;

    public SensorsController(ISensorsService sensorsService)
    {
        _sensorsService = sensorsService;
    }

        [HttpGet]
        [Route("/all")]
        public async Task<ActionResult<ICollection<Sensors>>> GetAllSensorsDataAsync()
        {
            try
            {
                ICollection<Sensors> sensors = await _sensorsService.GetAllSensorsDataAsync();
                return Ok(sensors);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("/all/date")]
        public async Task<ActionResult<ICollection<Sensors>>> GetSensorDataByDate([FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate)
        {
            try
            {
                ICollection<Sensors> sensors = await _sensorsService.GetSensorDataByDate(startDate, endDate);
                return Ok(sensors);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("/get/{id}")]
        public async Task<ActionResult<Sensors>> GetSensorsDataByIdAsync([FromRoute] string id)
        {
            try
            {
                Sensors sensors = await _sensorsService.GetSensorsDataByIdAsync(id);
                return Ok(sensors);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Sensors>> AddSensorsDataAsync([FromBody] Sensors sensors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Sensors localSensors = await _sensorsService.AddSensorsDataAsync(sensors);
                return Created($"/{localSensors.Id}", localSensors);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete]
        [Route("/delete/{id}")]
        public async Task<ActionResult<Sensors>> RemoveSensorsDataAsync([FromRoute] string id) {
            try {
                await _sensorsService.RemoveSensorsDataAsync(id);
                return Ok();
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
