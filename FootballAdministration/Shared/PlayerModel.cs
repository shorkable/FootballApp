
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FootballAdministration.Shared

{
    public class PlayerModel : PersonModel
    {
        [Required]
        public string PreferredFoot { get; set; }
        public int JerseyNumber { get; set; }
        public PlayerModel(string teamName, string firstName, string lastName, DateTime DOB, string preferredFoot, double monthlyWage, int jerseyNumber) : base(firstName, lastName, DOB, monthlyWage)
        {
            this.TeamName = teamName;
            this.PreferredFoot = preferredFoot;
            this.JerseyNumber = jerseyNumber;
            
        }
        public PlayerModel()
        {

        }

        public TeamModel GetTeam(List<TeamModel> teams)
        {
            //Method that gets the object of the team associated with the player based on the team name
            foreach(TeamModel team in teams)
            {
                try
                {
                    if (this.TeamName == team.Name)
                    {
                        return team;
                    }
                }
                catch
                {
                    throw new Exception();
                }
            }
            return null;
        }
    }
}
