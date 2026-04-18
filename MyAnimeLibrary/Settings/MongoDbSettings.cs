namespace MyAnimeLibrary.Settings
{
    public class MongoDbSettings
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string ConnectingString
        {
            get
            {
                return $"mongodb://{Host}:{Port}";
            }
        }
    }
}