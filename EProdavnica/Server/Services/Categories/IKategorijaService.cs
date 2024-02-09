namespace EProdavnica.Server.Services.Categories;

public interface IKategorijaService
{
    Task<ServiceResponse<List<Kategorija>>> GetKategorijeAsync();
}
