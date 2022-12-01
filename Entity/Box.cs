using System.ComponentModel.DataAnnotations;

namespace Entity;

public class Box
{
    [Key]
    public string Id { get; set; } = RandomIDGenerator.Generate(20);
    public Boolean light { get; set; }
    public Boolean locked { get; set; }
    public List<Record> records { get; set; }

    
}