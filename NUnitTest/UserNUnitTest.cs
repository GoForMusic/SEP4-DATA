using EFCDataBase;
using EFCDataBase.DAOImpl;
using Entity;
using Microsoft.EntityFrameworkCore;
using Services;
using WebApplication1.Contracts;

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
        try
        {
            User local =  await _service.AddUserAsync(new User()
            {
                Username = "adrian1234",
                FirstName = "Adrian",
                LastName = "Militaru",
                Country = "Denmark",
                Password = "Test1234",
                Sex = 'M'
            });
        }
        catch (Exception e)
        {
            throw e;
        }

        return null;
    }
    
    [Test, Order(1)]
    public async virtual Task AddUserSuccessfully()
    {
        Assert.NotNull(await createUserLocal());
    }

    [Test,Order(2)]
    public async virtual Task DuplicateUserFound()
    {
        Assert.IsNull(await createUserLocal());
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
}