using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines
{
    /// <summary>
    /// Coordinate object
    /// </summary>
    public class Coordinate
    {
        /// <summary>
        /// X Axes value. Cannot be negative
        /// </summary>
        public uint X { get; set; }
        /// <summary>
        /// Y axes value. Cannot be negative
        /// </summary>
        public uint Y { get; set; }

        //Override of the Equals and GetHashCode for using the class as dictionary key
        public bool Equals(Coordinate coordinate)
        {
            return coordinate.X.Equals(X) && coordinate.Y.Equals(Y);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Coordinate);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
    }
}
