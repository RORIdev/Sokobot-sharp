using Sokobot_sharp.Data;
using Sokobot_sharp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sokobot_sharp {
    class Box : MovableTile {
        public Box(int color, Coordinate p, Grid g) : base(color, p, g) => Type = TileType.BOX;
        public override bool Move(Side side) {
            var neighbour = GetNeighbour(side);
            if (neighbour == null) return false;
            if (neighbour.Is(TileType.BOX) || neighbour.Is(TileType.WALL)) return false;
            if (neighbour.Is(TileType.DESTINATION)) {
                Type = TileType.GROUND;
                neighbour.Type = TileType.WALL;
                return true;
            }
            switch (side) {
                case Side.UP:
                    Coordinate.Y--;
                    break;
                case Side.DOWN:
                    Coordinate.Y++;
                    break;
                case Side.LEFT:
                    Coordinate.X--;
                    break;
                case Side.RIGHT:
                    Coordinate.X++;
                break;
            }
            return true;
        }
    }
}
