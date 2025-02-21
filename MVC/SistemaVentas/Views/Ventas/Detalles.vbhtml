@ModelType Examen.ReporteVentaViewModel
@Code
    ViewData("Title") = "Detalles"
End Code

<h2>Detalles</h2>

<div>
    <h4>VentasViewModel</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.IdCliente)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IdCliente)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Fecha)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Fecha)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Total)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Total)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Nombre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Precio)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Precio)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Categoria)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Categoria)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Cantidad)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cantidad)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PrecioUnitario)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PrecioUnitario)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PrecioTotal)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PrecioTotal)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Id }) |
    @Html.ActionLink("Back to List", "Index")
</p>
