using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCDataBase.DAOImpl;

public class BoxDao : IBoxDao
{
    
    private readonly DBContext database;

    public BoxDao(DBContext database)
    {
        this.database = database;
    }
    
    public async Task<List<Box>> GetBoxesAsync()
    {
        return await database.Box.ToListAsync();
    }

    public async Task<Box> GetBoxAsync(string id)
    {
        return await database.Box.FirstAsync(t => t.Id.Equals(id));
    }

    public async Task DeleteBoxAsync(string id)
    {
        Box? box = await database.Box.FirstAsync(se => se.Id.Equals(id));
        if (box is null)
        {
            throw new Exception("ERROR: Box does not exist. ID: " + id);
        }

        database.Box.Remove(box);
        await database.SaveChangesAsync();
    }

    public async Task UpdateBoxAsync(Box box)
    {
        database.Box.Update(box);
        await database.SaveChangesAsync();
    }

    public async Task<Box> AddBoxAsync(Box box)
    {
        try
        {
            EntityEntry<Box> newBox = await database.Box.AddAsync(box);
            await database.SaveChangesAsync();
            return newBox.Entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e+" "+ e.StackTrace);
        }

        return box;
    }

    public async Task<ICollection<Preset>> GetPresets()
    {
        return await database.Preset.ToListAsync();
    }

    public async Task<Preset> AddPreset(Preset preset)
    {
        try
        {
            EntityEntry<Preset> newPreset = await database.Preset.AddAsync(preset);
            await database.SaveChangesAsync();
            return newPreset.Entity;
        }  catch (Exception e)
        {
            Console.WriteLine(e+" "+ e.StackTrace);
        }

        return preset;
    }
}