using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Entity;

public class User
{
    public User()
    {
        FirstName = String.Empty;
        LastName = String.Empty;
        Username = String.Empty;
        Password = String.Empty;
        Age = 0;
        Country = String.Empty;
        Sex = 'M';
    }

    [Key]
    public string Id { get; set; } = RandomIDGenerator.Generate(20);
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int Age { get; set; }
    public string Country { get; set; }
    public char Sex { get; set; }
    
}