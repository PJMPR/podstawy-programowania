namespace FirstDungeonMap.Core.Maps;

public static class DungeonMap
{
    public static char[,] Create(int width, int height)
    {
        if (width < 3 || height < 3)
        {
            throw new ArgumentException("Mapa musi mieć co najmniej 3 × 3 pola.");
        }

        char[,] map = new char[height, width];

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                bool isEdge = y == 0 || y == map.GetLength(0) - 1 ||
                              x == 0 || x == map.GetLength(1) - 1;
                map[y, x] = isEdge ? '#' : '.';
            }
        }

        return map;
    }

    public static char[,] CreateSample()
    {
        char[,] map = Create(12, 7);
        map[1, 10] = '>';
        map[3, 4] = '#';
        map[3, 5] = '#';
        map[4, 8] = '$';
        return map;
    }

    public static bool IsInside(char[,] map, int x, int y)
    {
        return x >= 0 && x < map.GetLength(1) && y >= 0 && y < map.GetLength(0);
    }

    public static bool IsWalkable(char[,] map, int x, int y)
    {
        return IsInside(map, x, y) && map[y, x] != '#';
    }

    public static int CountSymbol(char[,] map, char symbol)
    {
        int count = 0;

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == symbol)
                {
                    count++;
                }
            }
        }

        return count;
    }

    public static bool TryFindSymbol(char[,] map, char symbol, out int foundX, out int foundY)
    {
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == symbol)
                {
                    foundX = x;
                    foundY = y;
                    return true;
                }
            }
        }

        foundX = -1;
        foundY = -1;
        return false;
    }
}
