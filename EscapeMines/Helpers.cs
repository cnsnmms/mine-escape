using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static EscapeMines.MineFieldEnums;

namespace EscapeMines
{
    public static class Helpers
    {
        /// <summary>
        /// Reads and validates text data
        /// </summary>
        /// <returns></returns>
        public static GameData ReadData()
        {
            GameData result = new GameData();
            string[] lines = System.IO.File.ReadAllLines(@"..\..\TestMoves.txt");

            if (lines.Length < 5)
            {
                throw new Exception("Wrong number of lines in the file");
            }

            if (Regex.IsMatch(lines[0], @"^[1-9]\d*\s[1-9]\d*$"))
            {
                var sizes = lines[0].Split();
                result.BoardSizeX = Convert.ToUInt32(sizes[0]);
                result.BoardSizeY = Convert.ToUInt32(sizes[1]);
            }
            else
            {
                throw new Exception("Board size is wrong.");
            }

            if (Regex.IsMatch(lines[1], @"([0-9]\d*,[0-9]\d*)*"))
            {
                var coordinates = lines[1].Split();
                foreach (var item in coordinates)
                {
                    var dt = item.Split(',');
                    result.MineCoordinates.Add(new Coordinate
                    {
                        X = Convert.ToUInt32(dt[0]),
                        Y = Convert.ToUInt32(dt[1])
                    });
                }
            }
            else
            {
                throw new Exception("Mines coordinates are wrong");
            }

            if (Regex.IsMatch(lines[2], @"^[0-9]\d*\s[0-9]\d*$"))
            {
                var ep = lines[2].Split();
                result.ExitPoint = new Coordinate { X = Convert.ToUInt32(ep[0]), Y = Convert.ToUInt32(ep[1]) };
            }
            else
            {
                throw new Exception("Exit point is wrong.");
            }

            if (Regex.IsMatch(lines[3], @"^[0-9]\d*\s[0-9]\d*\s(N|W|S|E)$"))
            {
                var trtl = lines[3].Split();
                result.StartPosOfTurtle = new Coordinate { X = Convert.ToUInt32(trtl[0]), Y = Convert.ToUInt32(trtl[1]) };
                result.DirectionOfTurtle = ConvertDirectionToEnum(trtl[2][0]);
            }
            else
            {
                throw new Exception("Turtle data is wrong.");
            }

            for (int i = 4; i < lines.Length; i++)
            {
                if (Regex.IsMatch(lines[i], @"[M|L|R \s]+"))
                {
                    result.SeriesOfMoves.Add(lines[i]);
                }
                else
                {
                    throw new Exception("Movement data is wrong.");
                }
            }

            return result;
        }

        /// <summary>
        /// Converts direction char to enum.
        /// </summary>
        /// <param name="c">Char value N | W | S | E</param>
        /// <returns></returns>
        private static TurtleDirection ConvertDirectionToEnum(char c)
        {
            if (c.Equals('N'))
            {
                return TurtleDirection.North;
            }
            else if (c.Equals('W'))
            {
                return TurtleDirection.West;
            }
            else if (c.Equals('S'))
            {
                return TurtleDirection.South;
            }
            else if (c.Equals('E'))
            {
                return TurtleDirection.East;
            }
            else
            {
                throw new Exception("Wrong direction data for the turtle.");
            }
        }

    }
}
