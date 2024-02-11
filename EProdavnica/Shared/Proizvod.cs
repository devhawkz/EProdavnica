using System.ComponentModel.DataAnnotations.Schema;
namespace EProdavnica.Shared;

public class Proizvod
{
    public int Id { get; set; }
    
    public string Naziv { get; set; } = string.Empty;
    
    public string Opis { get; set;} = string.Empty;
    
    public string SlikaUrl { get; set; } = string.Empty;

    public Kategorija? Kategorija { get; set; }

    public int KategorijaId {  get; set; }

    public bool Preporuceni { get; set; } = false;

    public List<VarijantaProizvoda> Varijante { get; set; } = new List<VarijantaProizvoda>();
}
