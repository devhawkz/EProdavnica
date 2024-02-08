
namespace EProdavnica.Shared;

public class ServiceResponse<T>
{
    public T? Podaci { get; set; }
    public bool Uspesno { get; set; } = true;
    public string Poruka { get; set; } = string.Empty;
}
