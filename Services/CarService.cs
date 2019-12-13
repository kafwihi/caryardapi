using CarYardApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace CarYardApi.Services
{
    public class CarService
    {
        private readonly IMongoCollection<Car> _books;

        public CarService(ICaryardDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<Car>(settings.CaryardCollectionName);
        }

        public List<Car> Get() =>
            _books.Find(book => true).ToList();

        public Car Get(string id) =>
            _books.Find<Car>(book => book.Id == id).FirstOrDefault();

        public Car Create(Car book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void Update(string id, Car bookIn) =>
            _books.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(Car bookIn) =>
            _books.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) =>
            _books.DeleteOne(book => book.Id == id);
    }
}