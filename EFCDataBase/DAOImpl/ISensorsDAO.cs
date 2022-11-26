using Entity;

namespace EFCDataBase.DAOImpl;

public interface ISensorsDAO
{
    Task<List<Sensors>> GetSensorsAsync();
    Task<Sensors> GetSensorAsync(string id);
    Task DeleteSensorAsync(string id);
    Task UpdateSensorAsync(Sensors sensor);
    Task<Sensors> AddSensorAsync(Sensors sensor);
    Task<ICollection<Sensors>> GetSensorDataByDateAsync(DateTime startDate, DateTime endDate);
}