using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCDataBase.DAOImpl;
public interface IUserDAO
{
    Task<ICollection<User>> GetUsersAsync();
    Task<User> GetUserByIdAsync(string id);
    Task<User> AddUserAsync(User user);
    Task DeleteUserAsync(string id);
    Task UpdateUserAsync(User user);
    Task<User> GetUser(string username);
}