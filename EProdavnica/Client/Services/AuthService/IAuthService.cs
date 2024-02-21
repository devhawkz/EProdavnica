namespace EProdavnica.Client.Services.AuthService;

public interface IAuthService
{
    Task<ServiceResponse<int>> Registracija(RegistracijaKorisnika zahtev);

    Task<ServiceResponse<string>> Prijava(PrijavaKorisnika zahtev);

    Task<ServiceResponse<bool>> PromenaLozinke(KorisnikPromenaLozinke zahtev);
}
