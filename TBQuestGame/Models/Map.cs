using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TBQuestGame.Models
{
    public class Map
    {
        #region FIELDS
        private ObservableCollection<Location> _locations;
        private Location _currentLocation;
        private ObservableCollection<Location> _accessibleLocations;
        private List<GameItem> _standardGameItems;

        #endregion

        #region PROPERTIES
        public ObservableCollection<Location> Locations
        {
            get { return _locations; }
            set { _locations = value; }
        }
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set { _currentLocation = value; }
        }
        public ObservableCollection<Location> AccessibleLocations
        {
            get
            {
                ObservableCollection<Location> _accessibleLocations = new ObservableCollection<Location>();
                foreach (var location in _locations)
                {
                    if (location.Accessible == true)
                    {
                        _accessibleLocations.Add(location);
                    }
                }

                return _accessibleLocations;
            }

        }
        public List<GameItem> StandardGameItems
        {
            get { return _standardGameItems; }
            set { _standardGameItems = value; }
        }
        #endregion

        #region CONSTRUCTORS

        #endregion

        #region METHODS

        /// <summary>
        /// open the location controlled by a given clue
        /// </summary>
        /// <param name="clueId"></param>
        /// <returns>user message regarding success of attempt</returns>
        public string OpenLocationsByClue(int clueId)
        {
            string message = "This clue is not helpful here.";
            Location mapLocation = new Location();
              if (mapLocation != null && mapLocation.RequiredClueId == clueId)
                {
                    mapLocation.Accessible = true;
                    message = $"{mapLocation.Name} is now accessible.";
                }
                

            return message;
        }

        public void Move(Location location)
        {
            _currentLocation = location;
        }
        #endregion
    }
}
