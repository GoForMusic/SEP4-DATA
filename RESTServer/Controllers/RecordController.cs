using Entity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class RecordController : ControllerBase
{
    private IRecordService _recordService;

    public RecordController(IRecordService recordService)
    {
        _recordService = recordService;
    }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<ICollection<Record>>> GetAllRecordDataAsync([FromQuery]Filter filter)
        {
            try
            {
                ICollection<Record> record = await _recordService.GetAllRecordDataAsync(filter);
                return Ok(record);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("all/date")]
        public async Task<ActionResult<ICollection<Record>>> GetRecordDataByDate([FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate)
        {
            try
            {
                ICollection<Record> record = await _recordService.GetRecordDataByDate(startDate, endDate);
                return Ok(record);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Record>> GetRecordDataByIdAsync([FromRoute] string id)
        {
            try
            {
                Record record = await _recordService.GetRecordDataByIdAsync(id);
                return Ok(record);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        

        [HttpPost]
        public async Task<ActionResult<Record>> AddSensorsDataAsync([FromBody] Record record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Record localRecord = await _recordService.AddRecordDataAsync(record);
                return Created($"/{localRecord.Id}", localRecord);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Record>> RemoveSensorsDataAsync([FromRoute] string id) {
            try {
                await _recordService.RemoveRecordDataAsync(id);
                return Ok();
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
