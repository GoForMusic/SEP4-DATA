using Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Services;

public interface ISensorsService
{
    Task<ICollection<Sensors>> GetAllSensorsDataAsync();
    Task<ICollection<Sensors>> GetSensorDataByDate(DateTime startDate, DateTime endDate);
    Task<Sensors> GetSensorsDataByIdAsync(string id);
    Task<Sensors> AddSensorsDataAsync(Sensors sensors);
    Task<Sensors> RemoveSensorsDataAsync();
}