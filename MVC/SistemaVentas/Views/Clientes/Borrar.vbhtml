@ModelType Examen.Cliente
@Code
    ViewData("Title") = "Borrar"
End Code

<h2>Borrar</h2>

<h3>¿Seguro que desea borrar esta entrada?</h3>
<div>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Borrar" class="btn btn-default" /> |
            @Html.ActionLink("Atrás", "Index")
        </div>
    End Using
</div>
