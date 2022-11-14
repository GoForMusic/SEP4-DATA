namespace WebApplication1.Entities;

public class User
{
    

    public User(string firstName, string lastName, string username, string password, int age, string country, char sex)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.username = username;
        this.password = password;
        this.age = age;
        this.country = country;
        this.sex = sex;
    }

    public User()
    {
    }

    public string firstName { get; set; }
    public string lastName { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public int age { get; set; }
    public string country { get; set; }
    public char sex { get; set; }
}