Imports System.Threading.Tasks

Public Interface IClienteService
    Enum Filtros
        Nombre
        Telefono
        Correo
    End Enum

    Function Clientes() As Task(Of List(Of Cliente))
    Function Cliente(ByVal id As Integer) As Task(Of Cliente)
    Function Cliente(filtros As List(Of Filtros), ByVal busqueda As String) As Task(Of List(Of Cliente))
    Function Crear(ByVal cliente As Cliente) As Task
    Function Editar(ByVal cliente As Cliente) As Task
    Function Borrar(ByVal id As Integer) As Task
End Interface
