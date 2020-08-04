using Sokobot_sharp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sokobot_sharp {
    class Destination : Tile {
        public Destination(int color, Coordinate p, Grid g) : base(color, p, g) => Type = TileType.DESTINATION;
    }
}
