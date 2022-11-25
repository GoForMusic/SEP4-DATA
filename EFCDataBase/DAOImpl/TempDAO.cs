using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCDataBase.DAOImpl;

public class TempDAO : ITempDAO
{

    private readonly DBContext database;

    public TempDAO(DBContext database)
    {
        this.database = database;
    }

    public async Task<Sensors> GetTemperatureAsync(string id)
    {
        return await database.Sensors.FirstAsync(t => t.Id.Equals(id));
    }

    public async Task DeleteTemperatureAsync(string id)
    {
        Sensors? sensor = await database.Sensors.FirstAsync(se => se.Id.Equals(id));
        if (sensor is null)
        {
            throw new Exception("ERROR:  Sensor does not exist");
        }

        database.Sensors.Remove(sensor);
        await database.SaveChangesAsync();
    }

    public async Task UpdateTemperatureAsync(Sensors sensor)
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
}