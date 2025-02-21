Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports Dapper

Public Class ClienteService
    Implements IClienteService

    Private ReadOnly _connectionString As String

    Public Sub New()
        _connectionString = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
    End Sub

    Public Async Function Clientes() As Task(Of List(Of Cliente)) Implements IClienteService.Clientes
        Using conn As New SqlConnection(_connectionString)
            Return Await conn.QueryAsync(Of Cliente)("SELECT * FROM Clientes")
        End Using
    End Function

    Public Async Function Cliente(id As Integer) As Task(Of Cliente) Implements IClienteService.Cliente
        Using conn As New SqlConnection(_connectionString)
            Return Await conn.QueryFirstOrDefaultAsync(Of Cliente)("SELECT * FROM Clientes WHERE Id = @Id", New With {id})
        End Using
    End Function

    ' En caso de que se quiera hacer el filtro en el backend y no con jQuery
    Public Async Function Cliente(filtros As List(Of IClienteService.Filtros), busqueda As String) As Task(Of List(Of Cliente)) Implements IClienteService.Cliente
        Using conn As New SqlConnection(_connectionString)
            Dim sql As String = "SELECT * FROM Clientes WHERE "
            If filtros.Contains(IClienteService.Filtros.Nombre) Then
                sql &= "Cliente LIKE @Busqueda AND "
            End If
            If filtros.Contains(IClienteService.Filtros.Telefono) Then
                sql &= "Telefono LIKE @Busqueda AND "
            End If
            If filtros.Contains(IClienteService.Filtros.Correo) Then
                sql &= "Correo LIKE @Busqueda"
            End If

            If sql.EndsWith("AND ") Then
                sql = sql.Substring(0, sql.Length - 4)
            End If

            Return Await conn.QueryAsync(Of Cliente)(sql)
        End Using
    End Function

    Public Async Function Crear(cliente As Cliente) As Task Implements IClienteService.Crear
        Using conn As New SqlConnection(_connectionString)
            Await conn.ExecuteAsync("INSERT INTO Clientes (Cliente, Telefono, Correo) VALUES (@Cliente, @Telefono, @Correo)", cliente)
        End Using
    End Function

    Public Async Function Editar(cliente As Cliente) As Task Implements IClienteService.Editar
        Using conn As New SqlConnection(_connectionString)
            Await conn.ExecuteAsync("UPDATE Clientes SET Cliente = @Cliente, Telefono = @Telefono, Correo = @Correo WHERE Id = @Id", cliente)
        End Using
    End Function

    Public Async Function Borrar(id As Integer) As Task Implements IClienteService.Borrar
        Using conn As New SqlConnection(_connectionString)
            Await conn.ExecuteAsync("DELETE FROM Clientes WHERE Id = @Id", New With {id})
        End Using
    End Function
End Class
