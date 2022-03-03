using BlazorPrototype.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPrototype.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SuperHeroController : ControllerBase
	{
		public static List<Comic> _comics = new List<Comic>
		{
			new Comic { Id = 1, Name = "Marvel" },
			new Comic { Id = 2, Name = "DC" }
		};

		public static List<SuperHero> _heroes = new List<SuperHero>
		{
			new SuperHero
			{
				Id = 1,
				FirstName = "Peter",
				LastName = "Parker",
				HeroName = "Spiderman",
				Comic = _comics[0],
				ComicId = 1
			},
			new SuperHero
			{
				Id = 2,
				FirstName = "Bruce",
				LastName = "Wayne",
				HeroName = "Batman",
				Comic = _comics[1],
				ComicId = 2
			}
		};
		
		[HttpGet]
		public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
		{
			return Ok(_heroes);
		}

		[HttpGet("Comics")]
		public async Task<ActionResult<List<Comic>>> GetComics()
		{
			return Ok(_comics);
		}

		[HttpGet("{id}")]		
		public async Task<ActionResult<List<SuperHero>>> GetSingleHeroes(int id)
		{
			var hero = _heroes.FirstOrDefault(h => h.Id == id);

			if (hero == null)
				return NotFound("Sorry, no hero here.");

			return Ok(hero);
		}
	}
}
