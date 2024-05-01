using BlazorPrototype.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorPrototype.Client.Services.SuperHeroService
{
	public class SuperHeroService : ISuperHeroService
	{
		private readonly HttpClient _http;
		private readonly NavigationManager _navigationManager;

		public SuperHeroService(HttpClient http, NavigationManager navigationManager)
		{
			_http = http;
			_navigationManager = navigationManager;
		}

		public List<SuperHero> Heroes { get; set; } = new List<SuperHero>();
		public List<Comic> Comics { get; set; } = new List<Comic>();

		public async Task GetComics()
		{
			var result = await _http.GetFromJsonAsync<List<Comic>>("api/superhero/comics");
			if (result != null)
				Comics = result;
		}

		public async Task AddSuperHero(SuperHero hero)
		{
			var result = await _http.PostAsJsonAsync("api/superhero/addsuperhero", hero);
			await SetHeroes(result);
		}
		
		private async Task SetHeroes(HttpResponseMessage result)
		{
			var response = await result.Content.ReadFromJsonAsync<List<SuperHero>>();
			Heroes = response;
			_navigationManager.NavigateTo("superheroes");
		}

		public async Task<SuperHero> GetSingleHero(int id)
		{
			var result = await _http.GetFromJsonAsync<SuperHero>($"api/superhero/{id}");
			if (result != null)
				return result;

			throw new Exception("Hero not found!");
		}

		public async Task GetSuperHeroes()
		{
			var result = await _http.GetFromJsonAsync<List<SuperHero>>("api/superhero");
			if (result != null)
				Heroes = result;
		}

		public async Task UpdateSuperHero(SuperHero hero)
		{
			var result = await _http.PutAsJsonAsync($"api/superhero/{hero.Id}", hero);
			await SetHeroes(result);
		}

		public async Task DeleteSuperHero(int id)
		{
			var result = await _http.DeleteAsync($"api/superhero/{id}");
			await SetHeroes(result);
		}
	}
}
