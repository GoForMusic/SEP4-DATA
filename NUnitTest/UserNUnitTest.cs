

using EFCDataBase;
using EFCDataBase.DAOImpl;
using Entity;
using Services.Implementations;
using Services.Interfaces;

namespace NUnitTest;

using NUnit.Framework;
public class UserNUnitTest
{
    protected IUserService _service;
    
    [SetUp]
    public void Setup()
    {
        _service = new UserService(new UserDAO(new DBContext()));
    }

    [TearDown]
    public void TearDown()
    {
        _service = null;
    }

    private async Task<User> createUserLocal()
    {
        User localUser = null;
        try
        {
            localUser =  await _service.AddUserAsync(new User()
            {
                Username = "adrian1234",
                FirstName = "Adrian",
                LastName = "Militaru",
                Country = "Denmark",
                Password = "Test1234",
                Age = 10,
                Sex = 'M'
            });
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        return localUser;
    }
    
    [Test, Order(1)]
    public async virtual Task AddUserSuccessfully()
    {
        Assert.NotNull(await createUserLocal());
    }
    
    [Test]
    public async virtual Task RegisterUserExist()
    {
        Assert.ThrowsAsync<Exception>((async () => await _service.AddUserAsync(new User()
        {
            Username = "adrian1234",
            Password = "Test1234"
        })));
    }
    
    [Test]
    public async virtual Task GetUserNotFound()
    {
        Assert.ThrowsAsync<InvalidOperationException>((async () => await _service.GetUserAsync("abcdergg")));
    }

    [Test]
    public async virtual Task GetUserFound()
    {
        Assert.NotNull((async () => await _service.GetUserAsync("adrian1234")));
    }
    
    [Test]
    public async virtual Task RegisterUserPasswordFormat()
    {
        //username cannot be empty
        //password cannot be empty
        //username must have 6 characters
        //password must have 6 characters
        //password must have one upper case
        //password must contain numbers
        //username must contain numbers
        Assert.ThrowsAsync<Exception>((async () => await _service.AddUserAsync(new User()
        {
            Username = "",
            Password = ""
        })));
    }

    [Test]

    public async virtual Task ValidateLogin()
    {
        User local = await _service.LoginAsync("adrian1234","Test1234");
        Assert.IsNotNull(local);
    }
    
    [Test]
    public async virtual Task InValidateLogin()
    {
        Assert.ThrowsAsync<Exception>((async () => await _service.LoginAsync("x","x")));
    }
    
}