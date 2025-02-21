@ModelType Examen.Cliente
@Code
    ViewData("Title") = "Detalles"
End Code

<h2>Detalles</h2>

<div>
    <h4>Cliente</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Cliente)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cliente)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Telefono)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Telefono)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Correo)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Correo)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Editar", "Editar", New With {.id = Model.Id}) |
    @Html.ActionLink("Atrás", "Index")
</p>
