using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace TBQuestGame.Models
{
    public class Player : Character
    {
        #region ENUMS

        public enum JobTitleName { Hacker, StreetPunk, BountieHunter }

        #endregion

        #region FIELDS

        private int _credits;
        private int _health;
        private int _memoryPoints;
        private JobTitleName _jobTitle;
        private List<Location> _locationsVisited;
        private ObservableCollection<GameItem> _inventory;
        private ObservableCollection<GameItem> _medical;
        private ObservableCollection<GameItem> _treasure;
        private ObservableCollection<GameItem> _weapons;
        private ObservableCollection<GameItem> _clues;

        #endregion

        #region PROPERTIES

        public int Credits
        {
            get { return _credits; }
            set
            {
                _credits = value;
                OnPropertyChanged(nameof(Credits));
            }
        }

        public JobTitleName JobTitle
        {
            get { return _jobTitle; }
            set
            {
                _jobTitle = value;
                OnPropertyChanged(nameof(JobTitle));
            }
        }

        public int Health
        {
            get { return _health; }
            set
            {
                _health = value;

                if (_health > 100)
                {
                    _health = 100;
                }
                // gameover
                //else if (_health <= 0)
               // {
               // }

                OnPropertyChanged(nameof(Health));
            }
        }

        public int MemoryPoints
        {
            get { return _memoryPoints; }
            set
            {
                _memoryPoints = value;
                OnPropertyChanged(nameof(MemoryPoints));
            }
        }
        public List<Location> LocationsVisited
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value; }
        }
        public ObservableCollection<GameItem> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        public ObservableCollection<GameItem> Weapons
        {
            get { return _weapons; }
            set { _weapons = value; }
        }

        public ObservableCollection<GameItem> Medical
        {
            get { return _medical; }
            set { _medical = value; }
        }

        public ObservableCollection<GameItem> Treasure
        {
            get { return _treasure; }
            set { _treasure = value; }
        }

        public ObservableCollection<GameItem> Clues
        {
            get { return _clues; }
            set { _clues = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Player()
        {
            _locationsVisited = new List<Location>();
            _weapons = new ObservableCollection<GameItem>();
            _treasure = new ObservableCollection<GameItem>();
            _medical = new ObservableCollection<GameItem>();
            _clues = new ObservableCollection<GameItem>();
        }

        #endregion

        #region METHODS


        //
        // set the players wealth based on the initial inventory
        //
        public void CalculateCredit()
        {
            Credits = _inventory.Sum(i => i.Value);
        }

        /// <summary>
        /// update the game item category lists
        /// </summary>
        public void UpdateInventoryCategories()
        {
            Medical.Clear();
            Weapons.Clear();
            Treasure.Clear();
            Clues.Clear();

            foreach (var gameItem in _inventory)
            {
                if (gameItem is MedicalAid) Medical.Add(gameItem);
                if (gameItem is Weapon) Weapons.Add(gameItem);
                if (gameItem is Treasure) Treasure.Add(gameItem);
                if (gameItem is Clues) Clues.Add(gameItem);
            }
        }

        /// <summary>
        /// add selected item to inventory
        /// </summary>
        /// <param name="selectedGameItem">selected item</param>
        public void AddGameItemToInventory(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _inventory.Add(selectedGameItem);
            }
        }

        /// <summary>
        /// remove selected item from inventory
        /// </summary>
        /// <param name="selectedGameItem">selected item</param>
        public void RemoveGameItemFromInventory(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _inventory.Remove(selectedGameItem);
            }
        }


        public bool HasVisited(Location location)
        {
            return _locationsVisited.Contains(location);
        }

        /// <summary>
        /// override the default greeting in the Character class to include the job title
        /// set the proper article based on the job title
        /// </summary>
        /// <returns>default greeting</returns>
        public override string DefaultGreeting()
        {
            string article = "a";

            List<string> vowels = new List<string>() { "A", "E", "I", "O", "U" };

            if (vowels.Contains(_jobTitle.ToString().Substring(0, 1))) ;
            {
                article = "an";
            }

            return $"Hello, my name is {_name} and I am {article} {_jobTitle} living in the undercity of Neo-Detroit.";
        }

        #endregion

        #region EVENTS



        #endregion

    }
}
