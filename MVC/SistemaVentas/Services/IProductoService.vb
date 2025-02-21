Imports System.Threading.Tasks

Public Interface IProductoService
    Enum Filtros
        Nombre
        Precio
        Categoria
    End Enum

    Function Productos() As Task(Of List(Of Producto))
    Function Producto(ByVal id As Integer) As Task(Of Producto)
    Function Producto(filtros As List(Of Filtros), ByVal busqueda As String) As Task(Of List(Of Producto))
    Function Crear(ByVal producto As Producto) As Task
    Function Editar(ByVal producto As Producto) As Task
    Function Borrar(ByVal id As Integer) As Task
End Interface
