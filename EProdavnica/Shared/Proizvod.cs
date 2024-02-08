using System.ComponentModel.DataAnnotations.Schema;
namespace EProdavnica.Shared;

public class Proizvod
{
    public int Id { get; set; }
    
    public string Naziv { get; set; } = string.Empty;
    
    public string Opis { get; set;} = string.Empty;
    
    public string SlikaUrl { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    public decimal Cena { get; set; }

    public Kategorija? Kategorija { get; set; }

    public int KategorijaId {  get; set; }
}
