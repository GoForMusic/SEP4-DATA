using EFCDataBase.DAOImpl;
using Entity;
using Entity.RestFilter;

namespace WebApplication1.Services;

public class RecordService : IRecordService
{
    private IRecordDAO _recordDao; 
    
    public RecordService(IRecordDAO recordDao)
    {
        _recordDao = recordDao;
    }
    
    public async Task<ICollection<Record>> GetAllRecordsDataAsync(RecordFilter recordFilter)
    {
        try
        {
            return await _recordDao.GetRecordsAsync(recordFilter);
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
}