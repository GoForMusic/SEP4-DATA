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
            return await _sensorsDao.GetAllSensorsDataAsync(); // DAO SHOULD RETURN LIST/ARRAY;
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
            return await _sensorsDao.GetSensorDataByDateAsync(startDate, endDate); // Query logic should be in DAO implementation
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
            return await _sensorsDao.GetSensorDataByIdAsync(id); 
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
            return await _sensorsDao.AddSensorsDataAsync(sensors);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<Sensors> RemoveSensorsDataAsync()
    {
        try
        {
            return await _sensorsDao.RemoveAllSensorData();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}