using Entity;

namespace EFCDataBase.DAOImpl;

public interface IBoxDao
{
    Task<List<Box>> GetBoxesAsync();
    Task<Box> GetBoxAsync(string id);
    Task DeleteBoxAsync(string id);
    Task UpdateBoxAsync(Box box);
    Task<Box> AddBoxAsync(Box box);
    Task<Preset> AddPreset(Preset preset);
    Task<ICollection<Preset>> GetPresets();

}