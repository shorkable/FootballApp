using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballAdministration.Shared;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FootballAdministration.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<TeamModel>> GetAsync()
        {
            string ConnectionString = "mongodb+srv://RasmusKlatt:Test1234@testcluster.5ducm.mongodb.net/test?authSource=admin&replicaSet=atlas-ljj87j-shard-0&readPreference=primary&appname=MongoDB%20Compass&ssl=true";
            string DatabaseName = "ClubDB";
            string CollectionName = "Teams";
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            var collection = db.GetCollection<TeamModel>(CollectionName);
            var results = await collection.FindAsync(_ => true);

            List<TeamModel> teams = new List<TeamModel>();
            foreach(var team in results.ToList())
            {
                teams.Add(team);
            }
            return teams;
        }
    }
}
