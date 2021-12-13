using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace FootballAdministration.Shared
{
    public class TeamModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }

        public TeamModel(string name)
        {
            this.Name = name;
        }
        public TeamModel()
        {

        }
    }
}
