using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EProdavnica.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProizvodController : ControllerBase
{
    private static List<Proizvod> proizvodi = new()
    {
        new Proizvod
        {
            Id = 1,
            Naziv = "WTL MIG 315",
            Opis = "Aparat za poluautomatsko zavarivanje u zastiti gasa.",
            SlikaUrl = "https://www.sualati.com/files/product_picture/2019.07.11.14.16.25_5d272899aaebd_mig315a.jpg",
            Cena = 9.99m
        },

        new Proizvod
        {
            Id = 2,
            Naziv = "WTL EASY JOB 200E",
            Opis = "Savrsen za kucnu upotrebu i lakse radionicke poslove!elektrolucni aparat , za celik i prohron",
            SlikaUrl = "https://www.sualati.com/files/product_picture/605c73c8ac430_wtl-easy-job-200.jpg",
            Cena = 15.99m
        },

        new Proizvod
        {
            Id = 3,
            Naziv = "WTL MIG 350F",
            Opis = "MIG/MAG Aparat za poluautomatsko zavarivanje u zaštiti gasa u izvedbi sa odvojenim dodvačem žice",
            SlikaUrl = "https://www.sualati.com/files/product_picture/2019.07.11.14.53.23_5d2731434735b_mig-350-a-wtl.jpg",
            Cena = 5.99m
        }
    };

    [HttpGet]
    public async Task<ActionResult <List<Proizvod>>> GetProizvod()
    {
        return Ok(proizvodi);
    }
}
