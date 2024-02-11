namespace EProdavnica.Client.Services.CartService;

public interface IKorpaService
{
    //aktivira se kad kod se desi neka promena u korpi
    event Action OnChange;

    Task DodajUKorpu(ProizvodUKorpi proizvodUKorpi);

    // pre nego sto obrisemo proizvod iz korpe uzimamo sve proizvode iz korpe
    Task<List<ProizvodUKorpi>> GetProizvodeUKorpi();
}
