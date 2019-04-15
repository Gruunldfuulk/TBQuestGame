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
                LocationId = 0,
                Inventory = new ObservableCollection<GameItem>()
                {
                    GameItemById(1001),
                    GameItemById(2001)
                }
            };
        }
        private static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
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
                ModifyMemoryPoints = 0
            };
        }


        public static Map GameMap()
        {

            Map gameMap = new Map();
            gameMap.StandardGameItems = StandardGameItems();

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
                          ModifyMemoryPoints = 1,
                                   GameItems = new ObservableCollection<GameItem>
                                       {
                                           GameItemById(4001)
                                       }
                       },
                new Location()
                       {
                        Id = 2,
                        Name = "Bad Luck Bar",
                        Description = "The glowing red eye sign in the back seems familiar and draws you into the building." +
                        " Inside hang four hexagon lights with a soft white light hitting the crowd in here tonight." +
                        " A bartender with a small black mustache and his hair shaved on side looks up at you, giving a nod of recognition." +
                        " Walking up to the bar he leans up to talk",
                        Accessible = false,
                        RequiredClueId = 4001,
                        ModifyMemoryPoints = 1,
                        Message = "Back again, I told you you'd like that drink. No friends this time? I hope you guys had" +
                        " a good time at this Opera you said your were going to. Oh, your friend forgot his credit stick, think" +
                        " you can give it back to him?",
                        //ModiftyCredits = 200
                     },
                new Location()
                       {
                         Id = 3,
                         Name = "I.C.S Warehouse",
                         Description = "The main doors are broken as you come up to the building. " +
                         "A set of stairs leads up to the second floor door that is open. Inside you find a number of broken boxes," +
                         " with the words Integrated Computer Systems on the side of some of them. A smell hits your nose as you turn to"+
                         " find the source. Two bodies are hidden off to back corner of the building, both male and dressed as streetpunks.",
                          Accessible = false,
                          ModifyMemoryPoints = 1,
                          RequiredMemoryPoints = 3
                       },
                new Location()
                       {
                        Id = 4,
                        Name = "Detroit Opera House",
                        Description = "The old Opera House is a shadow of what it use to be. The once bright gold and red" +
                        " colors now washed out over the years. The wind whistles through some of the holes in the building, as" +
                        " bits of water drips from the once grand arched ceiling. A number pops in your head as your hand touches a seat" +
                        "'318.'",
                        Accessible = false,
                        ModifyMemoryPoints = 1,
                        RequiredMemoryPoints = 2
                     }

            };
            gameMap.CurrentLocation = gameMap.Locations.FirstOrDefault(l => l.Id == 1);

            return gameMap;
        }
        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new Weapon(1001, "Chain-Blade", 50, 1, 4, "A small blade with tiny thin blades that spin around the edge", 1),
                new Weapon(1002, "H-Can-non Mk2", 250, 3, 9, "Small but powerful, the least anyone should have before going out alone", 10),
                new Treasure(2001, "Old Coin", 10, Treasure.TreasureType.Coin, "A coin with a face on one side faded with time", 0),
                new Treasure(2002, "Small Diamond", 50, Treasure.TreasureType.Jewel, "A small pea-sized diamond of various colors.", 0),
                new Treasure(2003, "Self-Portrait of Vincent van Gogh", 500, Treasure.TreasureType.Artifact, "Painted by the knonwn artist in mid-1887, it depicts him wearing a straw hat and turned to the right.", 5),
                new MedicalAid(3001, "Stimpak", 5, 30, "Pain numbing shot that will help for now. Add 30 points of health.", 5),
                new MedicalAid(3002, "Medi-Gel", 15, 55, "A gel that when applied to the wound, will send out nanomachines to heal. Add 55 points of health.", 5),
                new Clues(4001, "Bar Receipt", 5, "Marked 'Bad Luck Bar' and your drink The Alchemist.", 0, "Maybe the bartender will remember you.", Clues.UseActionType.OPENLOCATION),
                new Clues(4002, "Keycard", 5, "Keycard found under the seat in the Opera House", 5, "Placing the keycard to the door you hear the locks release.", Clues.UseActionType.OPENLOCATION)
            };
        }
    }
}

