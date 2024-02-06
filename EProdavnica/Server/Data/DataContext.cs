namespace EProdavnica.Server.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    public DbSet<Proizvod> Proizvodi { get; set; }
}
