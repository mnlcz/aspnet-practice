using Portafolio.Models;

namespace Portafolio.Services;

public class RepositorioProyectos : IRepositorioProyectos
{
    public List<ProyectoViewModel> ObtenerProyectos() => new()
    {
        new()
        {
            Titulo = "Spammer para el bot de Discord \"Mudae\"",
            Descripcion = "Programa realizado en C++ que utiliza la API Win32 para spamear el comando requerido por el bot Mudae.",
            Link = "https://github.com/mnlcz/Mudae-Rolls-Spam",
            ImagenURL = "/img/Proyectos/mudae.png"
        },
        new()
        {
            Titulo = "Generador de proyectos CMake y Make para C++ usando PowerShell",
            Descripcion = "Un script que se encarga de generar los directorios y los scripts Makefile o CMakeLists según se necesite. Tiene también la capacidad de generar scripts CMake listos para la utilización de las bibliotecas Boost.",
            Link = "https://github.com/mnlcz/CPP-Project-Generator",
            ImagenURL = "/img/Proyectos/generador.png"
        },
        new()
        {
            Titulo = "Sistema de estacionamientos utilizando la API Directions de Google Maps (Outdated)",
            Descripcion = "Proyecto para la universidad en C++ y posteriormente Java el cual dada una dirección de origen y otra de llegada, indica la ruta a tomar para llegar al estacionamiento disponible (ficticio) más cercano al objetivo.",
            Link = "https://github.com/mnlcz/TP-POO",
            ImagenURL = "/img/Proyectos/tp.png"
        },
        new()
        {
            Titulo = "Web scraper básico en Ruby",
            Descripcion = "Pequeño script encargado de obtener la tabla de posiciones de la liga argentina.",
            Link = "https://github.com/mnlcz/Web-scraping",
            ImagenURL = "/img/Proyectos/scraper.png"
        },
        new()
        {
            Titulo = "Soluciones para problemas de HackerRank",
            Descripcion = "Mis soluciones a diversos problemas y challenges de la famosa página HackerRank.",
            Link = "https://github.com/mnlcz/HackerRank",
            ImagenURL = "/img/Proyectos/hr.png"
        },
        new()
        {
            Titulo = "Bibloteca básica de Grafos en Kotlin",
            Descripcion = "Implementación de la estructura de datos Grafo y sus métodos BFS y DFS.",
            Link = "https://github.com/mnlcz/GraphKT",
            ImagenURL = "/img/Proyectos/grafos.png"
        },
        new()
        {
            Titulo = "Bot para Discord en Ruby",
            Descripcion = "Bot simple para un servidor con amigos, encargado de gestionar una lista de peliculas vistas por el grupo, además de tener diversas respuestas según qué persona le hable.",
            Link = "El código del mismo no es open source debido a que contiene información personal de mi grupo de amigos.",
            ImagenURL = "/img/Proyectos/bot-discord.png"
        }
    };
}
