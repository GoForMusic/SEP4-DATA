using EFCDataBase.DAOImpl;
using Entity;
using WebApplication1.Contracts;

namespace Services;

public class UserService : IUserService
{
    private IUserDAO _userDao;

    public UserService(IUserDAO userDao)
    {
        _userDao = userDao;
    }

    public async Task<ICollection<User>> GetUserAsync()
    {
        return await _userDao.GetUsersAsync();
    }

    public async Task<User> GetUserAsync(string username)
    {
        return await _userDao.GetUser(username);
    }

    public async Task<User> AddUserAsync(User user)
    {
        if (await NotAllFieldsFilledIn(user) == true)
        {
            throw new Exception("Please fill out all the fields");
        }

        ValidateUsername(user.Username);
        ValidatePassword(user.Password);
        ValidateSex(user.Sex);
        user.Password = encryptPassword(user.Password);
        
        await _userDao.AddUserAsync(user);
        return user;
    }

    public async Task DeleteUserAsync(string id)
    {
        await _userDao.DeleteUserAsync(id);
    }

    public async Task UpdateAsync(User user)
    {
        await _userDao.UpdateUserAsync(user);
    }

    public async Task<User> LoginAsync(string username, string password)
    {
        User user = await _userDao.GetUser(username);
        if (validateHashPassword(password, user.Password)) return user;
        else throw new Exception("Username/password incorrect!");
    }
    
    private async Task<bool> NotAllFieldsFilledIn(User user)
    {
        if (user.Age == null ||
            user.Country == null || user.Country == string.Empty ||
            user.Password == null || user.Password == String.Empty ||
            user.Sex == null ||
            user.Username == null || user.Username == String.Empty ||
            user.FirstName == null || user.FirstName == String.Empty ||
            user.LastName == null || user.LastName == String.Empty)
        {
            return true;
        }

        return false;
    }

    private void ValidateUsername(string username)
    {
        if (username.Length <= 3 && username.Length > 15)
        {
            throw new Exception("Username must be between 3 and 15 letters");
        }
    }

    private void ValidatePassword(string password)
    {
        if (password.Length <= 3)
        {
            throw new Exception("Password must consist of more than 3 letters");
        }
        
        bool capitalLetter = false;
        bool digitLetter = false;

        foreach (char c in password.ToCharArray())
        {
            if (!capitalLetter){
                if (Char.IsUpper(c)){
                    capitalLetter =true;
                }
            }

            if (!digitLetter){
                if (Char.IsDigit(c)){
                    digitLetter=true;
                }
            }
        }

        if (!capitalLetter){
            throw new Exception("Password needs to contain at least one uppercase letter");
        }
        if (!digitLetter){
            throw new Exception("Password needs to contain at least one digit");
        }
    }

    private void ValidateSex(char sex)
    {
        if (Char.ToUpper(sex) != 'M' && Char.ToUpper(sex) != 'F')
        {
            throw new Exception("Invalid sex, must be M or F");
        }
    }


    private string encryptPassword(string passwordPlaintext)
    {
        string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
        
        return BCrypt.Net.BCrypt.HashPassword(passwordPlaintext, salt);
    }

    private bool validateHashPassword(string passwordPlaintext, string passwordHash)
    {
        bool password_verified = false;

        if(null == passwordHash || !passwordHash.StartsWith("$2a$"))
            throw new Exception("Invalid hash provided for comparison");

        password_verified = BCrypt.Net.BCrypt.Verify(passwordPlaintext, passwordHash);

        return password_verified;
    }
}