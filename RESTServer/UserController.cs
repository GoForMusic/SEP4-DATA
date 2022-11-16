using System.Text.Json;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using WebApplication1.Contracts;

namespace WebApplication1;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private IUserInterface userInterface;

    public UserController(IUserInterface userInterface)
    {
        this.userInterface = userInterface;
    }

    // get user
    [HttpGet]
    public async Task<ActionResult<User>> GetUser(string username)
    {
        try
        {
            ICollection<User> users = await userInterface.GetUserAsync();
            return Ok(users);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    // create user

    [HttpPost]
    public async Task<ActionResult<User>> Adduser([FromBody] User user)
    {
        try
        {
            User newUser = await userInterface.AddUser(user);
            return Ok(newUser);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    // delete user by id

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<ICollection<User>>> DeleteUser([FromRoute] string id)
    {
        try
        {
            await userInterface.DeleteUser(id);
            return Ok(id);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    // update user

    [HttpPatch]
    public async Task<ActionResult> Update([FromBody] User user)
    {
        try
        {
            await userInterface.Update(user);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    // login user
    public async Task LoginAsync(string username, string password)
    {
        User? user = await userInterface.GetUser(username);
        // await CacheUserAsync(user!);
    }

    // logout user 
    public async Task LogoutAsync()
    {
        // not fully implemented 
        
        await ClearUserFromCacheAsync();

    }

    private async Task ClearUserFromCacheAsync()
    {
        throw new NotImplementedException();
    }
//
//     private async Task CacheUserAsync(User user)
//     {
//         string serialisedData = JsonSerializer.Serialize(user);
//         await jsRuntime.InvokeVoidA
//     }
// }

}