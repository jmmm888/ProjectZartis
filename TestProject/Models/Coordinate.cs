using System;
using System.Net;

namespace TestProject.Models
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return "Position X: " + X + " Y: " + Y;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Coordinate);
        }

        public bool Equals(Coordinate other)
        {
            if (other == null)
                return false;

            return this.X.Equals(other.X) && this.Y.Equals(other.Y);
        }

    }
}

