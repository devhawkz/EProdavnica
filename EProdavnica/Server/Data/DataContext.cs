﻿namespace EProdavnica.Server.Data;

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
                    SlikaUrl = "https://www.biljaca.rs/wp-content/uploads/2019/01/aparat-zavarivanje-wtl-multimig-200-slika-42091184-300x300-2.jpg",
                    Cena = 9.99m,
                    KategorijaId = 2
                },

                new Proizvod
                {
                    Id = 2,
                    Naziv = "WTL EASY JOB 200E",
                    Opis = "Savrsen za kucnu upotrebu i lakse radionicke poslove!elektrolucni aparat , za celik i prohron",
                    SlikaUrl = "https://www.biljaca.rs/wp-content/uploads/2023/05/easy-job-200.jpg",
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
                },

                new Proizvod
                {
                    Id = 4,
                    Naziv = "WTL TT 2000 HF + REL",
                    Opis = "Multifunkcionalni aparat za zavarivanje TIG DC HF i REL\r\nVeoma lagan i kompaktan IGBT inverterski aparat ali izuzetno robustan. Savršen partner za TIG DC zavarivanje sa izuzetno lakim HF bezkontaktnim paljenjem luka i mogućnošću podešavanja završne struje, vremena završnog gasa i 2T –4T rada.\r\nU REL varijanti poseduje ARC FORCE optimizovano stabilizaciju električnog luka,HOT START olakšava paljenje elektrode i ANTI STICKING smanjuje mogućnost lepljenja elektrode za bazni materijal.\r\nOpremljen sa temperaturnim,naponskim i senzorom za zaštitu od oscilacija u naponu i jačini struje.\r\nDizajniran za rad na diesel generatorima sa sposobnošću da izbegne kvarove koji mogu da se dese zbog naglih skokova napona,testiran na 440 V.\r\nVisoka intermitenca pogodna za radioničke i industrijske namene.\r\nHlađenje unutrašnje elektronike je prinudno pomoću vrlo efikasnog ventilatora.\r\nUrađen prema EN propisima EN 60974-1 usklađen sa CE oznakom",
                    SlikaUrl = "https://www.biljaca.rs/wp-content/uploads/2021/04/tt2000.jpg",
                    Cena = 9.99m,
                    KategorijaId = 4
                },

                new Proizvod
                {
                    Id = 5,
                    Naziv = "WTL TIG 320 AC/DC",
                    Opis = "Aparat za zavarivanje WTL 320 TIG AC\\DC pulsni 320A\r\nTIG/REL(MMA )pulsni aparat pogodan za profesionalnu upotrebu.",
                    SlikaUrl = "https://www.biljaca.rs/wp-content/uploads/2020/05/big-53583055_5a1c62bf275d96-73145320tig_ac-dc_320-1--300x300.jpg",
                    Cena = 15.99m,
                    KategorijaId = 4
                },

                new Proizvod
                {
                    Id = 6,
                    Naziv = "ESAB ARISTO 500ix",
                    Opis = "SAB Aristo 500ix je prenosni pulsni višenamenski aparat za zavarivanje dizajniran i proizveden u skladu sa potrebama i željama najzahtevnijih industrijskih korisnika.\r\n\r\nUparen sa Robust Feed U6 ili Robust Feed Puls dodavačima ESAB Aristo 500ix predstavlja, u ovom trenutku, najnapredniju multiprocesnu zavarivačku opremu na svetskom tržištu namenjenu za korišćenje u ekstremnim radnim okruženjima.",
                    SlikaUrl = "https://www.biljaca.rs/wp-content/uploads/2021/03/aristo500ix-1.jpg",
                    Cena = 5.99m,
                    KategorijaId = 2
                },

                new Proizvod
                {
                    Id = 7,
                    Naziv = "WTL CUT 100CNC",
                    Opis = "Aparat za plazma rezanje maksimalne jačine 100 A Paljenje luka bez kontakta sa materijalom(vazdušno). Intermitenca mu je na 90 A 100% Reže do maksimalne debljine od 55 mm Količina vazduha koja mu je potrebna za pravilan rad je od 30 do 290 litara u   minuti. Brener za rezanje je dužine 6M i opremljen je TECMO PT 100 gorionikom.",
                    SlikaUrl = "https://www.biljaca.rs/wp-content/uploads/2019/01/cut_100_cnc_fotor.jpg",
                    Cena = 9.99m,
                    KategorijaId = 3
                },

                new Proizvod
                {
                    Id = 8,
                    Naziv = "WTL MIG 220 DIGI SYNERGIC",
                    Opis = "Vrhunski polusinergetski inverterski aparat za zavarivanje sa automatskim izborom brzine žice na osnovu debljine žice i vrste gasa koji se koristi.\r\nOdlična dinamika zavarivanja, sinergetsko podešavanje parametra.",
                    SlikaUrl = "https://www.biljaca.rs/wp-content/uploads/2022/10/digi4.jpg",
                    Cena = 15.99m,
                    KategorijaId = 2
                },

                new Proizvod
                {
                    Id = 9,
                    Naziv = "WTL MCU 250 PULS",
                    Opis = "Aparat se isporučuje sa gorionikom MB 25 3M, kleštima za masu i elektrodu sa pripadajućim kablovima.\r\n\r\nEkonomični sinergetski dupli pulsni aparat za MIG/MAG zavarivanje, odličnih performansi sa mogućnošću zavarivanja raznorodnih materijala.\r\n\r\nSynergic inverter sa pulsom, duplim pulsom, podešavanjem vremena početnog gasa i završnog gasa, frekvencijom pulsacije, gornjim i donjim strujama, podešavanjem dužine luka i kod gornje i kod donje struje, podešavanjem povećanja jačine i vremena trajanja prilikom starta paljenja luka, popunjavanje kratera prilikom završetka i trajanje popunjavanja kratera i indukcije.\r\n\r\nIzuzetno brzi igbt invertor, uparen sa kvalitetnom elektronikom i modernim softverom, daje izuzetnu dinamiku zavarivanja u svim režimima, omogućavajući odlične rezultate zavarivanja.\r\n\r\nWTL Schweisstechnik MCU MIG-250 je profesionalni aparat maksimalne jačine 230A, namenjen zavarivačima koji žele da poseduju kombinovani aparat sa kojim mogu u MIG/MAG postupku da zavaruju sve vrste materijala od crnih čelika, prohromskih čelika, aluminijuma.\r\n\r\nMogućnost korištenja sa Push-Pull gorionikom.\r\nTakodje omogućava zavarivanje REL i TIG(DC) postupkom.\r\nIdealan za izradu čamaca, lakih aluminijumskih i prohromskih konstrukcija, prikolica, limarske radove, za razne poslove reparaturnog tipa i slične namene.\r\nMonofazno napajanje(230V), vrlo mali gabariti i težina, omogućavaju da aparat bude vrlo prenosiv.\r\n\r\nDupli pogon žice sa četiri uzupčena točkića, koji omogućavaju besprekoran dotur žice, bez obzira na vrstu materijala koji se zavaruje i tipa žice koji se koristi.",
                    SlikaUrl = "https://www.biljaca.rs/wp-content/uploads/2022/02/116691304_60a7dfcb25a209-62465989strana.jpg",
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
                },

                new Kategorija
                {
                    Id = 4,
                    Ime = "Tig zavarivanje",
                    Url = "tig"
                }
            );

    }


}

 