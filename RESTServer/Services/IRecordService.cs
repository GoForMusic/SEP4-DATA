﻿using Entity;
using Entity.RestFilter;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Services;

public interface IRecordService
{
    Task<ICollection<Record>> GetAllRecordsDataAsync(RecordFilter recordFilter);
    Task<ICollection<Record>> GetRecordDataByDate(DateTime startDate, DateTime endDate);
    Task<Record> GetRecordDataByIdAsync(string id);
    Task<Record> AddRecordDataAsync(Record sensors);
    Task RemoveRecordDataAsync(string id);
}