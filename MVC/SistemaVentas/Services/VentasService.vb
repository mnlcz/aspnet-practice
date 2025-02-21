Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports Dapper

Public Class VentasService
    Implements IVentasService

    Private ReadOnly _connectionString As String
    Private sql As String =
            "SELECT ventasitems.ID, ventas.IDCliente, ventas.Fecha, ventas.Total, productos.Nombre, productos.Precio, productos.Categoria, ventasitems.PrecioUnitario, ventasitems.Cantidad, ventasitems.PrecioTotal FROM ventasitems INNER JOIN ventas ON ventasitems.IDVenta = ventas.ID INNER JOIN productos ON ventasitems.IDProducto = productos.ID"

    Public Sub New()
        _connectionString = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
    End Sub

    Public Async Function Ventas() As Task(Of List(Of ReporteVentaViewModel)) Implements IVentasService.Ventas
        Using conn As New SqlConnection(_connectionString)
            Return Await conn.QueryAsync(Of ReporteVentaViewModel)(sql)
        End Using
    End Function

    Public Async Function Venta(id As Integer) As Task(Of ReporteVentaViewModel) Implements IVentasService.Venta
        Using conn As New SqlConnection(_connectionString)
            Return Await conn.QueryFirstOrDefaultAsync(Of ReporteVentaViewModel)(sql & " WHERE ventasitems.ID = @Id", New With {id})
        End Using
    End Function

    Public Async Function VentaIndividual(id As Integer) As Task(Of VentaViewModel) Implements IVentasService.VentaIndividual
        Using conn As New SqlConnection(_connectionString)
            Return Await conn.QueryFirstOrDefaultAsync(Of VentaViewModel)("SELECT * FROM ventasitems WHERE ID = @Id", New With {id})
        End Using
    End Function

    Public Async Function Crear(venta As VentaViewModel) As Task Implements IVentasService.Crear
        Using conn As New SqlConnection(_connectionString)
            Await conn.OpenAsync().ConfigureAwait(False)
            Dim dbVenta As New With {
                venta.IDCliente,
                .Fecha = DateTime.Now,
                .Total = venta.PrecioTotal
            }
            Dim idVenta As Integer = Await conn.ExecuteScalarAsync(Of Integer)("INSERT INTO ventas (IDCliente, Fecha, Total) VALUES (@IDCliente, @Fecha, @Total); SELECT CAST(SCOPE_IDENTITY() as int)", dbVenta)
            Dim dbVentaItem As New With {
                idVenta,
                venta.IDProducto,
                venta.PrecioUnitario,
                venta.Cantidad,
                venta.PrecioTotal
            }
            Await conn.ExecuteAsync("INSERT INTO ventasitems (IDVenta, IDProducto, PrecioUnitario, Cantidad, PrecioTotal) VALUES (@IDVenta, @IDProducto, @PrecioUnitario, @Cantidad, @PrecioTotal)", dbVentaItem)
        End Using
    End Function

    ' FIXME
    Public Async Function Editar(venta As VentaViewModel, id As Integer) As Task Implements IVentasService.Editar
        Using conn As New SqlConnection(_connectionString)
            Await conn.OpenAsync()
            Dim dbVenta As New With {
                venta.IDCliente,
                .Fecha = DateTime.Now,
                .Total = venta.PrecioTotal
            }
            Await conn.ExecuteScalarAsync(Of Integer)("UPDATE ventas SET IDCliente = @IDCliente, Fecha = @Fecha, Total = @Total WHERE ID = @ID", New With {dbVenta, id})
            Dim dbVentaItem As New With {
                id,
                venta.IDProducto,
                venta.PrecioUnitario,
                venta.Cantidad,
                venta.PrecioTotal
            }
            Await conn.ExecuteAsync("UPDATE ventasitems SET IDVenta = @IDVenta, IDProducto = @IDProducto, PrecioUnitario = @PrecioUnitario, Cantidad = @Cantidad, PrecioTotal = @PrecioTotal WHERE ID = @ID", dbVentaItem)
        End Using
    End Function

    ' FIXME
    Public Async Function Borrar(id As Integer) As Task Implements IVentasService.Borrar
        Throw New NotImplementedException()
    End Function
End Class
