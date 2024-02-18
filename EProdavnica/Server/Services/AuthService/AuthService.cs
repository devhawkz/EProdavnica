using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;

namespace EProdavnica.Server.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
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

        public async Task<ServiceResponse<string>> PrijavaAsync(string email, string lozinka)
        {
            
            var response = new ServiceResponse<string>();

            // pronalazi prvog korisnika sa datom mejl adresom, ako takav korisnik ne postoji vraca null (default vrednost)
            var korisnik = await _context.Korisnici.
                FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));
            
            if(korisnik  == null) 
            {
                response.Uspesno = false;
                response.Poruka = "Korisnik nije pronađen.";
            }
            
            else if(!PotvrdaHesLozinke(lozinka, korisnik.LozinkaHash, korisnik.LozinkaSalt))
            {
                response.Uspesno = false;
                response.Poruka = "Pogrešna lozinka";
            }

            else 
            {
                response.Podaci = KreirajToken(korisnik); // za sad je ovako
            }

            return response;
        }

        private string? KreirajToken(Korisnik korisnik)
        {
            List<Claim> claims = new List<Claim>()
            {
                
                //Ova linija koda kreira novu tvrdnju (Claim) koja predstavlja identifikator imena korisnika. 
                new Claim(ClaimTypes.NameIdentifier, korisnik.Id.ToString()),
                
                //Ova linija koda kreira novu tvrdnju koja predstavlja ime korisnika. 
                new Claim(ClaimTypes.Name, korisnik.Email)
            };

            //uzima secret key sa servera 
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            //Ovaj kod kreira SigningCredentials objekat koji se koristi prilikom potpisivanja JWT tokena.
            var akreditacija = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

           // kreiranje JWT tokena
            var token = new JwtSecurityToken
                (
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: akreditacija
                );

            // konverzija JWT tokena u string
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private bool PotvrdaHesLozinke(string lozinka, byte[] lozinkaHash, byte[] lozinkaSalt)
        {
            // novoj instanci klase HMACSHA512 prosledjujemo vec generisan salt za tu mejl adresu kako bi mogao da se generise novi hes na osnovu unete lozinke prilikom prijave i kako bi mogla da se izvrsi provera o ispravnosti lozinke
            using (var hmac = new HMACSHA512(lozinkaSalt))
            {
                var izracunatiHes = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(lozinka));
                
                // vrsimo poredjenje dve sekvence (dva hesa) vraca bool vrednost
                return izracunatiHes.SequenceEqual(lozinkaHash);
            }
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
                // vrednost salta se ne koristi direktno ovde, vec se koristi vrednost koja je generisana prilikom kreiranja instance HMACSHA512
                lozinkaHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(lozinka));
            }
        }
    }
}
