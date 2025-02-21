Imports System.Threading.Tasks

Namespace Controllers
    Public Class ClientesController
        Inherits Controller

        Private ReadOnly _clienteService As IClienteService

        Public Sub New()
            _clienteService = New ClienteService()
        End Sub

        ' GET: Clientes
        Public Async Function Index() As Task(Of ActionResult)
            Dim clientes As List(Of Cliente) = Await _clienteService.Clientes()
            Return View(clientes)
        End Function

        ' GET: Clientes/Detalles/5
        Public Async Function Detalles(ByVal id As Integer) As Task(Of ActionResult)
            Dim cliente As Cliente = Await _clienteService.Cliente(id)
            Return View(cliente)
        End Function

        ' GET: Clientes/Buscar
        Public Async Function Buscar(ByVal filtros As List(Of IClienteService.Filtros), ByVal busqueda As String) As Task(Of ActionResult)
            Dim clientes As List(Of Cliente) = Await _clienteService.Cliente(filtros, busqueda)
            Return View("Index", clientes)
        End Function

        ' GET: Clientes/Crear
        Public Function Crear() As ActionResult
            Return View()
        End Function

        ' POST: Clientes/Crear
        <HttpPost()>
        Public Async Function Crear(ByVal collection As FormCollection) As Task(Of ActionResult)
            Try
                Await _clienteService.Crear(New Cliente() With {
                    .Cliente = collection("Cliente"),
                    .Telefono = collection("Telefono"),
                    .Correo = collection("Correo")
                })
                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Clientes/Editar/5
        Public Async Function Editar(ByVal id As Integer) As Task(Of ActionResult)
            Dim cliente As Cliente = Await _clienteService.Cliente(id)
            Return View(cliente)
        End Function

        ' POST: Clientes/Editar/5
        <HttpPost()>
        Public Async Function Editar(ByVal id As Integer, ByVal collection As FormCollection) As Task(Of ActionResult)
            Try
                Dim aEditar As New Cliente() With {
                    .Id = id,
                    .Cliente = collection("Cliente"),
                    .Telefono = collection("Telefono"),
                    .Correo = collection("Correo")
                }

                If Await _clienteService.Cliente(aEditar.Id) Is Nothing Then
                    Return HttpNotFound()
                End If

                Await _clienteService.Editar(aEditar)

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Clientes/Borrar/5
        Public Async Function Borrar(ByVal id As Integer) As Task(Of ActionResult)
            Dim cliente As Cliente = Await _clienteService.Cliente(id)
            Return View(cliente)
        End Function

        ' POST: Clientes/Borrar/5
        <HttpPost()>
        Public Async Function Borrar(ByVal id As Integer, ByVal collection As FormCollection) As Task(Of ActionResult)
            Try
                Dim aBorrar As New Cliente() With {
                    .Id = id,
                    .Cliente = collection("Cliente"),
                    .Telefono = collection("Telefono"),
                    .Correo = collection("Correo")
                }

                If Await _clienteService.Cliente(aBorrar.Id) Is Nothing Then
                    Return HttpNotFound()
                End If

                Await _clienteService.Borrar(aBorrar.Id)

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace