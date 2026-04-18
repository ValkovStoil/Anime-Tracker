using System.ComponentModel.DataAnnotations;

namespace MyAnimeLibrary.Dtos
{
    public record UpdateeAnimeDto
    {
        [Required]
        public required string Name { get; set; }
        public Uri? AnimeLink { get; set; }
        public Uri? AnimeImage { get; set; }
        [Required]
        [Range(0, 5000)]
        public required int NumberOfEpisodes { get; set; }
        [Required]
        public required DateTime StartingDate { get; set; }
    }
}