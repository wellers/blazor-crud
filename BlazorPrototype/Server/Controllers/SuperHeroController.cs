using BlazorPrototype.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPrototype.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SuperHeroController : ControllerBase
	{
		private static readonly List<Comic> Comics =
		[
			new Comic { Id = 1, Name = "Marvel" },
			new Comic { Id = 2, Name = "DC" }
		];

		private static readonly List<SuperHero> Heroes =
		[
			new SuperHero
			{
				Id = 1,
				FirstName = "Peter",
				LastName = "Parker",
				HeroName = "Spiderman",
				Comic = Comics[0],
				SelectedComicId = "1"
			},
			new SuperHero
			{
				Id = 2,
				FirstName = "Bruce",
				LastName = "Wayne",
				HeroName = "Batman",
				Comic = Comics[1],
				SelectedComicId = "2"
			}
		];

		[HttpGet]
		public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
		{
			return Ok(Heroes);
		}

		[HttpGet("Comics")]
		public async Task<ActionResult<List<Comic>>> GetComics()
		{
			return Ok(Comics);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<List<SuperHero>>> GetSingleHeroes(int id)
		{
			var hero = Heroes.FirstOrDefault(h => h.Id == id);

			if (hero == null)
				return NotFound("Sorry, no hero here.");

			return Ok(hero);
		}

		[HttpPost("AddSuperHero")]
		public async Task<ActionResult> AddSuperHero(SuperHero hero)
		{
			hero.Id = Heroes.Select(h => h.Id).Max() + 1;
			hero.Comic = Comics.FirstOrDefault(c => c.Id == int.Parse(hero.SelectedComicId));

			Heroes.Add(hero);
			return Ok(Heroes);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateSuperHero(SuperHero hero)
		{
			var foundHero = Heroes.FirstOrDefault(h => h.Id == hero.Id);

			if (foundHero == null)
				return NotFound("Sorry, no hero here.");

			Heroes.Remove(foundHero);
			Heroes.Add(hero);

			return Ok(Heroes);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteSuperHero(int id)
		{
			var hero = Heroes.FirstOrDefault(h => h.Id == id);

			if (hero == null)
				return NotFound("Sorry, no hero here.");

			Heroes.Remove(hero);
			return Ok(Heroes);
		}
	}
}
