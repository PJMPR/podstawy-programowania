using FirstDungeonMap.App.UI;
using FirstDungeonMap.Core.Maps;

namespace FirstDungeonMap.App;

public static class Program
{
    private const int PlayerX = 2;
    private const int PlayerY = 2;

    public static void Main()
    {
        Console.WriteLine("=== PIERWSZA MAPA LOCHU — ROZWIĄZANIE ===");
        Console.WriteLine("Wybierz zadanie 1–7:");

        if (!int.TryParse(Console.ReadLine(), out int taskNumber) || taskNumber < 1 || taskNumber > 7)
        {
            Console.WriteLine("Niepoprawny numer zadania.");
            return;
        }

        switch (taskNumber)
        {
            case 1: Task1(); break;
            case 2: Task2(); break;
            case 3: Task3(); break;
            case 4: Task4(); break;
            case 5: Task5(); break;
            case 6: Task6(); break;
            case 7: Task7(); break;
        }
    }

    private static void Task1()
    {
        char[,] map =
        {
            { '#', '#', '#', '#', '#' },
            { '#', '.', '.', '>', '#' },
            { '#', '.', '.', '.', '#' },
            { '#', '#', '#', '#', '#' }
        };

        MapRenderer.Print(map);
    }

    private static void Task2()
    {
        const int width = 12;
        const int height = 7;
        char[,] map = new char[height, width];

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                bool isEdge = y == 0 || y == map.GetLength(0) - 1 || x == 0 || x == map.GetLength(1) - 1;
                map[y, x] = isEdge ? '#' : '.';
            }
        }

        MapRenderer.Print(map);
    }

    private static void Task3()
    {
        char[,] map = DungeonMap.CreateSample();
        MapRenderer.Print(map);
        MapRenderer.PrintLegend();
    }

    private static void Task4()
    {
        char[,] map = DungeonMap.CreateSample();
        MapRenderer.Print(map, PlayerX, PlayerY);
        Console.WriteLine($"Pole pod graczem nadal zawiera: '{map[PlayerY, PlayerX]}'.");
    }

    private static void Task5()
    {
        char[,] map = DungeonMap.CreateSample();
        int[,] coordinates = { { 2, 2 }, { 0, 0 }, { 20, 3 }, { 10, 5 } };

        for (int i = 0; i < coordinates.GetLength(0); i++)
        {
            int x = coordinates[i, 0];
            int y = coordinates[i, 1];
            Console.WriteLine($"({x}, {y}) -> wewnątrz: {DungeonMap.IsInside(map, x, y)}, dostępne: {DungeonMap.IsWalkable(map, x, y)}");
        }
    }

    private static void Task6()
    {
        char[,] map = DungeonMap.CreateSample();
        MapRenderer.Print(map, PlayerX, PlayerY);
        Console.WriteLine($"Ściany: {DungeonMap.CountSymbol(map, '#')}");
        Console.WriteLine($"Podłoga: {DungeonMap.CountSymbol(map, '.')}");
        Console.WriteLine($"Skarby: {DungeonMap.CountSymbol(map, '$')}");

        if (DungeonMap.TryFindSymbol(map, '>', out int exitX, out int exitY))
        {
            Console.WriteLine($"Wyjście: x={exitX}, y={exitY}");
        }
    }

    private static void Task7()
    {
        char[,] map = DungeonMap.Create(20, 10);

        for (int y = 2; y <= 7; y++)
        {
            map[y, 7] = '#';
        }

        map[5, 7] = '.';
        map[1, 18] = '>';
        map[2, 4] = '$';
        map[7, 15] = '$';

        int playerX = 2;
        int playerY = 8;
        MapRenderer.Print(map, playerX, playerY);
        MapRenderer.PrintLegend();
        Console.WriteLine($"Rozmiar: {map.GetLength(1)} × {map.GetLength(0)}");
        Console.WriteLine($"Skarby: {DungeonMap.CountSymbol(map, '$')}");
        Console.WriteLine($"Start jest dostępny: {DungeonMap.IsWalkable(map, playerX, playerY)}");
    }
}
