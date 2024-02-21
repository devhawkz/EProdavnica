using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace BlazorEcommerce.Client;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _lokalnoSkladiste;
    private readonly HttpClient _http;

    public CustomAuthStateProvider(ILocalStorageService lokalnoSkladiste, HttpClient http)
    {
        _lokalnoSkladiste = lokalnoSkladiste;
        _http = http;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        string authToken = await _lokalnoSkladiste.GetItemAsStringAsync("authToken");

        var identitet = new ClaimsIdentity();
        _http.DefaultRequestHeaders.Authorization = null;

        if (!string.IsNullOrEmpty(authToken))
        {
            try
            {
                identitet = new ClaimsIdentity(ParseClaimsFromJwt(authToken), "jwt");
                _http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", authToken.Replace("\"", ""));
            }
            catch
            {
                await _lokalnoSkladiste.RemoveItemAsync("authToken");
                identitet = new ClaimsIdentity();
            }
        }

        var korisnik = new ClaimsPrincipal(identitet);
        var stanje = new AuthenticationState(korisnik);

        NotifyAuthenticationStateChanged(Task.FromResult(stanje));

        return stanje;
    }

    private byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        return Convert.FromBase64String(base64);
    }

    private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var payload = jwt.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer
            .Deserialize<Dictionary<string, object>>(jsonBytes);

        var claims = keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));

        return claims;
    }
}