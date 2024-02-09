using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EProdavnica.Shared;

public class VarijantaProizvoda
{
    [JsonIgnore]
    public Proizvod Proizvod { get; set; }
    
    public int ProizvodId { get; set; }
    
    public TipProizvoda TipProizvoda { get; set; }
    
    public int TipProizvodaId { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Cena { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal OriginalnaCena { get; set; }
}

