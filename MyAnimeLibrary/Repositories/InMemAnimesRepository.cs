using Microsoft.VisualBasic;
using MyAnimeLibrary.Entities;
using System.Collections.Generic;
using System.Linq;


namespace MyAnimeLibrary.Repositories
{
    public class InMemAnimesRepository : IAnimesRepository
    {
        private readonly List<Anime> animes = new()
        {

            new Anime{ Id = Guid.NewGuid(), Name = "One Piece",
            AnimeImage = new Uri("https://Pesho.jpg") ,
            AnimeLink = new Uri("https://Gosho.com"),
            StartingDate = DateTime.UtcNow,
            CreatedDate = DateTime.UtcNow,
            NumberOfEpisodes = 12 },

            new Anime{ Id = Guid.NewGuid(), Name = "Naruto",
            AnimeImage = new Uri("https://Pesho.jpg") ,
            AnimeLink = new Uri("https://Gosho.com"),
            StartingDate = DateTime.UtcNow,
            CreatedDate = DateTime.UtcNow,
            NumberOfEpisodes = 12 },

            new Anime{ Id = Guid.NewGuid(), Name = "Bleach",
            AnimeImage = new Uri("https://Pesho.jpg") ,
            AnimeLink = new Uri("https://Gosho.com"),
            StartingDate = DateTime.UtcNow,
            CreatedDate = DateTime.UtcNow,
            NumberOfEpisodes = 12 },
        };

        public IEnumerable<Anime> GetAnimes()
        {
            return animes;
        }

        public Anime GetAnime(Guid id)
        {
            return animes.Where(anime => anime.Id == id).SingleOrDefault();
        }

        public void CreateAnime(Anime anime)
        {
            animes.Add(anime);
        }

        public void UpdateAnime(Anime anime)
        {
            var index = animes.FindIndex(existingAnime => existingAnime.Id == anime.Id);
            animes[index] = anime;
        }

        public void DeleteAnime(Guid id)
        {
            var index = animes.FindIndex(existingAnime => existingAnime.Id == id);
            animes.RemoveAt(index);
        }
    }
}