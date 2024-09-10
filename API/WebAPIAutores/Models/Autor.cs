namespace WebAPIAutores.Models;

public sealed class Autor
{
    public int? Id { get; set; }
    public string? Nombre { get; set; }
    public List<Libro>? Libros { get; set; }
}
