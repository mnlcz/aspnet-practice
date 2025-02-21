@ModelType Examen.Producto
@Code
    ViewData("Title") = "Borrar"
End Code

<h2>Borrar</h2>

<h3>¿Seguro que desea borrar esta entrada?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Borrar" class="btn btn-default" /> |
            @Html.ActionLink("Atrás", "Index")
        </div>
    End Using
</div>
