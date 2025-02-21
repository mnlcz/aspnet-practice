@ModelType IEnumerable(Of ReporteMensualViewModel)
@Code
    ViewData("Title") = "Ventas Mensuales"
End Code

<h2>Ventas Mensuales</h2>

<table class="table">
    <tr>
        <th>Producto</th>
        <th>Mes</th>
        <th>Total</th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>@Html.DisplayFor(Function(modelItem) item.Nombre)</td>
            <td>@Html.DisplayFor(Function(modelItem) item.Mes)</td>
            <td>@Html.DisplayFor(Function(modelItem) item.Total)</td>
        </tr>
    Next
</table>

<div>
    @Html.ActionLink("Atrás", "Index")
</div>
