using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballAdministration.Shared;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;


namespace FootballAdministration.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        string ConnectionString = "mongodb+srv://RasmusKlatt:Test1234@testcluster.5ducm.mongodb.net/test?authSource=admin&replicaSet=atlas-ljj87j-shard-0&readPreference=primary&appname=MongoDB%20Compass&ssl=true";
        string DatabaseName = "ClubDB";
        string CollectionName = "Players";

        [HttpGet]
        public async Task<IEnumerable<PlayerModel>> GetAsync()
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            var collection = db.GetCollection<PlayerModel>(CollectionName);
            var results = await collection.FindAsync(_ => true);

            List<PlayerModel> players = new List<PlayerModel>();
            foreach (var player in results.ToList())
            {
                players.Add(player);
            }
            return players;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync()
        {
            //
            //Deletes EVERY player from the collection
            //
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            var collection = db.GetCollection<PlayerModel>(CollectionName);
            var results = await collection.FindAsync(_ => true);

            foreach(var item in results.ToList())
            {
                var filter = Builders<PlayerModel>.Filter.Eq("Id", item.Id);
                await collection.DeleteOneAsync(filter);
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<Task> AddPlayer(PlayerModel player)
        {
            //Adds a player to the Database   
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            var collection = db.GetCollection<PlayerModel>(CollectionName);

            return collection.InsertOneAsync(player);
        }

        [HttpPut]
        public async Task<Task> EditPlayer(PlayerModel player)
        {
            //Edits a player to the database
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            var collection = db.GetCollection<PlayerModel>(CollectionName);

            var filter = Builders<PlayerModel>.Filter.Eq("Id", player.Id);
            return collection.ReplaceOneAsync(filter, player);

        }
    }
}
