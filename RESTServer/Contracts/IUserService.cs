using Entity;

namespace WebApplication1.Contracts;

public interface IUserService
{
    public Task<ICollection<User>> GetUserAsync();
    public Task<User> GetUser(string username);
    public Task<User> AddUser(User user);
    public Task DeleteUser(string id);
    public Task Update(User user);
    public Task LoginAsync(string username, string password);
}