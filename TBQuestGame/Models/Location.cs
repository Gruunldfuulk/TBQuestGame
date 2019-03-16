using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region METHODS
        public override string ToString()
        {
            return _name;
        }
        #endregion
    }
}
