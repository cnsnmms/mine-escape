using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EscapeMines.MineFieldEnums;

namespace EscapeMines
{
    public class Minefield
    {
        private ITurtle _turtle;
        private uint xLength, yLength;
        //private uint[,] _listOfMines;
        private Dictionary<Coordinate, GameElements> _board;

        // I used tuples because every related data must be provided together. If I use plain int's it will hard to construct and initialization would be unsafe because of the number of the arguments. 
        /// <summary>
        /// Creates Minefield instance
        /// </summary>
        /// <param name="boardSizeXY"></param>
        /// <param name="listOfMines"></param>
        /// <param name="exitPointXY"></param>
        /// <param name="turtle"></param>
        public Minefield(Coordinate boardSizeXY, List<Coordinate> listOfMines, Coordinate exitPointXY, ITurtle turtle)
        {
            // Validations
            if (boardSizeXY.X * boardSizeXY.Y < listOfMines.Count)
            {
                throw new Exception("Number of mines must be less then the minearea cells.");
            }

            if (exitPointXY.X > boardSizeXY.X || exitPointXY.Y > boardSizeXY.Y)
            {
                throw new Exception("Wrong exit point coordinates. Exit point must be within the board.");
            }

            // Creation of the board
            xLength = boardSizeXY.X;
            yLength = boardSizeXY.Y;


            _board = new Dictionary<Coordinate, GameElements>();
            _board.Add(new Coordinate { X = exitPointXY.X, Y = exitPointXY.Y }, GameElements.Exit);

            foreach (var item in listOfMines)
            {
                _board.Add(new Coordinate { X = item.X, Y = item.Y }, GameElements.Mine);
            }

            // Turtle injection
            _turtle = turtle;
        }

        public GameResult RunGame(string actions)
        {
            foreach (var item in actions.Split())
            {
                if (item[0] == 'M')
                {
                    _turtle.Move();
                    var currResult = checkTurtle(_turtle.GetCoordinates());
                    if (currResult == GameResult.MineHit || currResult == GameResult.Success)
                    {
                        return currResult;
                    }
                }
                else if (item[0] == 'R' || item[0] == 'L')
                {
                    _turtle.Rotate((TurtleRotation)item[0]);
                }
                else
                {
                    throw new Exception("Wrong action. Allowed actions are M, R and L.");
                }
            }
            return GameResult.StillDanger;
        }

        private GameResult checkTurtle(Coordinate newCoords)
        {
            if (newCoords.X >= xLength || newCoords.Y >= yLength)
            {
                throw new Exception("Turtle is out of bound. Please keep the turtle inside.");
            }

            GameElements result;

            if (_board.TryGetValue(newCoords, out result))
            {
                switch (result)
                {
                    case GameElements.Exit:
                        return GameResult.Success;
                    default:
                        return GameResult.MineHit;
                }
            }
            else
            {
                return GameResult.StillDanger;
            }
        }
    }
}
