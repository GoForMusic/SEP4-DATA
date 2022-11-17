﻿using System.Text.Json;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using Services;
using WebApplication1.Contracts;

namespace Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class UserController : ControllerBase
{
    private IUserService _userService;

    public UserController(IUserService userService)
    {
        this._userService = userService;
    }

    // get user
    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<User>> GetUser(string username)
    {
        try
        {
            ICollection<User> users = await _userService.GetUserAsync();
            return Ok(users);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    // create user

    [HttpPost]
    public async Task<ActionResult<User>> AddUser([FromBody] User user)
    {
        try
        {
            User newUser = await _userService.AddUser(user);
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
            await _userService.DeleteUser(id);
            return Ok(id);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    // update user

    [HttpPatch]
    public async Task<ActionResult> UpdateUser([FromBody] User user)
    {
        try
        {
            await _userService.Update(user);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [Route("login/{username}/{password}")]
    // login user
    public async Task LoginAsync(string username, string password)
    {
        User? user = await _userService.GetUser(username);
        // await CacheUserAsync(user!);
    }
}