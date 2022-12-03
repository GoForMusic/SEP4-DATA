

using Entity;

namespace EFCDataBase;

public class Filtering
{
    public static IQueryable<Record> AddFilter(Filter filter, IQueryable<Record> queryable)
    {
       
           if (!filter.TimestampEQ.Equals(new DateTime()))
            {
                queryable = queryable.Where(x => x.Timestamp == filter.TimestampEQ);
            }
        
        if (!filter.TimestampEQ.Equals(new DateTime()))
        {
            queryable = queryable.Where(x => x.Timestamp < filter.TimestampGT);
        }
        
        if (!filter.TimestampEQ.Equals(new DateTime()))
        {
            queryable = queryable.Where(x => x.Timestamp > filter.TimestampLT);
        }
        
        if (!filter.TimestampEQ.Equals(new DateTime()))
        {
            queryable = queryable.Where(x => x.Timestamp <= filter.TimestampGTE);
        }
        
        if (!filter.TimestampEQ.Equals(new DateTime()))
        {
            queryable = queryable.Where(x => x.Timestamp >= filter.TimestampLTE);
        }
        
        if (!filter.TimestampEQ.Equals(new DateTime()))
        {
            queryable = queryable.Where(x => !x.Timestamp.Equals(filter.TimestampNOT));
        }

        //* Filter by Humidity
        
        if (filter?.HumidityEQ != null && filter?.HumidityEQ!=0)
        {
            queryable = queryable.Where(t => t.Humidity == filter.HumidityEQ);
        }
        
        if (filter?.HumidityGT != null && filter?.HumidityGT!=0)
        {
            queryable = queryable.Where(t => filter.HumidityGT < t.Humidity);
        }
        
        if(filter?.HumidityGTE != null && filter?.HumidityGTE!=0)
        {
            queryable = queryable.Where(t => filter.HumidityGTE <= t.Humidity);
        }
        
        if(filter?.HumidityLT != null && filter?.HumidityLT!=0)
        {
            queryable = queryable.Where(t => filter.HumidityLT > t.Humidity);
        }
        
        if(filter?.HumidityLTE != null && filter?.HumidityLTE!=0)
        {
            queryable = queryable.Where(t => filter.HumidityLTE >= t.Humidity);
        }

        if(filter?.HumidityNOT != null && filter?.HumidityNOT!=0)
        {
            queryable = queryable.Where(t => filter.HumidityNOT != t.Humidity);
        }
        
        //* Filter by Temperature
        
        if (filter?.TemperatureEQ != null && filter?.TemperatureEQ!=0)
        {
            queryable = queryable.Where(t => t.Temperature == filter.TemperatureEQ);
        }
        
        if (filter?.TemperatureGT != null && filter?.TemperatureGT!=0)
        {
            queryable = queryable.Where(t => filter.TemperatureGT < t.Temperature);
        }
        
        if(filter?.TemperatureGTE != null && filter?.TemperatureGTE!=0)
        {
            queryable = queryable.Where(t => filter.TemperatureGTE <= t.Temperature);
        }
        
        if(filter?.TemperatureLT != null && filter?.TemperatureLT!=0)
        {
            queryable = queryable.Where(t => filter.TemperatureLT > t.Temperature);
        }
        
        if(filter?.TemperatureLTE != null && filter?.TemperatureLTE!=0)
        {
            queryable = queryable.Where(t => filter.TemperatureLTE >= t.Temperature);
        }
        
        if(filter?.TemperatureNOT != null && filter?.TemperatureNOT!=0)
        {
            queryable = queryable.Where(t => filter.TemperatureNOT != t.Temperature);
        }
        
        //* Filter by CO2
        
        if (filter?.CO2EQ != null && filter?.CO2EQ!=0)
        {
            queryable = queryable.Where(t => t.CO2 == filter.CO2EQ);
        }
        
        if (filter?.CO2GT != null && filter?.CO2GT!=0)
        {
            queryable = queryable.Where(t => filter.CO2GT < t.CO2);
        }
        
        if(filter?.CO2GTE != null && filter?.CO2GTE!=0)
        {
            queryable = queryable.Where(t => filter.CO2GTE <= t.CO2);
        }
        
        if(filter?.CO2LT != null && filter?.CO2LT!=0)
        {
            queryable = queryable.Where(t => filter.CO2LT > t.CO2);
        }
        
        if(filter?.CO2LTE != null && filter?.CO2LTE!=0)
        {
            queryable = queryable.Where(t => filter.CO2LTE >= t.CO2);
        }
        
        if(filter?.CO2NOT != null && filter?.CO2NOT!=0)
        {
            queryable = queryable.Where(t => filter.CO2NOT != t.CO2);
        }
        
        //* Filter by DewPTEQ
        
        if (filter?.DewPTEQ != null && filter?.DewPTEQ!=0)
        {
            queryable = queryable.Where(t => t.DewPt == filter.DewPTEQ);
        }
        
        if (filter?.DewPTGT != null && filter?.DewPTGT!=0)
        {
            queryable = queryable.Where(t => filter.DewPTGT < t.DewPt);
        }
        
        if(filter?.DewPTGTE != null && filter?.DewPTGTE!=0)
        {
            queryable = queryable.Where(t => filter.DewPTGTE <= t.DewPt);
        }
        
        if(filter?.DewPTLT != null && filter?.DewPTLT!=0)
        {
            queryable = queryable.Where(t => filter.DewPTLT > t.DewPt);
        }
        
        if(filter?.DewPTLTE != null && filter?.DewPTLTE!=0)
        {
            queryable = queryable.Where(t => filter.DewPTLTE >= t.DewPt);
        }
        
        if(filter?.DewPTNOT != null && filter?.DewPTNOT!=0)
        {
            queryable = queryable.Where(t => filter.DewPTNOT != t.DewPt);
        }
        
        if(filter?.size != 0)
            queryable = queryable.Take(filter.size);
        
        
        return queryable;
    }
}