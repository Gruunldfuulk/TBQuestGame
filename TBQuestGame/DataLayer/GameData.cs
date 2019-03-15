using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;

namespace TBQuestGame.DataLayer
{
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
                Lives = 3,
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
    }
}

