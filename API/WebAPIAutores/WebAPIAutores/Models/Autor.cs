namespace WebAPIAutores.Models;

public sealed class Autor(int id, string nombre)
{
    public int Id { get; set; } = id;
    public string Nombre { get; set; } = nombre;
}
