namespace EProdavnica.Server.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    
    public DbSet<Proizvod> Proizvodi { get; set; }
    public DbSet<Kategorija> Kategorije { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Proizvod>().HasData
            (
                new Proizvod
                {
                    Id = 1,
                    Naziv = "WTL MIG 315",
                    Opis = "Aparat za poluautomatsko zavarivanje u zastiti gasa.",
                    SlikaUrl = "https://www.sualati.com/files/product_picture/2019.07.11.14.16.25_5d272899aaebd_mig315a.jpg",
                    Cena = 9.99m,
                    KategorijaId = 2
                },

                new Proizvod
                {
                    Id = 2,
                    Naziv = "WTL EASY JOB 200E",
                    Opis = "Savrsen za kucnu upotrebu i lakse radionicke poslove!elektrolucni aparat , za celik i prohron",
                    SlikaUrl = "https://www.sualati.com/files/product_picture/605c73c8ac430_wtl-easy-job-200.jpg",
                    Cena = 15.99m,
                    KategorijaId = 1
                },

                new Proizvod
                {
                    Id = 3,
                    Naziv = "WTL MIG 350F",
                    Opis = "MIG/MAG Aparat za poluautomatsko zavarivanje u zaštiti gasa u izvedbi sa odvojenim dodvačem žice",
                    SlikaUrl = "https://www.sualati.com/files/product_picture/2019.07.11.14.53.23_5d2731434735b_mig-350-a-wtl.jpg",
                    Cena = 5.99m,
                    KategorijaId = 2
                }
            );

        modelBuilder.Entity<Kategorija>().HasData
            (
                new Kategorija
                {
                    Id = 1,
                    Ime = "Elektrolučno zavarivanje",
                    Url = "elektro"
                },

                new Kategorija
                {
                    Id = 2,
                    Ime = "MIG/MAG zavarivanje",
                    Url = "mig-mag"
                },

                new Kategorija
                {
                    Id = 3,
                    Ime = "Plazma rezanje",
                    Url = "plazma"
                }
            );

    }


}

 