namespace EProdavnica.Client.Services.AuthService;

public interface IAuthService
{
    Task<ServiceResponse<int>> Registracija(RegistracijaKorisnika zahtev);
}
