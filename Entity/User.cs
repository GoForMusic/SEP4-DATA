using System.ComponentModel.DataAnnotations;

namespace Entity;

public class User
{
    public User()
    {
    }

    [Key]
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int Age { get; set; }
    public string Country { get; set; }
    public char Sex { get; set; }
    
}