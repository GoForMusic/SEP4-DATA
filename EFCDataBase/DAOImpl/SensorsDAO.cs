using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCDataBase.DAOImpl;

public class SensorsDAO : ISensorsDAO
{

    private readonly DBContext database;

    public SensorsDAO(DBContext database)
    {
        this.database = database;
    }

    public async Task<Sensors> GetSensorAsync(string id)
    {
        return await database.Sensors.FirstAsync(t => t.Id.Equals(id));
    }

    public async Task<List<Sensors>> GetSensorsAsync()
    {
        return await database.Sensors.ToListAsync();
    }
    
    public async Task DeleteSensorAsync(string id)
    {
        Sensors? sensor = await database.Sensors.FirstAsync(se => se.Id.Equals(id));
        if (sensor is null)
        {
            throw new Exception("ERROR:  Sensor does not exist");
        }

        database.Sensors.Remove(sensor);
        await database.SaveChangesAsync();
    }

    public async Task UpdateSensorAsync(Sensors sensor)
    {
        database.Sensors.Update(sensor);
        await database.SaveChangesAsync();
    }

    public async Task<Sensors> AddSensorAsync(Sensors sensor)
    {
        try
        {
            EntityEntry<Sensors> newSensor = await database.Sensors.AddAsync(sensor);
            await database.SaveChangesAsync();
            return newSensor.Entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e+" "+ e.StackTrace);
        }

        return sensor;
    }

    public Task<ICollection<Sensors>> GetSensorDataByDateAsync(DateTime startDate, DateTime endDate)
    {
        throw new NotImplementedException();
    }
}