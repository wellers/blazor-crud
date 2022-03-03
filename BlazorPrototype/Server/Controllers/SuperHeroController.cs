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
				SelectedComicId = "1"
			},
			new SuperHero
			{
				Id = 2,
				FirstName = "Bruce",
				LastName = "Wayne",
				HeroName = "Batman",
				Comic = _comics[1],
				SelectedComicId = "2"
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

		[HttpPost("AddSuperHero")]
		public async Task<ActionResult> AddSuperHero(SuperHero hero)
		{
			hero.Id = _heroes.Select(h => h.Id).Max() + 1;
			hero.Comic = _comics.FirstOrDefault(c => c.Id == int.Parse(hero.SelectedComicId));

			_heroes.Add(hero);
			return Ok(_heroes);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateSuperHero(SuperHero hero){
			var foundHero = _heroes.FirstOrDefault(h => h.Id == hero.Id);
			
			if (foundHero == null)
				return NotFound("Sorry, no hero here.");
			
			_heroes.Remove(foundHero);
			_heroes.Add(hero);

			return Ok(_heroes);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteSuperHero(int id)
		{
			var hero = _heroes.FirstOrDefault(h => h.Id == id);

			if (hero == null)
				return NotFound("Sorry, no hero here.");

			_heroes.Remove(hero);
			return Ok(_heroes);
		}
	}
}
