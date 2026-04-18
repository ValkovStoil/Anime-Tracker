using MyAnimeLibrary.Dtos;
using MyAnimeLibrary.Entities;

namespace MyAnimeLibrary
{
    public static class Extensions
    {
        public static AnimeDto AsDto(this Anime anime)
        {
            return new AnimeDto
            {
                Id = anime.Id,
                Name = anime.Name,
                CreatedDate = anime.CreatedDate,
                StartingDate = anime.StartingDate,
                EndDate = anime.EndDate,
                AnimeImage = anime.AnimeImage,
                AnimeLink = anime.AnimeLink,
                NumberOfEpisodes = anime.NumberOfEpisodes
            };
        }
    }
}