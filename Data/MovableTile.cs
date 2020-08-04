using DSharpPlus.Entities;
using Sokobot_sharp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sokobot_sharp.Data {
    abstract class MovableTile : Tile {
        public Coordinate InitialCoordinate { get; }
        public MovableTile(int color, Coordinate p, Grid g) : base(color, p, g) => InitialCoordinate = p;
        public MovableTile(int color, Coordinate p, Grid g, DiscordEmoji e) : base(color, p, g,e) => InitialCoordinate = p;
        abstract public bool Move(Side side);
        public void ResetCoordinate() => Coordinate = InitialCoordinate;
    }
}
