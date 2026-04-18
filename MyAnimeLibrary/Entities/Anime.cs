using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace MyAnimeLibrary.Entities
{
    public record Anime
    {
        public Guid Id { get; init; }
        public required string Name { get; set; }
        public Uri? AnimeLink { get; set; }
        public Uri? AnimeImage { get; set; }
        public required int NumberOfEpisodes { get; set; }
        public required DateTime StartingDate { get; set; }
        public DateTime EndDate
        {
            get => SetEndDate();
            set => SetEndDate();
        }
        public DateTime CreatedDate { get; init; }

        private DateTime SetEndDate()
        {
            return StartingDate.AddDays(NumberOfEpisodes * 7);
        }
    }

}