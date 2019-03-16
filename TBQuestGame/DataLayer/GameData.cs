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
                Id = 1,
                Name = "Ajex's Appartment",
                Description = "Your messy appartment with an old foldout sofa bed in the back. " +
                         "A computer on your desk now as fried as your headset. Bits of neon lights bleed through your worn shades." +
                         " On the side table you find your credit stick and speeder bike keys. Under your keys is a bar tab from last night" +
                         ", marked 'Bad Luck Bar' and your drink The Alchemist.",
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
                         Id = 1,
                         Name = "Ajex's Appartment",
                         Description = "Your messy appartment with an old foldout sofa bed in the back. " +
                         "A computer on your desk now as fried as your headset. Bits of neon lights bleed through your worn shades." +
                         " On the side table you find your credit stick and speeder bike keys. Under your keys is a bar tab from last night"+
                         ", marked 'Bad Luck Bar' and your drink The Alchemist.",
                          Accessible = true,
                          ModifyMemoryPoints = 10
                       },
                new Location()
                       {
                        Id = 2,
                        Name = "Bad Luck Bar",
                        Description = "The glowing red eye sign in the back seems familiar and draws you into the building." +
                        " Inside hang four hexagon lights with a soft white light hitting the crowd in here tonight." +
                        " A bartender with a small black mustache and his hair shaved on side looks up at you, giving a nod of recognition.",
                        Accessible = true,
                        ModifyMemoryPoints = 10
                     },
                new Location()
                       {
                         Id = 3,
                         Name = "I.C.S Warehouse",
                         Description = "The main doors are broken as you come up to the building. " +
                         "A set of stairs leads up to the second floor door that is open. Inside you find a number of broken boxes," +
                         " with the words Integrated Computer Systems on the side of some of them. A smell hits your nose as you turn to"+
                         " find the source. Two bodies are hidden off to back corner of the building, both male and dressed as streetpunks.",
                          Accessible = true,
                          ModifyMemoryPoints = 10
                       },
                new Location()
                       {
                        Id = 4,
                        Name = "Detroit Opera House",
                        Description = "The old Opera House is a shadow of what it use to be. The once bright gold and red" +
                        " colors now washed out over the years. The wind whistles through some of the holes in the building, as" +
                        " bits of water drips from the once grand arched ceiling.",
                        Accessible = true,
                        ModifyMemoryPoints = 10
                     }

            };

            return gameMap;
        }
    }
}

