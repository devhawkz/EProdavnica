﻿using EProdavnica.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EProdavnica.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProizvodController : ControllerBase
{
    private readonly IProizvodService _proizvodiService;

    public ProizvodController(IProizvodService proizvodiService)
    {
        _proizvodiService = proizvodiService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Proizvod>>>> GetProizvodi()
    {
        var rezultat = await _proizvodiService.GetProizvodiAsync();
        return Ok(rezultat);
    }

    [HttpGet("{proizvodId}")]
    public async Task<ActionResult<ServiceResponse<Proizvod>>> GetProizvod(int proizvodId)
    {
        var rezultat = await _proizvodiService.GetProizvodAsync(proizvodId);
        return Ok(rezultat);
    }

    [HttpGet("kategorija/{kategorijaUrl}")]
    public async Task<ActionResult<ServiceResponse<Proizvod>>> GetProizvodiByKategorija(string kategorijaUrl)
    {
        var rezultat = await _proizvodiService.GetProizvodiByKategorijaAsync(kategorijaUrl);
        return Ok(rezultat);
    }

    [HttpGet("pretraga/{tekstPretrage}/{trenutnaStrana}")]
    public async Task<ActionResult<ServiceResponse<RezultatPretrageProizvoda>>> PretraziProizvode(string tekstPretrage, int trenutnaStrana = 1)
    {
        var rezultat = await _proizvodiService.PretragaProizvodaAsync(tekstPretrage, trenutnaStrana);
        return Ok(rezultat);
    }

    [HttpGet("predlozipretrage/{tekstPretrage}")]
    public async Task<ActionResult<ServiceResponse<List<Proizvod>>>> PredloziZaPretraguProizvoda(string tekstPretrage)
    {
        var rezultat = await _proizvodiService.GetPredloziZaPretraguProizvodaAsync(tekstPretrage);
        return Ok(rezultat);

    }

    [HttpGet("preporuceno")]
    public async Task<ActionResult<ServiceResponse<List<Proizvod>>>> GetPreporuceneProizvode()
    {
        var rezultat = await _proizvodiService.GetPreporuceneProizvodeAsync();
        return Ok(rezultat);

    }
}
