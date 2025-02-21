@ModelType Examen.Producto
@Code
    ViewData("Title") = "Detalles"
End Code

<h2>Detalles</h2>

<div>
    <h4>Producto</h4>
    <hr />
    <dl class="dl-horizontal">
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

    </dl>
</div>
<p>
    @Html.ActionLink("Editar", "Editar", New With {.id = Model.Id}) |
    @Html.ActionLink("Atrás", "Index")
</p>
