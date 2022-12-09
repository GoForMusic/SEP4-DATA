using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity;

public class Box
{
    [Key]
    public string Id { get; set; }
    public Boolean Light { get; set; }
    public Boolean Locked { get; set; }
    [ForeignKey("User")]
    public string? UserId { get; set; }
    [ForeignKey("Preset")]
    public string PresetId { get; set; }
}