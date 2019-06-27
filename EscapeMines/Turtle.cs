using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EscapeMines.MineFieldEnums;

namespace EscapeMines
{
    /// <summary>
    /// Interface for turtles
    /// </summary>
    public interface ITurtle
    {
        /// <summary>
        ///  Moves the turtle
        /// </summary>
        void Move();
        /// <summary>
        /// Rotates the turtle
        /// </summary>
        /// <param name="rotate">Rotation parameter, right or left</param>
        void Rotate(TurtleRotation rotate);
        /// <summary>
        /// Returns the coordinates of the turtle
        /// </summary>
        /// <returns></returns>
        Coordinate GetCoordinates();
    }

    /// <summary>
    /// Turtle object
    /// </summary>
    public class Turtle : ITurtle
    {
        /// <summary>
        /// Holds the direction of the turtle
        /// </summary>
        private TurtleDirection _direction;

        /// <summary>
        /// Current coordinates of the turtle
        /// </summary>
        private Coordinate _coordinate;

        /// <summary>
        /// Creates a new Turtle
        /// </summary>
        /// <param name="x">Initial position of the turtle on the x axes</param>
        /// <param name="y">Initial position of the turtle on the y axes</param>
        /// <param name="y">Initial direction of the turtle</param>
        public Turtle(uint x, uint y, TurtleDirection direction)
        {
            _coordinate = new Coordinate { X = x, Y = y };
            _direction = direction;
        }

        /// <summary>
        /// Moves the turtle
        /// </summary>
        public void Move()
        {
            switch (_direction)
            {
                case TurtleDirection.East:
                    _coordinate.X++;
                    break;
                case TurtleDirection.West:
                    _coordinate.X--;
                    break;
                case TurtleDirection.South:
                    _coordinate.Y--;
                    break;
                default:
                    _coordinate.Y++;
                    break;
            }
        }

        /// <summary>
        /// Rotates the turtle to Right or Left
        /// </summary>
        /// <param name="rotation"></param>
        public void Rotate(TurtleRotation rotation)
        {
            int currentDegrees = (int)_direction;
            int degree = rotation == TurtleRotation.Right ? 90 : -90;
            _direction = CalcNewDirection(currentDegrees + degree);
        }

        /// <summary>
        /// Returns the coordinates of the turtle
        /// </summary>
        /// <returns></returns>
        public Coordinate GetCoordinates()
        {
            return new Coordinate { X = _coordinate.X, Y = _coordinate.Y };
        }

        /// <summary>
        /// Calculates the new direction of the turtle using degree convertion
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns></returns>
        private TurtleDirection CalcNewDirection(int degrees)
        {
            int result = degrees < 0 ? (int)(degrees % 360) + 360 : (int)(degrees % 360);
            return (TurtleDirection)result;
        }
    }
}
