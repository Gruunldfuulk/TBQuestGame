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
                Lives = 1,
                Health = 70,
                Credits = 500,
                MemoryPoints = 0,
                LocationId = 0,
                SkillLevel = 5,
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
        private static Npc NpcById(int id)
        {
            return Npcs().FirstOrDefault(i => i.Id == id);
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
                          ModifyMemoryPoints = 0,
                                   GameItems = new ObservableCollection<GameItem>
                                       {
                                           GameItemById(4001),
                                           GameItemById(3001)
                                       }
                       },
                new Location()
                       {
                        Id = 2,
                        Name = "Bad Luck Bar",
                        Description = "The glowing red eye sign in the back seems familiar and draws you into the building." +
                        " Inside hang four hexagon lights with a soft white light hitting the crowd in here tonight." +
                        " The bartender looks up at you, giving a nod of recognition.",
                        Accessible = false,
                        RequiredClueId = 4001,
                        ModifyMemoryPoints = 1,
                                   Npcs = new ObservableCollection<Npc>()
                                       {
                                           NpcById(1001),
                                           NpcById(1002)
                                       }
                     },
                new Location()
                       {
                         Id = 3,
                         Name = "I.C.S Warehouse",
                         Description = "The main doors are broken as you come up to the building. " +
                         "A set of stairs leads up to the second floor door that is open. Inside you find a number of broken boxes," +
                         " with the words Integrated Computer Systems on the side of some of them. A smell hits your nose as you turn to"+
                         " find the source. Two bodies are hidden off to back corner of the building, bloodied and dressed as streetpunks."+
                         " One of them is still alive, holding their side they looks up at you with a half smile.",
                          Accessible = false,
                          ModifyMemoryPoints = 1,
                          RequiredMemoryPoints = 5,
                                GameItems = new ObservableCollection<GameItem>
                                    {
                                        GameItemById(1002)
                                    },
                                Npcs = new ObservableCollection<Npc>()
                                {
                                    NpcById(1003)
                                }
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
                        RequiredMemoryPoints = 2,
                                GameItems = new ObservableCollection<GameItem>
                                    {
                                        GameItemById(4002)
                                    }
                     },

                new Location()
                       {
                        Id = 5,
                        Name = "Detroit Police Station",
                        Description = "The station is busy as ever, with punks on the wall being detained and cops running" +
                        " around with their holopads. The lights are flickering and the sound of a man on the floor" +
                        " cussing out a officer eachos down the hall. The hall leads you to a cluttered desk filled with" +
                        " papper work and cigarette butts. The sargent gives you a half-hearted glance, before going back" +
                        " to this work.",
                        Accessible = false,
                        ModifyMemoryPoints = 1,
                        RequiredMemoryPoints = 3,
                                  Npcs = new ObservableCollection<Npc>()
                                {
                                    NpcById(2002)
                                }
                     },
                new Location()
                       {
                        Id = 6,
                        Name = "Detroit Institute of Arts ",
                        Description = "The greyed out marble steps lead you up to the heavy brass double doors. " +
                        " As you come into the great hall you start to hear sounds coming in from the left hall." +
                        " The rooms are made to look new, but you can't help to laugh at how off they were." +
                        " As you come to the far wall, you find the 'Glass Art' room with a man kneeling down" +
                        " looking through a case that was knocked over.",
                        Accessible = false,
                        ModifyMemoryPoints = 1,
                        RequiredMemoryPoints = 6,
                                GameItems = new ObservableCollection<GameItem>
                                    {
                                        GameItemById(2003),
                                        GameItemById(2002)
                                    },
                                Npcs = new ObservableCollection<Npc>()
                                {
                                    NpcById(2001)
                                }
                     }

            };
            gameMap.CurrentLocation = gameMap.Locations.FirstOrDefault(l => l.Id == 1);

            return gameMap;
        }
        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new Weapon(1001, "Chain-Blade", 50, 1, 4, "A small blade with tiny thin blades that spin around the edge", 0),
                new Weapon(1002, "H-Can-non Mk2", 250, 3, 9, "Small but powerful, the least anyone should have before going out alone", 0),
                new Treasure(2001, "Old Coin", 10, Treasure.TreasureType.Coin, "A coin with a face on one side faded with time", 0),
                new Treasure(2002, "Small Diamond", 50, Treasure.TreasureType.Jewel, "A small pea-sized diamond of various colors.", 0),
                new Treasure(2003, "Self-Portrait of Vincent van Gogh", 500, Treasure.TreasureType.Artifact, "Painted by the knonwn artist in mid-1887, it depicts him wearing a straw hat and turned to the right.", 0),
                new MedicalAid(3001, "Stimpak", 5, 30, "Pain numbing shot that will help for now. Add 30 points of health.", 0, "You inject the stimpack into your leg, healing you up a bit."),
                new MedicalAid(3002, "Medi-Gel", 15, 55, "A gel that when applied to the wound, will send out nanomachines to heal. Add 55 points of health.", 5, "You rub the gel on your injury, healing you up a lot."),
                new Clues(4001, "Bar Receipt", 5, "Marked 'Bad Luck Bar' and your drink The Alchemist.", 1, "Maybe the bartender will remember you.", Clues.UseActionType.OPENLOCATION),
                new Clues(4002, "Keycard", 5, "Keycard found under the seat in the Opera House", 1, "Placing the keycard to the door you hear the locks release.", Clues.UseActionType.OPENLOCATION)
            };
        }
        public static List<Npc> Npcs()
        {
            return new List<Npc>()
            {
                new Hostile()
                {
                    Id = 2001,
                    Name = "Jack Decker",
                    Race = Character.RaceType.Human,
                    Description = "A short, stocky man, with a mohawk with a strong look of determination and a disposition to match.",
                    Messages = new List<string>()
                    {
                        "You never should have come here.",
                        "Could have just stayed at home, you were lucky.",
                        "You think you got what it takes to fight me?"
                    },
                   SkillLevel = 4,
                   //Weapons = new List<Weapon>()
                   //{
                   //    GameItemById(1001) as Weapons
                   //}
                },
                new Hostile()
                {
                    Id = 2002,
                    Name = "Sargent Bones",
                    Race = Character.RaceType.Human,
                    Description = "A tall and built man, with a shaved head and red beard.",
                    Messages = new List<string>()
                    {
                        "Need something? I'm a busy man.",
                        "Anything to report?",
                        "Seems there's been some sort of break-in at the I.C.S Warehouse."
                    },
                   SkillLevel = 3,
                   //Weapons = new List<Weapon>()
                   //{
                   //    GameItemById(1001) as Weapons
                   //}
                },

                new NonHostile()
                {
                    Id = 1001,
                    Name = "Hextor Freeze",
                    Race = Character.RaceType.Human,
                    Description = "A tall man with a small black mustache and his hair shaved on side",
                    Messages = new List<string>()
                    {
                        "Back again, I told you would like that drink.",
                        "No friends this time? I hope you guys had a good time at this Opera you said your were going to.",
                        "Oh, your friend forgot his credit stick, think you can give it back to him?" //ModiftyCredits = 200
                    }
                },
                new NonHostile()
                {
                    Id = 1002,
                    Name = "Lilianna Starbreeze",
                    Race = Character.RaceType.Elf,
                    Description = "A tall women of a thin build and pointed ears.",
                    Messages = new List<string>()
                    {
                        "Excuse me, but my kind does not speak with your kind."
                    }
                },

                new NonHostile()
                {
                    Id = 1003,
                    Name = "Maz Gar-Talda",
                    Race = Character.RaceType.Orc,
                    Description = "A build looking orc woman, with one broken tusk and pale green skin.",
                    Messages = new List<string>()
                    {
                        "Hey there Ajax, where were you?",
                        "It was Hextor, he got us here and must have stopped you somehow.",
                        "There don't forget the pick up that gun, you'll need it.",
                        "He took what he was looking for here, said something about going to see some art"
                    }
                }
            };
        }
    }
}

