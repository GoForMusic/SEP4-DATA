using EFCDataBase.DAOImpl;
using Entity;
namespace WebApplication1.Services;

public class SensorsService : ISensorsService
{
    private ISensorsDAO _sensorsDao; 
    
    public SensorsService(ISensorsDAO sensorsDao)
    {
        _sensorsDao = sensorsDao;
    }
    
    public async Task<ICollection<Sensors>> GetAllSensorsDataAsync()
    {
        try
        {
            return await _sensorsDao.GetSensorsAsync();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<ICollection<Sensors>> GetSensorDataByDate(DateTime startDate, DateTime endDate)
    {
        try
        {
            return await _sensorsDao.GetSensorDataByDateAsync(startDate, endDate);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    
    public async Task<Sensors> GetSensorsDataByIdAsync(string id)
    {
        try
        {
            return await _sensorsDao.GetSensorAsync(id);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<Sensors> AddSensorsDataAsync(Sensors sensors)
    {
        try
        {
            return await _sensorsDao.AddSensorAsync(sensors);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task RemoveSensorsDataAsync(string id)
    {
        try
        {
            await _sensorsDao.DeleteSensorAsync(id);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}