@ModelType IEnumerable(Of Examen.ReporteVentaViewModel)
@Code
    ViewData("Title") = "Ventas"
End Code

<!DOCTYPE html>
<html>
<head>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
</head>
<body>
    <h2>Listado de Ventas</h2>

    <p>
        @Html.ActionLink("Crear", "Crear")
        <br />
        @Html.ActionLink("Reporte Mensual", "Mensual")
    </p>
    <input type="text" id="searchBox" placeholder="Búsqueda de ventas..." />
    <div style="display: grid; grid-template-columns: repeat(auto-fit, minmax(400px, 1fr)); gap: 10px; margin: 20px 0;">
        <div>
            <input type="checkbox" id="filtroIdCliente" name="filtroIdCliente" checked>
            <label for="filtroIdCliente">Id Cliente</label>
        </div>
        <div>
            <input type="checkbox" id="filtroFecha" name="filtroFecha" checked>
            <label for="filtroFecha">Fecha</label>
        </div>
        <div>
            <input type="checkbox" id="filtroTotal" name="filtroTotal" checked>
            <label for="filtroTotal">Total Venta</label>
        </div>
        <div>
            <input type="checkbox" id="filtroNombre" name="filtroNombre" checked>
            <label for="filtroNombre">Nombre producto</label>
        </div>
        <div>
            <input type="checkbox" id="filtroPrecio" name="filtroPrecio" checked>
            <label for="filtroPrecio">Precio producto</label>
        </div>
        <div>
            <input type="checkbox" id="filtroCategoria" name="filtroCategoria" checked>
            <label for="filtroCategoria">Categoría producto</label>
        </div>
        <div>
            <input type="checkbox" id="filtroCantidad" name="filtroCantidad" checked>
            <label for="filtroCantidad">Cantidad producto</label>
        </div>
        <div>
            <input type="checkbox" id="filtroPrecioUnitario" name="filtroPrecioUnitario" checked>
            <label for="filtroPrecioUnitario">Precio unitario producto</label>
        </div>
        <div>
            <input type="checkbox" id="filtroPrecioTotal" name="filtroPrecioTotal" checked>
            <label for="filtroPrecioTotal">Precio total producto</label>
        </div>
    </div>
    <table class="table" id="tVentas">
        <thead>
            <tr>
                <th>
                    ID Cliente
                </th>
                <th>
                    Fecha
                </th>
                <th>
                    Total Venta
                </th>
                <th>
                    Producto
                </th>
                <th>
                    Precio Producto
                </th>
                <th>
                    Categoría
                </th>
                <th>
                    Cantidad
                </th>
                <th>
                    Precio Unitario
                </th>
                <th>
                    Precio Total
                </th>
                <th></th>
            </tr>
        </thead>

        <tbody>
            @For Each item In Model
                @<tr class="venta-row">
                    <td class="venta-idclient">
                        @Html.DisplayFor(Function(modelItem) item.IdCliente)
                    </td>
                    <td class="venta-fecha">
                        @Html.DisplayFor(Function(modelItem) item.Fecha)
                    </td>
                    <td class="venta-totalventa">
                        @Html.DisplayFor(Function(modelItem) item.Total)
                    </td>
                    <td class="venta-nombreprod">
                        @Html.DisplayFor(Function(modelItem) item.Nombre)
                    </td>
                    <td class="venta-precioprod">
                        @Html.DisplayFor(Function(modelItem) item.Precio)
                    </td>
                    <td class="venta-categoria">
                        @Html.DisplayFor(Function(modelItem) item.Categoria)
                    </td>
                    <td class="venta-cantidad">
                        @Html.DisplayFor(Function(modelItem) item.Cantidad)
                    </td>
                    <td class="venta-preciounit">
                        @Html.DisplayFor(Function(modelItem) item.PrecioUnitario)
                    </td>
                    <td class="venta-preciototal">
                        @Html.DisplayFor(Function(modelItem) item.PrecioTotal)
                    </td>
                    <td>
                        @Html.ActionLink("Editar", "Editar", New With {.id = item.Id}) |
                        @Html.ActionLink("Detalles", "Detalles", New With {.id = item.Id}) |
                        @Html.ActionLink("Borrar", "Borrar", New With {.id = item.Id})
                    </td>
                </tr>
            Next
        </tbody>

        <tfoot>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td colspan="1" class="text-right">
                    <strong>Total de Ventas:</strong>
                </td>
                <td id="finalTotal"></td>
            </tr>
        </tfoot>
    </table>

    <script>
        // FIXME
        $(document).ready(function () {
            function filterVentas() {
                let busqueda = $("#searchBox").val().toLowerCase();

                $(".venta-row").each(function () {
                    let row = $(this);
                    let mostrar = false;

                    if ($("#filtroIdCliente").prop("checked") && row.find(".venta-idclient").text().toLowerCase().includes(busqueda)) {
                        mostrar = true;
                    }
                    if ($("#filtroFecha").prop("checked") && row.find(".venta-fecha").text().toLowerCase().includes(busqueda)) {
                        mostrar = true;
                    }
                    if ($("#filtroTotal").prop("checked") && row.find(".venta-totalventa").text().toLowerCase().includes(busqueda)) {
                        mostrar = true;
                    }
                    if ($("#filtroNombre").prop("checked") && row.find(".venta-nombreprod").text().toLowerCase().includes(busqueda)) {
                        mostrar = true;
                    }
                    if ($("#filtroPrecio").prop("checked") && row.find(".venta-precioprod").text().toLowerCase().includes(busqueda)) {
                        mostrar = true;
                    }
                    if ($("#filtroCategoria").prop("checked") && row.find(".venta-categoria").text().toLowerCase().includes(busqueda)) {
                        mostrar = true;
                    }
                    if ($("#filtroCantidad").prop("checked") && row.find(".venta-cantidad").text().toLowerCase().includes(busqueda)) {
                        mostrar = true;
                    }
                    if ($("#filtroPrecioUnitario").prop("checked") && row.find(".venta-preciounit").text().toLowerCase().includes(busqueda)) {
                        mostrar = true;
                    }
                    if ($("#filtroPrecioTotal").prop("checked") && row.find(".venta-preciototal").text().toLowerCase().includes(busqueda)) {
                        mostrar = true;
                    }

                    row.toggle(mostrar);
                });
            }

            $("#searchBox").on("input", function () {
                filterVentas();
            });

            $("input[type='checkbox']").on("change", function () {
                filterVentas();
            });

            // Calcular total de ventas
            let total = 0;
            $(".venta-preciototal").each(function () {
                let valor = parseFloat($(this).text()) || 0;
                total += valor;
            });
            $("#finalTotal").text(total.toFixed(2));
        });

    </script>
</body>
</html>

