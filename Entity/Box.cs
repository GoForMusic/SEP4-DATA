using System.ComponentModel.DataAnnotations;

namespace Entity;

public class Box
{
    [Key]
    public string Id { get; set; } = RandomIDGenerator.Generate(20);
    [Required]
    public Boolean light { get; set; }
    [Required]
    public Boolean locked { get; set; }
    [Required]
    public List<Record> records { get; set; }

    public Box(string id, Boolean light, Boolean locked, List<Record> records)
    {
        Id = id;
        this.light = light;
        this.locked = locked;
        this.records = records;
    }
}