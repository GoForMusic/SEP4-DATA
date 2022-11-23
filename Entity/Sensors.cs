using System.ComponentModel.DataAnnotations;

namespace Entity;

public class Sensors
{
    [Key]
    public string Id { get; set; } = RandomIDGenerator.Generate(8);
    [Required]
    public string BoxId { get; set; }
    [Required]
    public DateTime Timestamp { get; set; }
    [Required]
    public float Temperature { get; set; }
    
    
}