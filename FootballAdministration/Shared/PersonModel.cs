using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace FootballAdministration.Shared
{
    public class PersonModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string TeamName { get; set; }
        [Required]
        public double MonthlyWage { get; set; }

        public PersonModel(string firstName, string lastName, DateTime DOB, double monthlyWage)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = DOB;
            this.MonthlyWage = monthlyWage;
        }
        public PersonModel()
        {

        }

        public string GetFullName()
        {
            return this.FirstName + " " + this.LastName;
        }

        public string GetBirthDate()
        {
            return this.DateOfBirth.ToString("dd/MM/yyyy");
        }
    }
}
