using Dapper;
using ManejoPresupuesto.Models;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuesto.Services;

public class RepositorioCuentas(IConfiguration configuration) : IRepositorioCuentas
{
    private readonly string? _connectionString = configuration.GetConnectionString("DefaultConnection");

    public async Task Crear(Cuenta cuenta)
    {
        await using var connection = new SqlConnection(_connectionString);
        var id = await connection.QuerySingleAsync<int>("""
                                                        INSERT INTO Cuentas (Nombre, TipoCuentaId, Descripcion, Balance)
                                                        VALUES (@Nombre, @TipoCuentaId, @Descripcion, @Balance);
                                                        SELECT SCOPE_IDENTITY();
                                                        """, cuenta);
        cuenta.Id = id;
    }
}