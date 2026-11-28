namespace DungeonRaider.App.UI;

public static class MapRenderer
{
    public static void Print(
        char[,] map, int playerX, int playerY,
        int enemyX = -1, int enemyY = -1,
        int gold = 0, bool hasKey = false,
        int moves = 0, string message = "")
    {
        // TODO Zadanie 3: wyświetl mapę; @ i M mają być nakładkami.
        Console.WriteLine($"[Mapa {map.GetLength(1)} × {map.GetLength(0)} — uzupełnij renderer]");
        Console.WriteLine($"Złoto: {gold} | Klucz: {(hasKey ? "tak" : "nie")} | Ruchy: {moves}");
        Console.WriteLine(message);
    }

    public static void PrintLegend()
    {
        Console.WriteLine("Legenda: # ściana | . podłoga | G złoto | K klucz | D drzwi | E wyjście | @ gracz | M przeciwnik");
    }
}
