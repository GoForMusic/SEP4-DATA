namespace Entity;

public class Preset
{
    public string Id { get; set; } = RandomIDGenerator.Generate(20);
    public string PresetName { get; set; } = "";
    public float TemperatureMax { get; set; }
    public float HumidityMax { get; set; }
    public float TemperatureMin { get; set; }
    public float HumidityMin { get; set; }
}