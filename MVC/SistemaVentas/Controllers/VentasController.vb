Imports System.Threading.Tasks

Namespace Controllers
    Public Class VentasController
        Inherits Controller

        Private ReadOnly _ventasService As IVentasService

        Public Sub New()
            _ventasService = New VentasService()
        End Sub

        ' GET: Ventas
        Public Async Function Index() As Task(Of ActionResult)
            Dim ventas As List(Of ReporteVentaViewModel) = Await _ventasService.Ventas()
            Return View(ventas)
        End Function

        ' GET: Ventas/Detalles/5
        Public Async Function Detalles(ByVal id As Integer) As Task(Of ActionResult)
            Dim venta As ReporteVentaViewModel = Await _ventasService.Venta(id)
            Return View(venta)
        End Function

        ' GET: Ventas/Crear
        Public Function Crear() As ActionResult
            Return View()
        End Function

        ' POST: Ventas/Crear
        <HttpPost()>
        Public Async Function Crear(ByVal collection As FormCollection) As Task(Of ActionResult)
            Try
                Await _ventasService.Crear(New VentaViewModel() With {
                    .IDCliente = collection("IDCliente"),
                    .IDProducto = collection("IDProducto"),
                    .PrecioUnitario = collection("PrecioUnitario"),
                    .Cantidad = collection("Cantidad")
                })

                Return RedirectToAction("Index")
            Catch
            End Try
        End Function

        ' GET: Ventas/Editar/5
        Public Async Function Editar(ByVal id As Integer) As Task(Of ActionResult)
            Dim venta As VentaViewModel = Await _ventasService.VentaIndividual(id)
            Return View(venta)
        End Function

        ' POST: Ventas/Editar/5
        <HttpPost()>
        Public Async Function Editar(ByVal id As Integer, ByVal collection As FormCollection) As Task(Of ActionResult)
            Try
                Dim aEditar As New VentaViewModel() With {
                    .IDCliente = collection("IDCliente"),
                    .IDProducto = collection("IDProducto"),
                    .PrecioUnitario = collection("PrecioUnitario"),
                    .Cantidad = collection("Cantidad")
                }

                If Await _ventasService.VentaIndividual(id) Is Nothing Then
                    Return HttpNotFound()
                End If

                Await _ventasService.Editar(aEditar, id)

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Ventas/Borrar/5
        Public Async Function Borrar(ByVal id As Integer) As Task(Of ActionResult)
            Throw New NotImplementedException()
        End Function

        ' POST: Ventas/Borrar/5
        <HttpPost()>
        Public Async Function Borrar(ByVal id As Integer, ByVal collection As FormCollection) As Task(Of ActionResult)
            Throw New NotImplementedException()
        End Function

        ' GET: Ventas/Mensual
        Public Async Function Mensual() As Task(Of ActionResult)
            Dim ventas As List(Of ReporteVentaViewModel) = Await _ventasService.Ventas()

            ' Group sales by Product Name and Month
            Dim groupedVentas = ventas _
                .GroupBy(Function(x) New With {
                    Key .ProductName = x.Nombre,
                    Key .Month = x.Fecha.Month,
                    Key .Year = x.Fecha.Year
                }) _
                .Select(Function(g) New ReporteMensualViewModel With {
                    .Nombre = g.Key.ProductName,
                    .Mes = g.Key.Month & "/" & g.Key.Year,
                    .Total = g.Sum(Function(x) x.PrecioTotal)
                }).ToList()

            Return View(groupedVentas)
        End Function

    End Class
End Namespace