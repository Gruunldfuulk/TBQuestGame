using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;
using TBQuestGame;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using WPFTBQuestGameS2;
using System.Windows.Data;
using System.Windows;

namespace TBQuestGame.PresentationLayer
{
    public class GameSessionViewModel : ObservableObject
    {
        #region ENUMS



        #endregion

        #region FIELDS

        private Player _player;
        private List<string> _messages;
        private DateTime _gameStartTime;

        private Map _gameMap;
        private Location _currentLocation;
        private string _currentLocationName;
        private string _currentLocationInformation;
        private ObservableCollection<Location> _accessibleLocations;

        private GameItem _currentGameItem;


        #endregion

        #region PROPERTIES

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        public string MessageDisplay
        {
            get { return FormatMessagesForViewer(); }
        }

        public GameItem CurrentGameItem
        {
            get { return _currentGameItem; }
            set { _currentGameItem = value; }
        }


        public string CurrentLocationInformation
        {
            get { return _currentLocationInformation; }
            set
            {
                _currentLocationInformation = value;
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
        }
        #endregion

        #region CONSTRUCTORS

        public GameSessionViewModel()
        {

        }

        public GameSessionViewModel(
            Player player,
            List<string> initialMessages,
            Map gameMap,
            Location currentLocation)
        {
            _player = player;
            _messages = initialMessages;
            _gameMap = gameMap;
            _currentLocation = currentLocation;
            InitializeView();
        }
        public ObservableCollection<Location> AccessibleLocations
        {
            get { return _accessibleLocations; }
            set { _accessibleLocations = value; }
        }


        public string CurrentLocationName
        {
            get { return _currentLocationName; }

            set
            {
                _currentLocationName = value;
                OnPlayerMove();
                OnPropertyChanged("CurrentLocation");
            }
        }


        public Location CurrentLocation
        {
            get { return _currentLocation; }

            set
            {
                _currentLocation = value;
            }
        }


        public Map GameMap
        {
            get { return _gameMap; }
            set { _gameMap = value; }
        }

        

        #endregion

        #region METHODS

        /// <summary>
        /// initial setup of the game session view
        /// </summary>
        private void InitializeView()
        {
            _gameStartTime = DateTime.Now;
            _accessibleLocations = _gameMap.AccessibleLocations;
            _player.UpdateInventoryCategories();    
            _player.CalculateCredit();
        }

        /// <summary>
        /// generates a sting of mission messages with time stamp with most current first
        /// </summary>
        /// <returns>string of formated mission messages</returns>
        private string FormatMessagesForViewer()
        {
            List<string> lifoMessages = new List<string>();

            for (int index = 0; index < _messages.Count; index++)
            {
                lifoMessages.Add($" <T:{GameTime().ToString(@"hh\:mm\:ss")}> " + _messages[index]);
            }

            lifoMessages.Reverse();

            return string.Join("\n\n", lifoMessages);
        }

        /// <summary>
        /// running time of game
        /// </summary>
        /// <returns></returns>
        private TimeSpan GameTime()
        {
            return DateTime.Now - _gameStartTime;
        }

        private void OnPlayerMove()
        {
            //
            // set new current location
            //
            foreach (Location location in AccessibleLocations)
            {
                if (location.Name == _currentLocationName)
                {
                    _currentLocation = location;
                }
            }
            //_currentLocation = AccessibleLocations.FirstOrDefault(l => l.Name == _currentLocationName);

            //
            // update stats if player has not visited the location
            //
            if (!_player.HasVisited(_currentLocation))
            {
                //
                // update list of visited locations
                //
                _player.LocationsVisited.Add(_currentLocation);

                //
                // update player memory points
                //
                _player.MemoryPoints += _currentLocation.ModifyMemoryPoints;
                _player.Credits += _currentLocation.ModifyCredits;

            }

            //
            // display a new message if available
            //
            OnPropertyChanged(nameof(MessageDisplay));


            //
            // update the list of locations
            //
            UpdateAccessibleLocations();
        }

        /// <summary>
        /// update the accessible locations for the list box
        /// </summary>
        private void UpdateAccessibleLocations()
        {
            //
            // reset accessible locations list
            //
            _accessibleLocations.Clear();

            //
            // add all accessible locations to list
            //
            foreach (Location location in _gameMap.Locations)
            {
                if (
                    location.Accessible == true ||
                    _player.MemoryPoints >= location.RequiredMemoryPoints)
                {
                    _accessibleLocations.Add(location);
                }
            }

            //
            // remove current location
            //
            _accessibleLocations.Remove(_accessibleLocations.FirstOrDefault(l => l == _currentLocation));

            //
            // notify list box in view to update
            //
            OnPropertyChanged(nameof(AccessibleLocations));
        }

        /// <summary>
        /// add a new item to the players inventory
        /// </summary>
        /// <param name="selectedItem"></param>
        public void AddItemToInventory()
        {
            //
            // confirm a game item selected and is in current location
            // subtract from location and add to inventory
            //
            if (_currentGameItem != null && _currentLocation.GameItems.Contains(_currentGameItem))
            {
                //
                // cast selected game item 
                //
                GameItem selectedGameItem = _currentGameItem as GameItem;

                _currentLocation.RemoveGameItemFromLocation(selectedGameItem);
                _player.AddGameItemToInventory(selectedGameItem);

                OnPlayerPickUp(selectedGameItem);
            }
        }

        /// <summary>
        /// remove item from the players inventory
        /// </summary>
        /// <param name="selectedItem"></param>
        public void RemoveItemFromInventory()
        {
            //
            // confirm a game item selected
            // subtract from inventory and add to location
            //
            if (_currentGameItem != null)
            {
                //
                // cast selected game item 
                //
                GameItem selectedGameItem = _currentGameItem as GameItem;

                _currentLocation.AddGameItemToLocation(selectedGameItem);
                _player.RemoveGameItemFromInventory(selectedGameItem);

                OnPlayerPutDown(selectedGameItem);
            }
        }
        /// <summary>
        /// process events when a player picks up a new game item
        /// </summary>
        /// <param name="gameItem">new game item</param>
        private void OnPlayerPickUp(GameItem gameItem)
        {
            _player.MemoryPoints += gameItem.ExperiencePoints;
            _player.Credits += gameItem.Value;
        }

        /// <summary>
        /// process events when a player puts down a new game item
        /// </summary>
        /// <param name="gameItem">new game item</param>
        private void OnPlayerPutDown(GameItem gameItem)
        {
            _player.Credits -= gameItem.Value;
        }
        /// <summary>
        /// process using an item in the player's inventory
        /// </summary>
        public void OnUseGameItem()
        {
            switch (_currentGameItem)
            {
                case MedicalAid medical:
                    ProcessMedicalUse(medical);
                    break;
                case Clues clues:
                    ProcessClueUse(clues);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// process the effects of using the relic
        /// </summary>
        /// <param name="Clue">potion</param>
        private void ProcessClueUse(Clues clues)
        {
            string message;

            switch (clues.UseAction)
            {
                case Clues.UseActionType.OPENLOCATION:
                    message = _gameMap.OpenLocationsByClue(clues.Id);
                    CurrentLocationInformation = clues.UseMessage;
                    break;
                case Clues.UseActionType.KILLPLAYER:
                    OnPlayerDies(clues.UseMessage);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// process the effects of using the potion
        /// </summary>
        /// <param name="medical">potion</param>
        private void ProcessMedicalUse(MedicalAid medical)
        {
            _player.Health += medical.HealthChange;
            _player.RemoveGameItemFromInventory(_currentGameItem);
        }

        /// <summary>
        /// process player dies with option to reset and play again
        /// </summary>
        /// <param name="message">message regarding player death</param>
        private void OnPlayerDies(string message)
        {
            string messagetext = message +
                "\n\nWould you like to play again?";

            string titleText = "Death";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(messagetext, titleText, button);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    ResetPlayer();
                    break;
                case MessageBoxResult.No:
                    QuiteApplication();
                    break;
            }
        }
        /// <summary>
        /// player chooses to exit game
        /// </summary>
        private void QuiteApplication()
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// player chooses to reset game
        /// </summary>
        private void ResetPlayer()
        {
            Environment.Exit(0);
        }

        #endregion

        #region EVENTS



        #endregion
    }
}
