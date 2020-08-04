using System;
using System.Collections.Generic;
using System.Text;

namespace Sokobot_sharp.Data {
    class Coordinate {
        public int X;
        public int Y;
        public Coordinate(int x, int y) {
            X = x;
            Y = y;
        }
        public static bool operator==(Coordinate left, Coordinate notleft) {
            if (left.X == notleft.X && left.Y == notleft.Y) return true;
            return false;
        }
        public static bool operator!=(Coordinate left, Coordinate notleft) {
            if (!(left == notleft)) return true;
            return false;
        }
    }

}
