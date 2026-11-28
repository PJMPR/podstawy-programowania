using DungeonRider.Core.Maps;

namespace DungeonRider.Core.Game;

public class DungeonGame
{
    public DungeonMap Map { get; }
    public Player Player { get; }
    public bool IsFinished => Map.GetField(Player.X, Player.Y) == '>';

    public DungeonGame(DungeonMap map, Player player)
    {
        Map = map;
        Player = player;
    }

    public static DungeonGame CreateSample()
    {
        DungeonMap map = new(12, 7);
        map.SetField(10, 1, '>');
        map.SetField(8, 4, '$');
        map.SetField(4, 3, '#');
        map.SetField(5, 3, '#');
        return new DungeonGame(map, new Player("Ada", 2, 2));
    }
}
