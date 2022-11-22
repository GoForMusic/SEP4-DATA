using System.ComponentModel.DataAnnotations;

namespace Entity;

public class Temperature
{
    [Key]
    public string Id { get; set; } = RandomIDGenerator.Generate(8);
    [Required]
    public DateTime Timestamp { get; set; }
    [Required]
    public float Temp { get; set; }
    [Required]
    public string BoxId { get; set; }
    
}