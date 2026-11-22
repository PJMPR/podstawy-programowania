namespace FirstDungeonMap.App.UI;

public static class MapRenderer
{
    public static void Print(char[,] map, int playerX = -1, int playerY = -1)
    {
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                Console.Write(x == playerX && y == playerY ? '@' : map[y, x]);
            }

            Console.WriteLine();
        }
    }

    public static void PrintLegend()
    {
        Console.WriteLine("Legenda: # ściana | . podłoga | @ gracz | > wyjście | $ skarb");
    }
}
