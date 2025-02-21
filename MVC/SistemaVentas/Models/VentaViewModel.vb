Public Class VentaViewModel
    Public Property IDProducto As Integer
    Public Property IDCliente As Integer
    Public Property Cantidad As Integer
    Public Property PrecioUnitario As Decimal

    Public ReadOnly Property PrecioTotal As Decimal
        Get
            Return Cantidad * PrecioUnitario
        End Get
    End Property
End Class
