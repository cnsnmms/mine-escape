using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EscapeMines.MineFieldEnums;

namespace EscapeMines
{
    public class GameData
    {
        public uint BoardSizeX { get; set; }
        public uint BoardSizeY { get; set; }
        public List<Coordinate> MineCoordinates { get; set; }
        public Coordinate ExitPoint { get; set; }
        public Coordinate StartPosOfTurtle { get; set; }
        public TurtleDirection DirectionOfTurtle { get; set; }
        public List<string> SeriesOfMoves { get; set; }

        public GameData()
        {
            MineCoordinates = new List<Coordinate>();
            SeriesOfMoves = new List<string>();
        }
    }
}
