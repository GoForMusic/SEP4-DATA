using Entity;
using Microsoft.EntityFrameworkCore;

namespace EFCDataBase;

public class DBContext : DbContext
{
    
    public DbSet<User> Users { get; set; }
    public DbSet<Record> Record { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // ! need to be installed dotnet tool install -g dotnet-ef
        // ! cd EFCDataBase -> you need to be inside the EFC project to run the EFC commands
        // ! dotnet ef migrations add InitialCreate where InitialCreate is a uniq message
        // ! dotnet ef database update

        //amazon credentails
        optionsBuilder.UseNpgsql(@"Host=awseb-e-phug32p3mh-stack-awsebrdsdatabase-f06vkog3fu5g.cwtobajncazb.eu-north-1.rds.amazonaws.com;Database=postgres;Username=sep4user;Password=sep4passworddata");
        optionsBuilder.EnableSensitiveDataLogging();
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<User>().HasKey(user => new {user.Id, user.Username});
        modelBuilder.Entity<User>().HasIndex(user => user.Username ).IsUnique();
       
        
    }
}