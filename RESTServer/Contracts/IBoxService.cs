using Entity;

namespace WebApplication1.Services;

public interface IBoxService
{
    Task<ICollection<Box>> GetBoxesAsync();
    Task<Box> GetBoxAsync(string id);
    Task DeleteBoxAsync(string id);
    Task UpdateBoxAsync(Box box);
    Task<Box> AddBoxAsync(Box box);
}