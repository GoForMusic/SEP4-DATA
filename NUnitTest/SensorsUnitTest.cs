using EFCDataBase;
using EFCDataBase.DAOImpl;
using Entity;
using NUnit.Framework;
using WebApplication1.Services;

namespace NUnitTest;

public class SensorsUnitTest
{
    private ISensorsService _service;
    
    [SetUp]
    public void Setup()
    {
        _service = new SensorsService(new SensorsDAO(new DBContext()));
    }

    [TearDown]
    public void TearDown()
    {
        _service = null;
    }
    
    private async Task<Sensors> createSensorData()
    {
        DateTime dateTest = new DateTime(2023, 01, 01);
        
        try
        {
            Sensors local =  await _service.AddSensorsDataAsync(new Sensors()
            {
                //BoxId = "testBoxId",
                Timestamp = dateTest,
                Temperature = 12.3f,
                CO2 = 12.3f,
            });
            return local;
        }
        catch (Exception e)
        {
            throw e;
        }

        return null;
    }
    
    [Test, Order(1)]
    public async virtual Task AddSensorsObjSuccessfully()
    {
        Assert.NotNull(await createSensorData());
    }

    [Test]
    public async virtual Task GetSensors_ByDate()
    {
        DateTime dateTestStart = new DateTime(2022, 02, 02);
        DateTime dateTestEnd = new DateTime(2024, 02, 02);
        Assert.ThrowsAsync<Exception>((async () => await _service.GetSensorDataByDate(dateTestStart, dateTestStart)));
        Assert.NotNull((async () => await _service.GetSensorDataByDate(dateTestStart, dateTestEnd)));
    }

    [Test]
    public async virtual Task GetSensors_AllReturnsNotNull()
    {
        Assert.NotNull((async () => await _service.GetAllSensorsDataAsync()));
    }

    [Test]
    public async virtual Task GetSensors_ById()
    {
        await createSensorData();
        DateTime dateTest = new DateTime(2022, 01, 01);
        Sensors local =  await _service.AddSensorsDataAsync(new Sensors()
        {
            //BoxId = "testBoxId",
            Timestamp = dateTest,
            Temperature = 12.3f,
            CO2 = 12.3f,
        });

        Assert.AreEqual("99999999",   _service.GetSensorsDataByIdAsync("99999999").Result.Id); ;
    }
    
    
}