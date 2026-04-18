namespace MyAnimeLibrary.Dtos
{
    public record AnimeDto
    {
        public Guid Id { get; init; }
        public required string Name { get; set; }
        public Uri? AnimeLink { get; set; }
        public Uri? AnimeImage { get; set; }
        public required int NumberOfEpisodes { get; set; }
        public required DateTime StartingDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; init; }
    }
}