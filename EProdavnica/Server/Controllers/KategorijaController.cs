using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EProdavnica.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KategorijaController : ControllerBase
{
    private readonly IKategorijaService _kategorijaService;

    public KategorijaController(IKategorijaService kategorijaService)
    {
        _kategorijaService = kategorijaService;
    }

    [HttpGet]
    public async Task<ActionResult <ServiceResponse<List<Kategorija>>>> GetKategorije()
    {
        var rezultat = await _kategorijaService.GetKategorijeAsync();
        return Ok(rezultat);
    }
}
