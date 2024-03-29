﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EProdavnica.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("registracija")]
    public async Task<ActionResult<ServiceResponse<int>>> Registracija(RegistracijaKorisnika zahtev)
    {
        var response = await _authService.RegistracijaAsync(
            new Korisnik 
        { 
            Email = zahtev.Email 
        }, 
        zahtev.Lozinka);

        // proverava da li je korisnik sa tom mejl adresom vec kreiran
        if(!response.Uspesno)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpPost("prijava")]
    public async Task<ActionResult<ServiceResponse<string>>> Prijava(PrijavaKorisnika zahtev)
    {
        var response = await _authService.PrijavaAsync(zahtev.Email, zahtev.Lozinka);
        if (!response.Uspesno)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpPost("promena-lozinke"), Authorize]
    public async Task<ActionResult<ServiceResponse<bool>>> PromenaLozinke([FromBody] string novaLozinka)
    {
        var korisnikId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var response = await _authService.PromenaLozinkeAsync(int.Parse(korisnikId), novaLozinka);

        if (!response.Uspesno)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
}
