using Entity;
namespace WebApplication1.Services;

public class SensorsService : ISensorsService
{
    //private ISensorsDAO _sensorsDao; 
    
    public SensorsService()
    {
        //_sensorsDao = sensorsDao;
    }
    
    public async Task<ICollection<Sensors>> GetAllSensorsDataAsync()
    {
        try
        {
            return null; //await _sensorsDao.GetAllSensorsDataAsync(); // DAO SHOULD RETURN LIST/ARRAY;
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
            return
                null; //await _sensorsDao.GetSensorDataByDateAsync(startDate, endDate); // Query logic should be in DAO implementation
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
            return null; //await _sensorsDao.GetSensorDataByIdAsync(id); 
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
            return null; //await _sensorsDao.AddSensorsDataAsync(sensors);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<Sensors> RemoveSensorsDataAsync(string id)
    {
        try
        {
            return null; //await _sensorsDao.RemoveSensorData(id);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}