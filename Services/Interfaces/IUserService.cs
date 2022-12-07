using Entity;

namespace Services.Interfaces;

public interface IUserService
{
    public Task<ICollection<User>> GetUserAsync();
    public Task<User> GetUserAsync(string username);
    public Task<User> AddUserAsync(User user);
    public Task DeleteUserAsync(string id);
    public Task UpdateAsync(User user);
    public Task<User> LoginAsync(string username, string password);
}