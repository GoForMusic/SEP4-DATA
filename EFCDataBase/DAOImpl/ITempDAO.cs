using Entity;

namespace EFCDataBase.DAOImpl;

public interface ITempDAO
{
    public Task<Sensors> GetTemperatureAsync(string id);
    public Task DeleteTemperatureAsync(string id);
    public Task UpdateTemperatureAsync(Sensors sensor);
    public Task<Sensors> AddSensorAsync(Sensors sensor);



}