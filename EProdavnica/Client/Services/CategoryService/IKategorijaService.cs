namespace EProdavnica.Client.Services.CategoryService;

public interface IKategorijaService
{
    List<Kategorija> Kategorije {  get; set; }
    Task GetKategorije();
}
