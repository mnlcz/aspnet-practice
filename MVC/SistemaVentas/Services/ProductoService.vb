Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports Dapper

Public Class ProductoService
    Implements IProductoService

    Private ReadOnly _connectionString As String

    Public Sub New()
        _connectionString = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
    End Sub

    Public Async Function Productos() As Task(Of List(Of Producto)) Implements IProductoService.Productos
        Using conn As New SqlConnection(_connectionString)
            Return Await conn.QueryAsync(Of Producto)("SELECT * FROM Productos")
        End Using
    End Function

    Public Async Function Producto(id As Integer) As Task(Of Producto) Implements IProductoService.Producto
        Using conn As New SqlConnection(_connectionString)
            Return Await conn.QueryFirstOrDefaultAsync(Of Producto)("SELECT * FROM Productos WHERE Id = @Id", New With {id})
        End Using
    End Function

    ' En caso de que se quiere hacer el filtro en el backend y no con jQuery
    Public Async Function Producto(filtros As List(Of IProductoService.Filtros), busqueda As String) As Task(Of List(Of Producto)) Implements IProductoService.Producto
        Using conn As New SqlConnection(_connectionString)
            Dim sql As String = "SELECT * FROM Productos WHERE "
            If filtros.Contains(IProductoService.Filtros.Nombre) Then
                sql &= "Nombre LIKE @Busqueda AND "
            End If
            If filtros.Contains(IProductoService.Filtros.Categoria) Then
                sql &= "Categoria LIKE @Busqueda AND "
            End If
            If filtros.Contains(IProductoService.Filtros.Precio) Then
                sql &= "Precio LIKE @Busqueda"
            End If

            If sql.EndsWith("AND ") Then
                sql = sql.Substring(0, sql.Length - 4)
            End If

            Return Await conn.QueryAsync(Of Producto)(sql)
        End Using
    End Function

    Public Async Function Crear(producto As Producto) As Task Implements IProductoService.Crear
        Using conn As New SqlConnection(_connectionString)
            Await conn.ExecuteAsync("INSERT INTO Productos (Nombre, Categoria, Precio) VALUES (@Nombre, @Categoria, @Precio)", producto)
        End Using
    End Function

    Public Async Function Editar(producto As Producto) As Task Implements IProductoService.Editar
        Using conn As New SqlConnection(_connectionString)
            Await conn.ExecuteAsync("UPDATE Productos SET Nombre = @Nombre, Categoria = @Categoria, Precio = @Precio WHERE Id = @Id", producto)
        End Using
    End Function

    Public Async Function Borrar(id As Integer) As Task Implements IProductoService.Borrar
        Using conn As New SqlConnection(_connectionString)
            Await conn.ExecuteAsync("DELETE FROM Productos WHERE Id = @Id", New With {id})
        End Using
    End Function
End Class
