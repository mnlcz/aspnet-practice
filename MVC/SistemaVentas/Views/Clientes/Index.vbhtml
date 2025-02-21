@ModelType List(Of Cliente)
@Code
    ViewData("Title") = "Clientes"
End Code

<!DOCTYPE html>
<html>
<head>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
</head>

<body>
    <h2>Listado de Clientes</h2>

    <p>
        @Html.ActionLink("Crear", "Crear")
    </p>
    <input type="text" id="searchBox" placeholder="Búsqueda de clientes..." />
    <div>
        <input type="checkbox" id="filtroNombre" name="filtroNombre" checked>
        <label for="filtroNombre">Nombre</label><br>
        <input type="checkbox" id="filtroTel" name="filtroTel" checked>
        <label for="filtroTel">Teléfono</label><br>
        <input type="checkbox" id="filtroEmail" name="filtroEmail" checked>
        <label for="filtroEmail">Correo</label><br><br>
    </div>
    <table class="table" id="tClientes">
        <tr>
            <th>
                Nombre
            </th>
            <th>
                Telefono
            </th>
            <th>
                Correo
            </th>
            <th></th>
        </tr>

        @For Each item In Model
            @<tr class="client-row">
                <td class="client-name">
                    @Html.DisplayFor(Function(modelItem) item.Cliente)
                </td>
                <td class="client-tel">
                    @Html.DisplayFor(Function(modelItem) item.Telefono)
                </td>
                <td class="client-em">
                    @Html.DisplayFor(Function(modelItem) item.Correo)
                </td>
                <td>
                    @Html.ActionLink("Editar", "Editar", New With {.id = item.Id}) |
                    @Html.ActionLink("Detalles", "Detalles", New With {.id = item.Id}) |
                    @Html.ActionLink("Borrar", "Borrar", New With {.id = item.Id})
                </td>
            </tr>
        Next
    </table>

    <script>
        $(document).ready(function () {
            function filterClients() {
                let busqueda = $("#searchBox").val().toLowerCase();

                $(".client-row").each(function () {
                    let row = $(this);
                    let mostrar = false;

                    if ($("#filtroNombre").prop("checked") && row.find(".client-name").text().toLowerCase().includes(busqueda)) {
                        mostrar = true;
                    }
                    if ($("#filtroTel").prop("checked") && row.find(".client-tel").text().toLowerCase().includes(busqueda)) {
                        mostrar = true;
                    }
                    if ($("#filtroEmail").prop("checked") && row.find(".client-em").text().toLowerCase().includes(busqueda)) {
                        mostrar = true;
                    }

                    row.toggle(mostrar);
                });
            }

            $("#searchBox").on("input", function () {
                filterClients();
            });

            $("input[type='checkbox']").on("change", function () {
                filterClients();
            });
        });

    </script>
</body>
</html>
