@Code
    ViewData("Title") = "Inicio"
End Code

<main>
    <section class="row" aria-labelledby="aspnetTitle">
        <h1 id="title">Examen de Visual Basic .NET</h1>
        <p class="lead">Examen en el que se utiliza Visual Basic 4.7* y SQL Server 2008.</p>
        <h3>Paquetes externos utilizados</h3>
        <ul>
            <li>
                <h5>
                    <a href="https://www.nuget.org/packages/Microsoft.Data.SqlClient">Microsoft.Data.SqlClient</a>:
                </h5>
                <p>Dado que el paquete especificado en la consigna (Systen.Data.SqlClient.SqlConnection) se encuentra deprecado.</p>
            </li>
            <li>
                <h5>
                    <a href="https://www.nuget.org/packages/Dapper/">Dapper</a>:
                </h5>
                <p>Para facilitar la interacción con la base de datos.</p>
            </li>
            <li>
                <h5>
                    <a href="https://jquery.com/">jQuery</a>:
                </h5>
                <p>Para el filtrado en tiempo real en el front-end.</p>
            </li>
        </ul>
        <h3>Consignas</h3>
        <ul>
            <li>
                <h5>
                    <input type="checkbox" checked id="consigna1" />
                    <label for="consigna1">Alta, Baja y Modificación de Clientes y Productos.</label><br />
                </h5>
            </li>
            <li>
                <h5>
                    <input type="checkbox" checked id="consigna2" />
                    <label for="consigna2">Buscadores de Clientes y Productos con filtros.</label><br />
                </h5>
                <p>El filtrado lo realicé en el front-end, de todas formas dejé una implementación (no testeada) de filtrado desde el backend en los respectivos servicios de Clientes y Productos. </p>
            </li>
            <li>
                <h5>
                    <input type="checkbox" id="consigna3" />
                    <label for="consigna3">Alta, Baja, Modificación de Ventas y Cálculo del Total</label><br />
                </h5>
                <p>
                    Alta y Cálculo del Total implementados. La baja y modificación de ventas no funcionan correctamente.
                </p>
            </li>
            <li>
                <h5>
                    <input type="checkbox" id="consigna4" checked />
                    <label for="consigna4">Buscador de Ventas con filtros.</label><br />
                </h5>
            </li>
            <li>
                <h5>
                    <input type="checkbox" id="consigna5" checked />
                    <label for="consigna5">Generación de reportes.</label><br />
                </h5>
                <p>
                    El reporte del total está visible en la vista de ventas al entrar sin aplicar filtros. El reporte mensual se encuentra en la sección de ventas, en el apartado "Reporte Mensual".
                </p>
            </li>
        </ul>
    </section>
</main>
