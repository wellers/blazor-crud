using BlazorPrototype.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
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
		
	}
}
