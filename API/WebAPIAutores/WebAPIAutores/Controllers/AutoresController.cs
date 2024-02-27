using Microsoft.AspNetCore.Mvc;
using WebAPIAutores.Models;

namespace WebAPIAutores.Controllers;

[Route("api/autores")]
public class AutoresController : Controller
{
	[HttpGet]
	public ActionResult<List<Autor>> Get()
	{
		return new List<Autor>()
		{
			new(1, "Manuel"),
			new(2, "Felipe")
		};
	}
}
