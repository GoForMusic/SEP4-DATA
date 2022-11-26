using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCDataBase.DAOImpl.CO2;

public class CO2DAO : ICO2DAO
{

    private readonly DBContext database;

    public async Task<Sensors> GetCO2Async(string id)
    {
        return await database.Sensors.FirstAsync(t => t.Co2.Equals(id));
    }

    public async Task DeleteCO2Async(string id)
    {
        Sensors sensor = await database.Sensors.FirstAsync(s => s.Id.Equals(id));
        if (sensor is null)
        {
            throw new Exception("ERROR:  Sensor does not exist");
        }
        database.Sensors.Remove(sensor);
        await database.SaveChangesAsync();
        
    }

    public async Task UpdateCO2Async(Sensors sensor)
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
        catch(Exception e)
        {
            Console.WriteLine(e+" "+ e.StackTrace);
        }

        return sensor;
    }
}