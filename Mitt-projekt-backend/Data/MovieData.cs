using Mitt_projekt_backend.Models;

namespace Mitt_projekt_backend.Data
{
	public static class MovieData
	{
		public static List<Movie> Movies { get; } = new()
		{
			new Movie { Id = 1, Title = "The Shawshank Redemption", Genre = "Drama", Year = 1994, Rating = 9.3,
				Description = "Två fångar bygger en stark vänskap under många år i fängelse.", ImageUrl = "" },
			new Movie { Id = 2, Title = "The Godfather", Genre = "Kriminal", Year = 1972, Rating = 9.2,
				Description = "En maffiafamiljs överhuvud lämnar över makten till sin son.", ImageUrl = "" },
			new Movie { Id = 3, Title = "The Dark Knight", Genre = "Action", Year = 2008, Rating = 9.0,
				Description = "Batman ställs mot Jokern som sprider kaos i Gotham City.", ImageUrl = "" },
			new Movie { Id = 4, Title = "Inception", Genre = "Sci-Fi", Year = 2010, Rating = 8.8,
				Description = "En tjuv stjäl hemligheter genom att gå in i människors drömmar.", ImageUrl = "" },
			new Movie { Id = 5, Title = "Pulp Fiction", Genre = "Kriminal", Year = 1994, Rating = 8.9,
			    Description = "En flicka hamnar i en magisk värld full av andar.", ImageUrl = "" },
			new Movie { Id = 6, Title = "Forrest Gump", Genre = "Drama", Year = 1994, Rating = 8.8,
				Description = "En godhjärtad man är med om flera stora händelser i USA:s historia.", ImageUrl = "" },
			new Movie { Id = 7, Title = "The Matrix", Genre = "Sci-Fi", Year = 1999, Rating = 8.7,
				Description = "En hacker upptäcker att världen han lever i är en simulering.", ImageUrl = "" },
			new Movie { Id = 8, Title = "Interstellar", Genre = "Sci-Fi", Year = 2014, Rating = 8.7,
				Description = "Astronauter reser genom ett maskhål för att rädda mänskligheten.", ImageUrl = "" },
			new Movie { Id = 9, Title = "Gladiator", Genre = "Action", Year = 2000, Rating = 8.5,
				Description = "En romersk general blir slav och kämpar som gladiator för hämnd.", ImageUrl = "" },
			new Movie { Id = 10, Title = "Spirited Away", Genre = "Animerad", Year = 2001, Rating = 8.6,
	}           Description = "En flicka hamnar i en magisk värld full av andar.", ImageUrl = "" },
}           new Movie { Id = 11, Title = "The Lion King", Genre = "Animerad", Year = 1994, Rating = 8.5,
                Description = "Ett ungt lejon måste ta sin plats som kung.", ImageUrl = "" },
            new Movie { Id = 12, Title = "Parasite", Genre = "Thriller", Year = 2019, Rating = 8.5,
                Description = "En fattig familj tar sig in i en rik familjs liv.", ImageUrl = "" },
            new Movie { Id = 13, Title = "Joker", Genre = "Thriller", Year = 2019, Rating = 8.4,
                Description = "En ensam komiker glider sakta in i galenskap.", ImageUrl = "" },
            new Movie { Id = 14, Title = "Toy Story", Genre = "Animerad", Year = 1995, Rating = 8.3,
                Description = "Leksaker som lever när ingen ser får en ny rival.", ImageUrl = "" },
            new Movie { Id = 15, Title = "Titanic", Genre = "Romantik", Year = 1997, Rating = 7.9,
                Description = "En kärlekshistoria ombord på fartyget Titanic.", ImageUrl = "" },
            new Movie { Id = 16, Title = "Jurassic Park", Genre = "Äventyr", Year = 1993, Rating = 8.2,
                Description = "En nöjespark med levande dinosaurier går helt fel.", ImageUrl = "" },
            new Movie { Id = 17, Title = "Avengers: Endgame", Genre = "Action", Year = 2019, Rating = 8.4,
                Description = "Hjältarna samlas en sista gång för att besegra Thanos.", ImageUrl = "" },
            new Movie { Id = 18, Title = "The Silence of the Lambs", Genre = "Thriller", Year = 1991, Rating = 8.6,
                Description = "En FBI-agent tar hjälp av en farlig fånge för att fånga en mördare.", ImageUrl = "" },
            new Movie { Id = 19, Title = "Get Out", Genre = "Skräck", Year = 2017, Rating = 7.8,
                Description = "Ett besök hos flickvännens familj blir allt mer obehagligt.", ImageUrl = "" },
            new Movie { Id = 20, Title = "The Conjuring", Genre = "Skräck", Year = 2013, Rating = 7.5,
                Description = "Två paranormala utredare hjälper en familj i ett hemsökt hus.", ImageUrl = "" }