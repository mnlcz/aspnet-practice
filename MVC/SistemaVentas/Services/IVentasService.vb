Imports System.Threading.Tasks

Public Interface IVentasService
    Enum Filtros
        IDVenta
        IDProducto
        IDCliente
        PrecioUnitario
        Cantidad
        Fecha
        PrecioTotal
        VentasTotal
    End Enum

    Function Ventas() As Task(Of List(Of ReporteVentaViewModel))
    Function Venta(ByVal id As Integer) As Task(Of ReporteVentaViewModel)
    Function VentaIndividual(ByVal id As Integer) As Task(Of VentaViewModel)
    Function Crear(ByVal venta As VentaViewModel) As Task
    Function Editar(ByVal venta As VentaViewModel, ByVal id As Integer) As Task
    Function Borrar(ByVal id As Integer) As Task
End Interface
