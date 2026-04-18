using Amazon.Util.Internal.PlatformServices;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using MyAnimeLibrary.Repositories;
using MyAnimeLibrary.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
BsonSerializer.RegisterSerializer(new DateTimeSerializer(BsonType.String));
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "WatchAnime",
                      policy =>
                      {
                          policy.AllowAnyOrigin();
                          //policy.WithOrigins("https://127.0.0.1:5500");
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                          //policy.AllowCredentials();
                      });
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IMongoClient>(ServiceProvider =>
{
    var connectionString = "mongodb://localhost:27017";
    //var settings = MongoClientSettings.FromConnectionString(connectionString);

    var mongoClient = new MongoClient(connectionString);
    return mongoClient;
});
builder.Services.AddSingleton<IAnimesRepository, MongoDBAnimesRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("WatchAnime");
app.UseHttpsRedirection();

app.MapControllers();

app.Run();

