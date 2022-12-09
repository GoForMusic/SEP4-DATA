namespace Entity;

public class Filter
{
   
    //*  EQ     -> equal
    //*  NOT    -> NOT equal
    //*  GT     -> greater than
    //*  GTE    -> greater than or equal
    //*  LT     -> less than
    //*  LTE    -> less than or equal
    
    //* Timestamps
    public DateTime TimestampEQ { get; set; }
    public DateTime TimestampNOT { get; set; }
    public DateTime TimestampGT { get; set; }
    public DateTime TimestampGTE { get; set; }
    public DateTime TimestampLT { get; set; }
    public DateTime TimestampLTE { get; set; }
    
    //* Temperature
    public float TemperatureEQ { get; set; }
    public float TemperatureNOT { get; set; }
    public float TemperatureGT { get; set; }
    public float TemperatureGTE { get; set; }
    public float TemperatureLT { get; set; }
    public float TemperatureLTE { get; set; }
    
    //* Humidity
    public float HumidityEQ { get; set; }
    public float HumidityNOT { get; set; }
    public float HumidityGT { get; set; }
    public float HumidityGTE { get; set; }
    public float HumidityLT { get; set; }
    public float HumidityLTE { get; set; }
    
    //* CO2
    public float CO2EQ { get; set; }
    public float CO2NOT { get; set; }
    public float CO2GT { get; set; }
    public float CO2GTE { get; set; }
    public float CO2LT { get; set; }
    public float CO2LTE { get; set; }

    //* DewPT
    public float DewPTEQ { get; set; }
    public float DewPTNOT { get; set; }
    public float DewPTGT { get; set; }
    public float DewPTGTE { get; set; }
    public float DewPTLT { get; set; }
    public float DewPTLTE { get; set; }
    
    //* PAGINATION
    public int size { get; set;  }
}