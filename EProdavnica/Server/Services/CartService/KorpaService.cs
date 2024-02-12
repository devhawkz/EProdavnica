using EProdavnica.Shared.DTO;

namespace EProdavnica.Server.Services.CartService;

public class KorpaService : IKorpaService
{
    private readonly DataContext _context;

    public KorpaService(DataContext context)
    {
        _context = context;
    }
    public async Task<ServiceResponse<List<ProizvodiUKorpiResponse>>> GetProizvodeIzKorpeAsync(List<ProizvodUKorpi> proizvodiIzKorpe)
    {
        var rezultat = new ServiceResponse<List<ProizvodiUKorpiResponse>>
        {
            Podaci = new List<ProizvodiUKorpiResponse>()
        };

        /*Ova petlja prolazi kroz listu proizvoda iz korpe i za svaki proizvod pronalazi odgovarajući proizvod i varijantu proizvoda u bazi podataka. Ako ne može pronaći proizvod ili varijantu proizvoda za trenutni element u korpi, preskače taj element. Na kraju, rezultat sadrži informacije o svim pronađenim proizvodima iz korpe. Ovaj kod se koristi za prikupljanje detalja o proizvodima iz korpe koje je potrebno prikazati korisniku, kao što su naziv, slika, cena i tip proizvoda.
         */
        foreach (var proizvodIzKorpe in proizvodiIzKorpe) //- Petlja prolazi kroz svaki element (proizvodIzKorpe) u listi proizvoda iz korpe (proizvodiIzKorpe).
        {
            // Pronalazi se proizvod u bazi podataka koji ima isti Id kao i proizvod iz korpe koji se trenutno obrađuje. Koristi se asinhrona metoda FirstOrDefaultAsync().
            var proizvod = await _context.Proizvodi
                .Where(p => p.Id == proizvodIzKorpe.ProizvodId)
                .FirstOrDefaultAsync();

            if (proizvod == null)
            {
                continue; //  Proverava se da li je pronađen proizvod u bazi podataka. Ako nije pronađen, preskače se dalji kod u petlji za trenutni proizvod iz korpe
            }

            //Pronalazi se varijanta proizvoda u bazi podataka koja odgovara trenutnom proizvodu iz korpe, filtrirajući po Id-u proizvoda i Id-u tipa proizvoda. Takođe se uključuju podaci o tipu proizvoda (TipProizvoda) koristeći Include.
            var varijantaProizvoda = await _context.VarijanteProizvoda
                .Where(v => v.ProizvodId == proizvodIzKorpe.ProizvodId && v.TipProizvodaId == proizvodIzKorpe.TipProizvodaId)
                .Include(v => v.TipProizvoda)
                .FirstOrDefaultAsync();

            if (varijantaProizvoda == null)
            {
                continue; //proverava se da li je pronađena varijanta proizvoda u bazi podataka. Ako nije pronađena, preskače se dalji kod u petlji za trenutni proizvod iz korpe.
            }

            // Kreira se objekat ProizvodiUKorpiResponse koji sadrži informacije o proizvodu iz korpe i varijanti proizvoda koji su pronađeni u bazi podataka.
            var proizvodIzKorpeResponse = new ProizvodiUKorpiResponse
            {
                ProizvodId = proizvod.Id,
                Naziv = proizvod.Naziv,
                SlikaUrl = proizvod.SlikaUrl,
                Cena = varijantaProizvoda.Cena,
                TipProizvoda = varijantaProizvoda.TipProizvoda.Ime,
                TipProizvodaId = varijantaProizvoda.TipProizvoda.Id,
                Kolicina = proizvodIzKorpe.Kolicina
            };

            //rezultat.Podaci.Add(proizvodIzKorpeResponse); - Dodaje se objekat proizvodIzKorpeResponse
            rezultat.Podaci.Add(proizvodIzKorpeResponse);
        }

        return rezultat;
    }
}
