using System.ComponentModel.DataAnnotations;

namespace Entity;

public class Sensors
{
    [Key]
    public string Id { get; set; } = RandomIDGenerator.Generate(8);
    [Required]
    public DateTime Timestamp { get; set; }
    [Required]
    public float Temperature { get; set; }
    [Required]
    public float Humidity { get; set; }
    [Required]
    public float CO2 { get; set; }
    [Required]
    public float DewPt { get; set; }
    
    //! STest with teacher fake data
}