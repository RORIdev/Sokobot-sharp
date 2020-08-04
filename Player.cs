using DSharpPlus.Entities;
using Sokobot_sharp.Data;
using Sokobot_sharp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sokobot_sharp {
    class Player : MovableTile {
        public Player(int color, Coordinate p, Grid g) : base(color, p, g) => Type = TileType.PLAYER;

        public Player(int color, Coordinate p, Grid g, DiscordEmoji e) : base(color, p, g, e) => Type = TileType.PLAYER;

        public override bool Move(Side side) {
            var neighbour = GetNeighbour(side);
            if (neighbour == null) return false;
            if (neighbour.Is(TileType.WALL)) return false;
            if (neighbour is Box box && !box.Move(side)) return false;
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
