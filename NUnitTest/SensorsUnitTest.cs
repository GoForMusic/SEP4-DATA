using EFCDataBase;
using EFCDataBase.DAOImpl;
using Entity;
using Entity.RestFilter;
using NUnit.Framework;
using WebApplication1.Services;

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
        Assert.NotNull((async () => await _service.GetAllRecordsDataAsync(new RecordFilter())));
    }

    [Test]
    public async virtual Task GetRecord_ById()
    {
        await createRecordData();
        DateTime dateTest = new DateTime(2022, 01, 01);
        Record local =  await _service.AddRecordDataAsync(new Record()
        {
            //BoxId = "testBoxId",
            Timestamp = dateTest,
            Temperature = 12.3f,
            CO2 = 12.3f,
        });

        Assert.AreEqual("99999999",   _service.GetRecordDataByIdAsync("99999999").Result.Id); ;
    }
    
    
}