@ModelType List(Of Producto)
@Code
    ViewData("Title") = "Productos"
End Code

<!DOCTYPE html>
<html>
<head>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
</head>

<body>
    <h2>Listado de Productos</h2>

    <p>
        @Html.ActionLink("Crear", "Crear")
    </p>
    <input type="text" id="searchBox" placeholder="Búsqueda de productos..." />
    <div>
        <input type="checkbox" id="filtroNombre" name="filtroNombre" checked>
        <label for="filtroNombre">Nombre</label><br>
        <input type="checkbox" id="filtroPrecio" name="filtroPrecio" checked>
        <label for="filtroPrecio">Precio</label><br>
        <input type="checkbox" id="filtroCategoria" name="filtroCategoria" checked>
        <label for="filtroCategoria">Categoría</label><br><br>
    </div>
    <table class="table" id="tProductos">
        <tr>
            <th>
                Nombre
            </th>
            <th>
                Precio
            </th>
            <th>
                Categoría
            </th>
            <th></th>
        </tr>

        @For Each item In Model
            @<tr class="product-row">
                <td class="product-name">
                    @Html.DisplayFor(Function(modelItem) item.Nombre)
                </td>
                <td class="product-price">
                    @Html.DisplayFor(Function(modelItem) item.Precio)
                </td>
                <td class="product-category">
                    @Html.DisplayFor(Function(modelItem) item.Categoria)
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
            function filterProducts() {
                let busqueda = $("#searchBox").val().toLowerCase();

                $(".product-row").each(function () {
                    let row = $(this);
                    let mostrar = false;

                    if ($("#filtroNombre").prop("checked") && row.find(".product-name").text().toLowerCase().includes(busqueda)) {
                        mostrar = true;
                    }
                    if ($("#filtroPrecio").prop("checked") && row.find(".product-price").text().toLowerCase().includes(busqueda)) {
                        mostrar = true;
                    }
                    if ($("#filtroCategoria").prop("checked") && row.find(".product-category").text().toLowerCase().includes(busqueda)) {
                        mostrar = true;
                    }

                    row.toggle(mostrar);
                });
            }

            $("#searchBox").on("input", function () {
                filterProducts();
            });

            $("input[type='checkbox']").on("change", function () {
                filterProducts();
            });
        });

    </script>
</body>
</html>
