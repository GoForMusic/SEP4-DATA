using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity;

public class Box
{
    [Key]
    public string Id { get; set; } = RandomIDGenerator.Generate(20);
    public Boolean Light { get; set; }
    public Boolean Locked { get; set; }
    [ForeignKey("User")]
    public string? OwnedBy { get; set; }
    public List<Record>? Records { get; set; }
}