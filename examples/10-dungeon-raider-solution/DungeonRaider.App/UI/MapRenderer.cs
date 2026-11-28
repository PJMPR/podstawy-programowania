namespace DungeonRaider.App.UI;

public static class MapRenderer
{
    public static void Print(
        char[,] map, int playerX, int playerY,
        int enemyX = -1, int enemyY = -1,
        int gold = 0, bool hasKey = false,
        int moves = 0, string message = "")
    {
        Console.Clear();

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (x == playerX && y == playerY)
                {
                    Console.Write('@');
                }
                else if (x == enemyX && y == enemyY)
                {
                    Console.Write('M');
                }
                else
                {
                    Console.Write(map[y, x]);
                }
            }

            Console.WriteLine();
        }

        Console.WriteLine($"Złoto: {gold} | Klucz: {(hasKey ? "tak" : "nie")} | Ruchy: {moves}");
        Console.WriteLine(message);
        Console.WriteLine("WASD — ruch | Q — koniec");
    }

    public static void PrintLegend()
    {
        Console.WriteLine("Legenda: # ściana | . podłoga | G złoto | K klucz | D drzwi | E wyjście | @ gracz | M przeciwnik");
    }
}
