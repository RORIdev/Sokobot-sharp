using Sokobot_sharp.Data;
using Sokobot_sharp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokobot_sharp {
    class Grid {
        public List<Tile> Tiles { get; }

        public Tile At(Coordinate coord) => Tiles.FirstOrDefault(x => x.Coordinate == coord);
        public Tile At(int x, int y) => At(new Coordinate(x, y));
    }
}
