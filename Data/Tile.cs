using DSharpPlus.Entities;
using sisbase;
using Sokobot_sharp.Data.Enums;
using System.Collections.Generic;

namespace Sokobot_sharp.Data {
    abstract class Tile {
        public TileType Type { get; set; }
        public Coordinate Coordinate { get; set; }
        public Grid Context { get; }
        public DiscordEmoji Emoji => map[Type];
        private Dictionary<TileType, DiscordEmoji> map = new Dictionary<TileType, DiscordEmoji> {
            [TileType.BOX] = DiscordEmoji.FromName(SisbaseBot.Instance.Client, ":brown_square:"),
            [TileType.GROUND] = DiscordEmoji.FromName(SisbaseBot.Instance.Client, ":black_large_square:"),
            [TileType.DESTINATION] = DiscordEmoji.FromName(SisbaseBot.Instance.Client, ":negative_squared_cross_mark:"),
            [TileType.PLAYER] = DiscordEmoji.FromName(SisbaseBot.Instance.Client, ":flushed:")
        };

        public Tile(int color, Coordinate p, Grid g) {
            map.Add(TileType.WALL, Color(color));
            Coordinate = p;
            Context = g;
        }

        public Tile(int color, Coordinate p, Grid g, DiscordEmoji customEmoji) {
            Coordinate = p;
            Context = g;
            map.Remove(TileType.PLAYER);
            map.Add(TileType.PLAYER, customEmoji);
            map.Add(TileType.WALL, Color(color));
        }

        public bool Is(TileType type) => Type == type;
        public Tile GetNeighbour(Side side) => side switch
        {
            Side.UP => Context.At(Coordinate.X, Coordinate.Y - 1),
            Side.DOWN => Context.At(Coordinate.X, Coordinate.Y + 1),
            Side.LEFT => Context.At(Coordinate.X - 1, Coordinate.Y),
            Side.RIGHT => Context.At(Coordinate.X + 1, Coordinate.Y),
            _ => this,
        };

        private DiscordEmoji Color(int color) => color switch
        {
            0 => DiscordEmoji.FromName(SisbaseBot.Instance.Client, ":red_square:"),
            1 => DiscordEmoji.FromName(SisbaseBot.Instance.Client, ":orange_square:"),
            2 => DiscordEmoji.FromName(SisbaseBot.Instance.Client, ":yellow_square:"),
            3 => DiscordEmoji.FromName(SisbaseBot.Instance.Client, ":green_square:"),
            4 => DiscordEmoji.FromName(SisbaseBot.Instance.Client, ":blue_square:"),
            _ => DiscordEmoji.FromName(SisbaseBot.Instance.Client, ":purple_square:"),
        };
    }
}
