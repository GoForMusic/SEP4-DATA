using EFCDataBase.DAOImpl;
using Entity;
using Services.Interfaces;

namespace Services.Implementations;

public class RecordService : IRecordService
{
    private IRecordDAO _recordDao; 
    
    public RecordService(IRecordDAO recordDao)
    {
        _recordDao = recordDao;
    }
    
    public async Task<ICollection<Record>> GetAllRecordDataAsync(Filter filter)
    {
        try
        {
            return await _recordDao.GetRecordsAsync(filter);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<ICollection<Record>> GetRecordDataByDate(DateTime startDate, DateTime endDate)
    {
        try
        {
            return await _recordDao.GetRecordDataByDateAsync(startDate, endDate);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    
    public async Task<Record> GetRecordDataByIdAsync(string id)
    {
        try
        {
            return await _recordDao.GetRecordAsync(id);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<Record> AddRecordDataAsync(Record record)
    {
        try
        {
            record.DewPt = await CalculateDewPt(record.Temperature, record.Humidity);
            return await _recordDao.AddRecordAsync(record);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task RemoveRecordDataAsync(string id)
    {
        try
        {
            await _recordDao.DeleteRecordAsync(id);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    private async Task<float> CalculateDewPt(float temperature, float relativeHumidity)
    {
        temperature = (temperature - 32) / 1.8f;
        float a = 17.625f;
        float b = 243.04f;
        double alfa = Math.Log(relativeHumidity / 100) + (a * temperature / (b + temperature));
        double result = (b * alfa) / (a - alfa);
        double value = result*(9.0/5.0);

        return (float) value + 32;
    }
}