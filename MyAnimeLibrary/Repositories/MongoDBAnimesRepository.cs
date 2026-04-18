using MongoDB.Bson;
using MongoDB.Driver;
using MyAnimeLibrary.Entities;

namespace MyAnimeLibrary.Repositories
{
    public class MongoDBAnimesRepository : IAnimesRepository
    {
        private const string databaseName = "anime";
        private const string collectioName = "animes";
        private readonly IMongoCollection<Anime> animesCollection;
        private readonly FilterDefinitionBuilder<Anime> filterBuilder = Builders<Anime>.Filter;

        public MongoDBAnimesRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            animesCollection = database.GetCollection<Anime>(collectioName);
        }

        public void CreateAnime(Anime anime)
        {
            animesCollection.InsertOne(anime);
        }

        public void DeleteAnime(Guid id)
        {
            var filter = filterBuilder.Eq(anime => anime.Id, id);
            animesCollection.DeleteOne(filter);
        }

        public Anime GetAnime(Guid id)
        {
            var filter = filterBuilder.Eq(anime => anime.Id, id);
            return animesCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Anime> GetAnimes()
        {
            return animesCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdateAnime(Anime anime)
        {
            var filter = filterBuilder.Eq(existingAnime => existingAnime.Id, anime.Id);
            animesCollection.ReplaceOne(filter, anime);
        }
    }
}