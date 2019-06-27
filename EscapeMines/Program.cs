using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EscapeMines.MineFieldEnums;

namespace EscapeMines
{
    class Program
    {
        static void Main(string[] args)
        {
            GameData dt = Helpers.ReadData();
            foreach (var moves in dt.SeriesOfMoves)
            {
                Turtle tr = new Turtle(dt.StartPosOfTurtle.X, dt.StartPosOfTurtle.Y, dt.DirectionOfTurtle);
                Minefield mf = new Minefield(new Coordinate { X = dt.BoardSizeX, Y = dt.BoardSizeY }, dt.MineCoordinates, dt.ExitPoint, tr);
                var gameResult = mf.RunGame(moves);
                if (gameResult == GameResult.MineHit)
                {
                    Console.WriteLine(String.Format("Mine hit for the Moves of {0}.", moves));
                }
                else if (gameResult == GameResult.Success)
                {
                    Console.WriteLine(String.Format("Success for the Moves of {0}.", moves));
                }
                else
                {
                    Console.WriteLine(String.Format("Still in danger for the Moves of {0}.", moves));
                }
            }
            Console.Read();
        }
    }
}
