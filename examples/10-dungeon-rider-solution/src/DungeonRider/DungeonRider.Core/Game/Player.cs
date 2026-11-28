using DungeonRider.Core.Maps;

namespace DungeonRider.Core.Game;

public class Player
{
    public string Name { get; }
    public int X { get; private set; }
    public int Y { get; private set; }
    public int MovesCount { get; private set; }
    public int CollectedTreasures { get; private set; }

    public Player(string name, int x, int y)
    {
        Name = string.IsNullOrWhiteSpace(name) ? "Gracz" : name;
        X = x;
        Y = y;
    }

    public bool TryMove(int dx, int dy, DungeonMap map)
    {
        int nextX = X + dx;
        int nextY = Y + dy;
        if (!map.IsWalkable(nextX, nextY)) return false;
        X = nextX;
        Y = nextY;
        MovesCount++;
        CollectTreasure(map);
        return true;
    }

    private void CollectTreasure(DungeonMap map)
    {
        if (map.GetField(X, Y) != '$') return;
        CollectedTreasures++;
        map.SetField(X, Y, '.');
    }
}
