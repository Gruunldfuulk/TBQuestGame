using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TBQuestGame.Models
{
    public class Location
    {
        #region FIELDS
        private int _id;
        private string _name;
        private string _description;
        private bool _accessible;
        private int _modifyMemoryPoints;
        private int _requiredClueId;
        private int _requiredMemoryPoints;
        private int _modifyHealth;
        private int _modifyCredits;
        private string _message;
        private ObservableCollection<GameItem> _gameItems;

        #endregion

        #region PROPERTIES
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public bool Accessible
        {
            get { return _accessible; }
            set { _accessible = value; }
        }
        public int ModifyMemoryPoints
        {
            get { return _modifyMemoryPoints; }
            set { _modifyMemoryPoints = value; }
        }
        public int RequiredMemoryPoints
        {
            get { return _requiredMemoryPoints; }
            set { _requiredMemoryPoints = value; }
        }
        public int ModifyHealth
        {
            get { return _modifyHealth; }
            set { _modifyHealth = value; }
        }
        public int ModifyCredits
        {
            get { return _modifyCredits; }
            set { _modifyCredits = value; }
        }
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        public int RequiredClueId
        {
            get { return _requiredClueId; }
            set { _requiredClueId = value; }
        }
        public ObservableCollection<GameItem> GameItems
        {
            get { return _gameItems; }
            set { _gameItems = value; }
        }

        #endregion

        #region CONSTRUCTORS
        public Location()
        {
            _gameItems = new ObservableCollection<GameItem>();
        }


        #endregion

        #region METHODS
        //
        // location is open if character has enough XP
        //
        public bool IsAccessibleByMemoryPoints(int playerMemoryPoints)
        {
            return playerMemoryPoints >= _requiredMemoryPoints ? true : false;
        }

        //
        // Stopgap to force the list of items in the location to update
        //
        // todo Velis refactor using the CollectionChanged event
        public void UpdateLocationGameItems()
        {
            ObservableCollection<GameItem> updatedLocationGameItems = new ObservableCollection<GameItem>();

            foreach (GameItem GameItem in _gameItems)
            {
                updatedLocationGameItems.Add(GameItem);
            }

            GameItems.Clear();

            foreach (GameItem gameItem in updatedLocationGameItems)
            {
                GameItems.Add(gameItem);
            }
        }

        /// <summary>
        /// add selected item to location
        /// </summary>
        /// <param name="selectedGameItem">selected item</param>
        public void AddGameItemToLocation(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _gameItems.Add(selectedGameItem);
            }

            UpdateLocationGameItems();
        }

        /// <summary>
        /// remove selected item from location
        /// </summary>
        /// <param name="selectedGameItem">selected item</param>
        public void RemoveGameItemFromLocation(GameItem selectedGameItem)
        {
            if (selectedGameItem != null)
            {
                _gameItems.Remove(selectedGameItem);
            }

            UpdateLocationGameItems();
        }


        public override string ToString()
        {
            return _name;
        }
        #endregion
    }
}
