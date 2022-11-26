using Entity;

namespace EFCDataBase.DAOImpl.CO2;

public interface ICO2DAO
{
    public Task<Sensors> GetCO2Async(string id);
    public Task DeleteCO2Async(string id);
    public Task UpdateCO2Async(Sensors sensor);
    public Task<Sensors> AddSensorAsync(Sensors sensor);
}