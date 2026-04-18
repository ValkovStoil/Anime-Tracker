
using MyAnimeLibrary.Entities;
namespace MyAnimeLibrary.Repositories
{

    public interface IAnimesRepository
    {
        IEnumerable<Anime> GetAnimes();
        Anime GetAnime(Guid id);
        void CreateAnime(Anime anime);
        void UpdateAnime(Anime anime);
        void DeleteAnime(Guid id);
    }

}