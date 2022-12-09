using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity;

public class Box
{
    [Key]
    public string Id { get; set; }
    public bool Light { get; set; }
    public bool Locked { get; set; }
    [ForeignKey("User")]
    public string? UserId { get; set; }
    [ForeignKey("Preset")]
    public string PresetId { get; set; }
}