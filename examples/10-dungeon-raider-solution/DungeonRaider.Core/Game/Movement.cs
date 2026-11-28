namespace DungeonRaider.Core.Game;

public static class Movement
{
    public static bool TryGetDirection(ConsoleKey key, out int dx, out int dy)
    {
        dx = 0;
        dy = 0;

        switch (key)
        {
            case ConsoleKey.W: dy = -1; return true;
            case ConsoleKey.A: dx = -1; return true;
            case ConsoleKey.S: dy = 1; return true;
            case ConsoleKey.D: dx = 1; return true;
            default: return false;
        }
    }

    public static bool IsInside(char[,] map, int x, int y)
    {
        return x >= 0 && x < map.GetLength(1) &&
               y >= 0 && y < map.GetLength(0);
    }

    public static bool CanEnter(char[,] map, int x, int y, bool hasKey)
    {
        if (!IsInside(map, x, y))
        {
            return false;
        }

        char field = map[y, x];
        return field != '#' && (field != 'D' || hasKey);
    }

    public static bool TryMoveEnemy(
        char[,] map, int playerX, int playerY,
        ref int enemyX, ref int enemyY)
    {
        int stepX = Math.Sign(playerX - enemyX);
        if (stepX != 0 && CanEnemyEnter(map, enemyX + stepX, enemyY))
        {
            enemyX += stepX;
            return true;
        }

        int stepY = Math.Sign(playerY - enemyY);
        if (stepY != 0 && CanEnemyEnter(map, enemyX, enemyY + stepY))
        {
            enemyY += stepY;
            return true;
        }

        return false;
    }

    private static bool CanEnemyEnter(char[,] map, int x, int y)
    {
        return IsInside(map, x, y) && map[y, x] != '#' && map[y, x] != 'D';
    }
}
