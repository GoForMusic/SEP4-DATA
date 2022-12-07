using Entity;

namespace Services.Interfaces;

public interface IRecordService
{
    Task<ICollection<Record>> GetAllRecordDataAsync(Filter filter);
    Task<ICollection<Record>> GetRecordDataByDate(DateTime startDate, DateTime endDate);
    Task<Record> GetRecordDataByIdAsync(string id);
    Task<Record> AddRecordDataAsync(Record record);
    Task RemoveRecordDataAsync(string id);
    
}