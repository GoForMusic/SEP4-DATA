
using EFCDataBase;
using EFCDataBase.DAOImpl;
using Entity;
using NUnit.Framework;
using Services.Implementations;
using Services.Interfaces;

namespace NUnitTest;

public class RecordUnitTest
{
    private IRecordService _service;
    
    [SetUp]
    public void Setup()
    {
        _service = new RecordService(new RecordDAO(new DBContext()));
    }

    [TearDown]
    public void TearDown()
    {
        _service = null;
    }
    
    private async Task<Record> createRecordData()
    {
        DateTime dateTest = new DateTime(2023, 01, 01);
        
        try
        {
            Record local =  await _service.AddRecordDataAsync(new Record()
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
    public async virtual Task AddRecordObjSuccessfully()
    {
        Assert.NotNull(await createRecordData());
    }

    [Test]
    public async virtual Task GetRecord_ByDate()
    {
        DateTime dateTestStart = new DateTime(2022, 02, 02);
        DateTime dateTestEnd = new DateTime(2024, 02, 02);
        Assert.ThrowsAsync<Exception>((async () => await _service.GetRecordDataByDate(dateTestStart, dateTestStart)));
        Assert.NotNull((async () => await _service.GetRecordDataByDate(dateTestStart, dateTestEnd)));
    }

    [Test]
    public async virtual Task GetRecord_AllReturnsNotNull()
    {
        Assert.NotNull((async () => await _service.GetAllRecordDataAsync(new Filter())));
    }

    [Test]
    public async virtual Task GetRecord_ById()
    {
        await createRecordData();
        Assert.AreEqual("99999999",   _service.GetRecordDataByIdAsync("99999999").Result.Id); ;
    }
    
    [Test]
    public async virtual Task CalculateDewPtInF()
    {
        Record record = new Record()
        {
            Id = "testMock",
            Temperature = 66.7f,
            Humidity = 12.3f,
        };
        Record? returnedRecord=await _service.AddRecordDataAsync(record);
        //tolerance 0.2f
        Assert.AreEqual(13.1f, returnedRecord.DewPt,0.2f);

    }
    
}