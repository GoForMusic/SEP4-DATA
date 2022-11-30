using EFCDataBase.Queryable;
using Entity;
using Entity.RestFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCDataBase.DAOImpl;

public class RecordDAO : IRecordDAO
{

    private readonly DBContext database;

    public RecordDAO(DBContext database)
    {
        this.database = database;
    }

    public async Task<Record> GetRecordAsync(string id)
    {
        return await database.Record.FirstAsync(t => t.Id.Equals(id));
    }

    public async Task<List<Record>> GetRecordsAsync(RecordFilter recordFilter)
    {
        var queryable = database.Record.AsQueryable();

        queryable = RecordQueryable.AddFilltersOnQuery(recordFilter, queryable);
        
        return await queryable.ToListAsync();
    }
    
    public async Task DeleteRecordAsync(string id)
    {
        Record? record = await database.Record.FirstAsync(se => se.Id.Equals(id));
        if (record is null)
        {
            throw new Exception("ERROR:  Record does not exist");
        }

        database.Record.Remove(record);
        await database.SaveChangesAsync();
    }

    public async Task UpdateRecordAsync(Record record)
    {
        database.Record.Update(record);
        await database.SaveChangesAsync();
    }

    public async Task<Record> AddRecordAsync(Record record)
    {
        try
        {
            EntityEntry<Record> newSensor = await database.Record.AddAsync(record);
            await database.SaveChangesAsync();
            return newSensor.Entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e+" "+ e.StackTrace);
        }

        return record;
    }

    public Task<ICollection<Record>> GetRecordDataByDateAsync(DateTime startDate, DateTime endDate)
    {
        throw new NotImplementedException();
    }
}
