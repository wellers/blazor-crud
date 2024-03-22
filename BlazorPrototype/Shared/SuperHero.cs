﻿namespace BlazorPrototype.Shared
{
    public class SuperHero
	{
		public int Id { get; set; }
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string HeroName { get; set; } = string.Empty;
		public Comic? Comic { get; set; }
		public string SelectedComicId { get; set; }
	}
}
