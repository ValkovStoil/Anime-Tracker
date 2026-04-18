using Microsoft.AspNetCore.Mvc;
using MyAnimeLibrary.Dtos;
using MyAnimeLibrary.Entities;
using MyAnimeLibrary.Repositories;

namespace MyAnimeLibrary.Controllers
{
    [ApiController]
    [Route("animes")]
    public class AnimesController : ControllerBase
    {
        private readonly IAnimesRepository _repository;

        public AnimesController(IAnimesRepository repository)
        {
            this._repository = repository;
        }

        //GET /animes
        [HttpGet]
        public IEnumerable<AnimeDto> GetAnimes()
        {
            var animes = _repository.GetAnimes().Select(anime => anime.AsDto());

            return animes;
        }

        // GET /animes/{id}
        [HttpGet("{id}")]
        public ActionResult<AnimeDto> GetAnime(Guid id)
        {
            var anime = _repository.GetAnime(id);

            if (anime is null)
            {
                return NotFound();
            }
            return anime.AsDto();
        }

        //POST /animes
        [HttpPost]
        public ActionResult<AnimeDto> CreateAnime(CreateAnimeDto animeDtio)
        {
            Anime anime = new()
            {
                Id = Guid.NewGuid(),
                Name = animeDtio.Name,
                AnimeImage = animeDtio.AnimeImage,
                AnimeLink = animeDtio.AnimeLink,
                StartingDate = animeDtio.StartingDate,
                NumberOfEpisodes = animeDtio.NumberOfEpisodes,
                CreatedDate = DateTime.UtcNow
            };

            _repository.CreateAnime(anime);
            return CreatedAtAction(nameof(GetAnime), new { id = anime.Id }, anime.AsDto());
        }

        // PUT /animes/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateAnime(Guid id, UpdateeAnimeDto animeDto)
        {
            var existingAnime = _repository.GetAnime(id);
            if (existingAnime == null)
            {
                return NotFound();
            }

            var updatedAnime = existingAnime with
            {
                Name = animeDto.Name,
                AnimeImage = animeDto.AnimeImage,
                AnimeLink = animeDto.AnimeLink,
                NumberOfEpisodes = animeDto.NumberOfEpisodes,
                StartingDate = animeDto.StartingDate
            };

            _repository.UpdateAnime(updatedAnime);

            return NoContent();
        }

        // DELETE /items/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteAnime(Guid id)
        {
            var existingAnime = _repository.GetAnime(id);
            if (existingAnime == null)
            {
                return NotFound();
            }

            _repository.DeleteAnime(id);

            return NoContent();
        }

    }
}