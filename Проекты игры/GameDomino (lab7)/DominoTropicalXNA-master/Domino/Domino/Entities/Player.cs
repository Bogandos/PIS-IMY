using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domino.Entities
{
    public class Player
    {
        #region Fields

        string _strName;
        bool _myTurn;
        bool _isHuman;

        // Если 1, плитка была сыграна на правой стороне стола. Если 2, плитка была сыграна на левой стороне стола
        int _positionOfTileLastPlayed;

        #endregion

        #region Properties

        public string Name
        {
            get { return _strName; }
            set { _strName = value; }
        }

        public bool MyTurn
        {
            get { return _myTurn; }
            set { _myTurn = value; }
        }

        public bool IsHuman
        {
            get { return _isHuman; }
            set { _isHuman = value; }
        }

        public int PositionOfTileLastPlayed
        {
            get { return _positionOfTileLastPlayed; }
            set { _positionOfTileLastPlayed = value; }
        }

        public List<Tile> PlayerTileList { get; set; } 
      
        #endregion

        #region Constructors

        public Player()
        {
        }

        public Player(string Name, bool MyTurn, bool IsHuman)
        {
            this.Name = Name;

            this.PlayerTileList = new List<Tile>();

            this.MyTurn = MyTurn;
            this.IsHuman = IsHuman;
            this.PositionOfTileLastPlayed = new int();
        }
        #endregion

        #region Methods/Functions
        
        #endregion

        #region Events
        
        #endregion

    }
}
