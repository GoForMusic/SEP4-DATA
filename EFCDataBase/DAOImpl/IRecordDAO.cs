using Entity;

namespace EFCDataBase.DAOImpl;

public interface IRecordDAO
{
    Task<List<Record>> GetRecordAsync();
    Task<Record> GetRecordAsync(string id);
    Task DeleteRecordAsync(string id);
    Task UpdateRecordAsync(Record record);
    Task<Record> AddRecordAsync(Record record);
    Task<ICollection<Record>> GetRecordDataByDateAsync(DateTime startDate, DateTime endDate);
}