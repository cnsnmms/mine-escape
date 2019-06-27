using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines
{
    public class MineFieldEnums
    {
        public enum GameElements
        {
            Mine = 0,
            Exit = 1
        }

        public enum TurtleDirection
        {
            North = 0,
            East = 90,
            South = 180,
            West = 270
        }

        public enum TurtleRotation
        {
            Right = 'R',
            Left = 'L'
        }

        public enum GameResult
        {
            Success = 0,
            MineHit = 1,
            StillDanger = 2
        }
    }
}
