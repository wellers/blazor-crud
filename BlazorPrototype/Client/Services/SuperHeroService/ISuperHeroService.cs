using BlazorPrototype.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorPrototype.Client.Services.SuperHeroService
{
	public interface ISuperHeroService
	{
		List<SuperHero> Heroes { get; set; }
		List<Comic> Comics { get; set; }

		Task GetSuperHeroes();
		Task<SuperHero> GetSingleHero(int id);
		Task GetComics();
		Task AddSuperHero(SuperHero hero);
		Task UpdateSuperHero(SuperHero hero);
		Task DeleteSuperHero(int id);
	}
}
