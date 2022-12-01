using System.ComponentModel.DataAnnotations;

namespace Entity;

public class Record
{
    [Key]
    public string Id { get; set; } = RandomIDGenerator.Generate(20);
    public DateTime Timestamp { get; set; }
    public float Temperature { get; set; }
    public float Humidity { get; set; }
    public float CO2 { get; set; }
    public float DewPt { get; set; }

    public Record(){}
    
    public Record(float temperature, float humidity, float co2)
    {
        this.Id = RandomIDGenerator.Generate(20);
        this.Timestamp = new DateTime();
        this.Temperature = temperature;
        this.Humidity = humidity;
        this.CO2 = co2;
        this.DewPt = 0;
    }

    
}