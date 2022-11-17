using Entity;

namespace WebApplication1.Contracts;

public interface IUserService
{
    public Task<ICollection<User>> GetUserAsync();
    public Task<User> GetUserAsync(string username);
    public Task<User> AddUserAsync(User user);
    public Task DeleteUserAsync(string id);
    public Task UpdateAsync(User user);
    public Task LoginAsync(string username, string password);
}