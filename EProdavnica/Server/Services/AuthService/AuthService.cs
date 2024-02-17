
using System.Security.Cryptography;

namespace EProdavnica.Server.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;

        public AuthService(DataContext context)
        {
            _context = context;
        }
        
        public async Task<bool> KorisnikPostojiAsync(string email)
        {
            // ova linija proverava da li postoji korisnik sa datim mejlom u bazi (da li je korisnik sa tim mejlom vec registrovan), ako je tacno vraca true vrednost
            if (await _context.Korisnici.AnyAsync(korisnik => korisnik.Email.ToLower().Equals(email.ToLower())))
            {
                return true;
            }

            return false;
        }

        public async Task<ServiceResponse<int>> RegistracijaAsync(Korisnik korisnik, string lozinka)
        {
            if(await KorisnikPostojiAsync(korisnik.Email))
            {
                return new ServiceResponse<int> 
                { 
                    Uspesno = false, 
                    Poruka = "Korisnik sa tom mejl adresom već postoji." 
                };
            }

            KreirajHashLozinke(lozinka, out byte[] lozinkaHash, out byte[] lozinkaSalt);

            korisnik.LozinkaHash = lozinkaHash;
            korisnik.LozinkaSalt = lozinkaSalt;

            // dodajemo novog korisnika u bazu
            _context.Korisnici.Add(korisnik);

            await _context.SaveChangesAsync();

            return new ServiceResponse<int> 
            { 
                Podaci = korisnik.Id,
                Poruka = "Uspešna registracija."
            }; 
        }

        private void KreirajHashLozinke(string lozinka, out byte[] lozinkaHash, out byte[] lozinkaSalt)
        {
            // resursi se oslobadjaju nakon zavrsetka bloka
            using(var hmac = new HMACSHA512())
            {
                // dobijamo salt lozinke
                lozinkaSalt = hmac.Key; 

                // hesiramo unetu vrednost lozinke, string pretvaramo u niz bajtova i tako dobijamo lozinkaHash
                lozinkaHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(lozinka));
            }
        }
    }
}
