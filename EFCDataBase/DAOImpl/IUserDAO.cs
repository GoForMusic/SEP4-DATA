using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCDataBase.DAOImpl;
public interface IUserDAO
{
    public Task<ICollection<User>> GetUsersAsync();
    public Task<User> GetUserByIdAsync(string id);
    public Task<User> AddUserAsync(User user);
    public Task DeleteUserAsync(int id);
    public Task UpdateUserAsync(User user);
    public Task<User> GetUser(string username);
}