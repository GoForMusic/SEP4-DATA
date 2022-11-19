using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCDataBase.DAOImpl;
using Entity;

public class UserDAO : IUserDAO
{

 private readonly DBContext database;

    public UserDAO(DBContext database)
    {
        this.database = database;
    }
    
    public async Task<ICollection<User>> GetUsersAsync()
    {
        return await database.Users.ToListAsync();
    }

    public async Task<User> GetUserByIdAsync(string id)
    {
        return await database.Users.FirstAsync(t=>t.Id.Equals(id));
    }

    public async Task<User> AddUserAsync(User user)
    {
        try{
            EntityEntry<User> add = await database.Users.AddAsync(user);
            await database.SaveChangesAsync();
            return add.Entity;
        }catch (Exception e)
        {
            Console.WriteLine(e+" "+ e.StackTrace); 
        }

        return user;
    }

    public async Task DeleteUserAsync(string id)
    {
        User? user = await database.Users.FirstAsync(t=>t.Id.Equals(id));
        if (user is null)
        {
            throw new Exception("Good sir, the user that you want to delete is not found");
        }
        database.Users.Remove(user);
        await database.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(User user)
    {
        database.Users.Update(user);
        await database.SaveChangesAsync();
    }

    public async Task<User> GetUser(string username) // for login
    {
    
        return await database.Users.FirstAsync(t => t.Username.Equals(username));
 
    }
    
}