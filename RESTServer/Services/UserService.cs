﻿using Entity;
using WebApplication1.Contracts;

namespace Services;

public class UserService : IUserService
{
    public async Task<ICollection<User>> GetUserAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUser(string username)
    {
        throw new NotImplementedException();
    }

    public async Task<User> AddUser(User user)
    {
        if (await NotAllFieldsFilledIn(user) == true)
        {
            throw new Exception("Please fill out all the fields");
        }

        ValidateUsername(user.Username);
        ValidatePassword(user.Password);
        ValidateSex(user.Sex);
        //(Add when DAO is done) Code to test if username exists in the database
        //(Add when DAO is done) Code to put the user in the database
        return user;
    }

    public async Task DeleteUser(string id)
    {
        throw new NotImplementedException();
    }

    public async Task Update(User user)
    {
        throw new NotImplementedException();
    }

    public async Task LoginAsync(string username, string password)
    {
        throw new NotImplementedException();
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
}