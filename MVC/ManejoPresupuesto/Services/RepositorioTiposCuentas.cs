using Dapper;
using ManejoPresupuesto.Models;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuesto.Services;

public class RepositorioTiposCuentas(IConfiguration configuration) : IRepositorioTiposCuentas
{
    private readonly string? _connectionString = configuration.GetConnectionString("DefaultConnection");

    public async Task Crear(TipoCuenta tipoCuenta)
    {
        await using var connection = new SqlConnection(_connectionString);
        var id = await connection.QuerySingleAsync<int>("TiposCuentas_Insertar",
            new { usuarioId = tipoCuenta.UsuarioId, nombre = tipoCuenta.Nombre },
            commandType: System.Data.CommandType.StoredProcedure);

        tipoCuenta.Id = id;
    }

    public async Task<bool> Existe(string nombre, int usuarioId)
    {
        await using var connection = new SqlConnection(_connectionString);
        var existe = await connection.QueryFirstOrDefaultAsync<int>("""
                                                                    SELECT 1
                                                                    FROM TiposCuentas 
                                                                    WHERE Nombre = @Nombre AND UsuarioId = @UsuarioId;
                                                                    """,
            new { Nombre = nombre, UsuarioId = usuarioId });

        return existe == 1;
    }

    public async Task<IEnumerable<TipoCuenta>> Obtener(int usuarioId)
    {
        await using var connection = new SqlConnection(_connectionString);

        return await connection.QueryAsync<TipoCuenta>("""
                                                       SELECT Id, Nombre, UsuarioId, Orden 
                                                       FROM TiposCuentas 
                                                       WHERE UsuarioId = @UsuarioId
                                                       ORDER BY Orden;
                                                       """, new { usuarioId });
    }

    public async Task Actualizar(TipoCuenta tipoCuenta)
    {
        await using var connection = new SqlConnection(_connectionString);

        await connection.ExecuteAsync("""
                                      UPDATE TiposCuentas
                                      SET Nombre = @Nombre
                                      WHERE Id = @Id;
                                      """, tipoCuenta);
    }

    public async Task<TipoCuenta?> ObtenerPorId(int id, int usuarioId)
    {
        await using var connection = new SqlConnection(_connectionString);

        return await connection.QueryFirstOrDefaultAsync<TipoCuenta>("""
                                                                     SELECT Id, Nombre, UsuarioId, Orden
                                                                     FROM TiposCuentas
                                                                     WHERE Id = @Id AND UsuarioId = @UsuarioId;
                                                                     """, new { Id = id, UsuarioId = usuarioId });
    }

    public async Task Borrar(int id)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync("DELETE FROM TiposCuentas WHERE Id = @Id;", new { Id = id });
    }

    public async Task Ordenar(IEnumerable<TipoCuenta> tipoCuentasOrdenados)
    {
        var query = "UPDATE TiposCuentas SET Orden = @Orden WHERE Id = @Id;";
        await using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(query, tipoCuentasOrdenados);
    }
}