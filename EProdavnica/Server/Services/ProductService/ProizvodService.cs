
using System.Net.WebSockets;

namespace EProdavnica.Server.Services.ProductService;

public class ProizvodService : IProizvodService
{
    private readonly DataContext _context;

    public ProizvodService(DataContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<List<string>>> GetPredloziZaPretraguProizvodaAsync(string tekstPretrage)
    {
        var proizvodi = await PronadjiProizvodePoTekstuPretrage(tekstPretrage);

        List<string> rezultat = new();

        foreach (var proizvod in proizvodi) 
        {
            //proveravamo da li se tekstPretrage sadrzi u nazivu bilo kog proizvoda
            if (proizvod.Naziv.Contains(tekstPretrage, StringComparison.OrdinalIgnoreCase))
            {
                // ako naziv proizvoda tog proizvoda sadrzi tekst pretrage onda se on dodaje u listu stringova
                rezultat.Add(proizvod.Naziv);
            }

            if(proizvod.Opis != null)
            {
                //ova promenljiva sadrzi sve znakove interpunkcije iz opisa proizvoda, po jedan od svakog
                var interpunkcija = proizvod.Opis.Where(char.IsPunctuation).Distinct().ToArray();

                //ova promenljkiva sadrzi niz reci bez znakova intepunkcije u njima
                var reci = proizvod.Opis.Split()
                        .Select(s => s.Trim(interpunkcija));

                //Dodajemo foreach koji ce za svaku rec iz niza reci da proveri da li sadrzi tekstPretrage i ako ga sadrzi da li se vec ne nalazi u promenljivoj rezultat (sadrzi sve odgovarajuce predloge).
                foreach (var rec in reci)
                {
                    if(rec.Contains(tekstPretrage, StringComparison.OrdinalIgnoreCase) && !rezultat.Contains(rec))
                    {
                        rezultat.Add(rec);
                    }
                }
            }
        }

        return new ServiceResponse<List<string>> { Podaci = rezultat };
    }

    public async Task<ServiceResponse<Proizvod>> GetProizvodAsync(int proizvodId)
    {
        var response = new ServiceResponse<Proizvod>();
        var proizvod = await _context.Proizvodi
            .Include(p => p.Varijante)
            .ThenInclude(v => v.TipProizvoda)
            .FirstOrDefaultAsync(p => p.Id == proizvodId);
        
        if(proizvod == null) 
        {
            response.Uspesno = false;
            response.Poruka = "Traženi proizvod ne postoji!";
        }
        else
        {
            response.Podaci = proizvod;
        }
        
        return response;
    }

    public async Task<ServiceResponse<List<Proizvod>>> GetProizvodiAsync()
    {
        var response = new ServiceResponse<List<Proizvod>>
        {
            Podaci = await _context.Proizvodi.Include(p => p.Varijante).ToListAsync()
        };

        return response;
    }

    public async Task<ServiceResponse<List<Proizvod>>> GetProizvodiByKategorijaAsync(string kategorijaUrl)
    {
        var response = new ServiceResponse<List<Proizvod>>
        {
            Podaci = await _context.Proizvodi
                .Where(p => p.Kategorija.Url.ToLower().Equals(kategorijaUrl))
                .Include(p => p.Varijante)
                .ToListAsync()
        };

        return response;
       
    }

    public async Task<ServiceResponse<List<Proizvod>>> PretragaProizvodaAsync(string tekstPretrage)
    {
        var response = new ServiceResponse<List<Proizvod>>
        {

            
            Podaci = await PronadjiProizvodePoTekstuPretrage(tekstPretrage)
        };

        return response;
    }

    private async Task<List<Proizvod>> PronadjiProizvodePoTekstuPretrage(string tekstPretrage)
    {
        // 1. trazimo proizvod koji  ili u svom nazivu sadrzi tekstPretrage ili u svom opisu, zatim ukljucujemo u zahtev podataka iz baze i podatke o varijantama i zatim sve to pretvaramo u listu.
        return await _context.Proizvodi
                        .Where(p => p.Naziv.ToLower().Contains(tekstPretrage.ToLower())
                               ||
                               p.Opis.ToLower().Contains(tekstPretrage.ToLower()))
                        .Include(p => p.Varijante)
                        .ToListAsync();
    }
}
