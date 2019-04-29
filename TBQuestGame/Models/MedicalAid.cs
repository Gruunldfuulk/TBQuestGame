using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class MedicalAid : GameItem
    {
        public int HealthChange { get; set; }
        

        public MedicalAid(int id, string name, int value, int healthChange, string description, int experiencePoints, string useMessage)
            : base(id, name, value, description, experiencePoints, useMessage)
        {
            HealthChange = healthChange;
            
        }

        public override string InformationString()
        {
            if (HealthChange != 0)
            {
                return $"{Name}: {Description}\nHealth: {HealthChange}";
            }
            else
            {
                return $"{Name}: {Description}";
            }
        }
    }
}
