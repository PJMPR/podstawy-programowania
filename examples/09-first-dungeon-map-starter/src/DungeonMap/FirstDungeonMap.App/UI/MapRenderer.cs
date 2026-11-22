namespace FirstDungeonMap.App.UI;

public static class MapRenderer
{
    public static void Print(char[,] map, int playerX = -1, int playerY = -1)
    {
        // TODO: renderuj mapę w konwencji map[y, x]. Gracz ma być nakładką.
        Console.WriteLine($"[Mapa {map.GetLength(1)} × {map.GetLength(0)} — uzupełnij renderowanie]");
    }

    public static void PrintLegend()
    {
        Console.WriteLine("Legenda: # ściana | . podłoga | @ gracz | > wyjście | $ skarb");
    }
}
