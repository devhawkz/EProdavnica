using EProdavnica.Shared.DTO;

namespace EProdavnica.Server.Services.CartService;

public interface IKorpaService
{
    // metoda koja pretvara proizvode iz korpe sa info o ProizvodId i TipProizvodaId u proizvod sa svim mogucim info(naziv,slika,cena,tip...)
    Task<ServiceResponse<List<ProizvodiUKorpiResponse>>> GetProizvodeIzKorpeAsync(List<ProizvodUKorpi> proizvodiIzKorpe);

}
