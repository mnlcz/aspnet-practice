Imports System.Threading.Tasks
Imports System.Web.Mvc

Namespace Controllers
    Public Class ProductosController
        Inherits Controller

        Private ReadOnly _productoService As IProductoService

        Public Sub New()
            _productoService = New ProductoService()
        End Sub

        ' GET: Productos
        Public Async Function Index() As Task(Of ActionResult)
            Dim productos As List(Of Producto) = Await _productoService.Productos()
            Return View(productos)
        End Function

        ' GET: Productos/Detalles/5
        Public Async Function Detalles(ByVal id As Integer) As Task(Of ActionResult)
            Dim producto As Producto = Await _productoService.Producto(id)
            Return View(producto)
        End Function

        ' GET: Productos/Buscar
        Public Async Function Buscar(ByVal filtros As List(Of IProductoService.Filtros), ByVal busqueda As String) As Task(Of ActionResult)
            Dim productos As List(Of Producto) = Await _productoService.Producto(filtros, busqueda)
            Return View("Index", productos)
        End Function

        ' GET: Productos/Crear
        Public Function Crear() As ActionResult
            Return View()
        End Function

        ' POST: Productos/Crear
        <HttpPost()>
        Public Async Function Crear(ByVal collection As FormCollection) As Task(Of ActionResult)
            Try
                Await _productoService.Crear(New Producto() With {
                    .Nombre = collection("Nombre"),
                    .Categoria = collection("Categoria"),
                    .Precio = collection("Precio")
                })

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Productos/Editar/5
        Public Async Function Editar(ByVal id As Integer) As Task(Of ActionResult)
            Dim producto As Producto = Await _productoService.Producto(id)
            Return View(producto)
        End Function

        ' POST: Productos/Editar/5
        <HttpPost()>
        Public Async Function Editar(ByVal id As Integer, ByVal collection As FormCollection) As Task(Of ActionResult)
            Try
                Dim aEditar As New Producto() With {
                    .Id = id,
                    .Nombre = collection("Nombre"),
                    .Categoria = collection("Categoria"),
                    .Precio = collection("Precio")
                }

                If Await _productoService.Producto(aEditar.Id) Is Nothing Then
                    Return HttpNotFound()
                End If

                Await _productoService.Editar(aEditar)

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Productos/Borrar/5
        Public Async Function Borrar(ByVal id As Integer) As Task(Of ActionResult)
            Dim producto As Producto = Await _productoService.Producto(id)
            Return View(producto)
        End Function

        ' POST: Productos/Borrar/5
        <HttpPost()>
        Public Async Function Borrar(ByVal id As Integer, ByVal collection As FormCollection) As Task(Of ActionResult)
            Try
                Dim aBorrar As New Producto() With {
                    .Id = id,
                    .Nombre = collection("Nombre"),
                    .Categoria = collection("Categoria"),
                    .Precio = collection("Precio")
                }

                If Await _productoService.Producto(aBorrar.Id) Is Nothing Then
                    Return HttpNotFound()
                End If

                Await _productoService.Borrar(aBorrar.Id)

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace