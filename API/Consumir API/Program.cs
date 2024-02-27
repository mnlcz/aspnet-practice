// Consumiendo la API Jikan usando el wrapper Jikan.NET
using JikanDotNet;

IJikan jikan = new Jikan();

var q1 = await jikan.SearchAnimeAsync("Naruto");
// foreach(var narutos in q1.Data)
// {
//     Console.WriteLine(narutos.Title);
// }
var naruto = 
(
    from n in q1.Data
    where n.Title == "Naruto"
    select n
).FirstOrDefault();
Console.WriteLine(naruto?.Synopsis);