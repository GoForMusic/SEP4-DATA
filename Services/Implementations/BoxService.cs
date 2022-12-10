using EFCDataBase.DAOImpl;
using Entity;
using Services.Interfaces;

namespace Services.Implementations;

public class BoxService : IBoxService
{
    private IBoxDao _boxDao;

    public BoxService(IBoxDao boxDao)
    {
        _boxDao = boxDao;
    }
    
    public async Task<ICollection<Box>> GetBoxesAsync()
    {
        try
        {
            return await _boxDao.GetBoxesAsync();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<Box> GetBoxAsync(string id)
    {
        try
        {
            return await _boxDao.GetBoxAsync(id);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task DeleteBoxAsync(string id)
    {
        try
        {
            await _boxDao.DeleteBoxAsync(id);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task UpdateBoxAsync(Box box)
    {
        try
        {
            await _boxDao.UpdateBoxAsync(box);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<Box> AddBoxAsync(Box box)
    {
        try
        {
            return await _boxDao.AddBoxAsync(box);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<Preset> AddPreset(Preset preset)
    {
        try
        {
            return await _boxDao.AddPreset(preset);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<ICollection<Preset>> GetPresets()
    {
        try
        {
            return await _boxDao.GetPresets();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}