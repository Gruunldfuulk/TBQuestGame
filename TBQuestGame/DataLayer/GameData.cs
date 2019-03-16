using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;
using System.Collections.ObjectModel;

namespace TBQuestGame.DataLayer
{
    /// <summary>
    /// static class to store the game data set
    /// </summary>
    public static class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                Id = 1,
                Name = "Ajax",
                Age = 34,
                JobTitle = Player.JobTitleName.Hacker,
                Race = Character.RaceType.Human,
                Health = 100,
                Credits = 500,
                MemoryPoints = 0,
                LocationId = 0
            };
        }

        public static List<string> InitialMessages()
        {
            return new List<string>()
            {
                "\tYou awaken slowly to the sound of neon lights humming outside your bedroom. However you are not in your bed, but on the floor, broken VR headset to your side. A splitting headache hits you before you can start to rise.",
                "\tTrying to remember what happened, you can only seem to know that this is your place and your name and age. You look around the small appartment, this is as good of place to start looking for clues."
            };

        }
        public static Location InitialGameMapLocation()
        {
            return new Location()
            {
                Id = 4,
                Name = "Norlon Corporate Headquarters",
                Description = "The Norlon Corporation Headquarters is located in just outside of Detroit " +
                         "Michigan.Norlon, founded in 1985 as a bio-tech company, is now a 36 billion dollar company with " +
                         "huge holdings in defense and space research and development.",
                Accessible = true,
                ModifyMemoryPoints = 10
            };
        }


        public static Map GameMap()
        {

            Map gameMap = new Map();

            gameMap.Locations = new ObservableCollection<Location>()
            {
                new Location()
                       {
                         Id = 4,
                         Name = "Norlon Corporate Headquarters",
                         Description = "The Norlon Corporation Headquarters is located in just outside of Detroit " +
                         "Michigan.Norlon, founded in 1985 as a bio-tech company, is now a 36 billion dollar company with " +
                         "huge holdings in defense and space research and development.",
                          Accessible = true,
                          ModifyMemoryPoints = 10
                       },
                new Location()
                       {
                        Id = 1,
                        Name = "Aion Base Lab",
                        Description = "The Norlon Corporation research facility located in the city of Heraklion on " +
                        "the north coast of Crete and the top secret research lab for the Aion Project.\nThe lab is a large, " + "" +
                        "well lit room, and staffed by a small number of scientists, all wearing light blue uniforms with the hydra-like Norlan Corporation logo.",
                        Accessible = true,
                        ModifyMemoryPoints = 10
                     }
            };

            return gameMap;
        }
    }
}

