using Entity;
using Entity.RestFilter;

namespace EFCDataBase.DAOImpl;

public interface IRecordDAO
{
    Task<List<Record>> GetRecordsAsync(RecordFilter recordFilter);
    Task<Record> GetRecordAsync(string id);
    Task DeleteRecordAsync(string id);
    Task UpdateRecordAsync(Record record);
    Task<Record> AddRecordAsync(Record record);
    Task<ICollection<Record>> GetRecordDataByDateAsync(DateTime startDate, DateTime endDate);
}