using DungeonRaider.App.UI;
using DungeonRaider.Core.Game;

namespace DungeonRaider.App;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("=== DUNGEON RAIDER — STARTER ===");
        Console.Write("Wybierz zadanie 1–7: ");

        if (!int.TryParse(Console.ReadLine(), out int number) || number < 1 || number > 7)
        {
            Console.WriteLine("Niepoprawny numer zadania.");
            return;
        }

        switch (number)
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
        Console.WriteLine("Naciskaj W/A/S/D. Q kończy zadanie.");
        // TODO: odczytuj klawisze i wyświetlaj dx/dy.
    }

    private static void Task2()
    {
        int playerX = 2;
        int playerY = 2;
        Console.WriteLine($"Pozycja początkowa: ({playerX}, {playerY})");
        // TODO: obliczaj i zatwierdzaj proponowaną pozycję.
    }

    private static void Task3()
    {
        char[,] map = CreateBasicMap();
        // TODO: dodaj pętlę ruchu z kolizjami.
        MapRenderer.Print(map, 1, 1, message: "Uzupełnij zadanie 3.");
    }

    private static void Task4()
    {
        char[,] map = CreateBasicMap();
        map[1, 3] = 'G';
        map[4, 8] = 'G';
        // TODO: dodaj licznik i zbieranie złota.
        MapRenderer.Print(map, 1, 1);
    }

    private static void Task5()
    {
        char[,] map = CreateBasicMap();
        map[4, 2] = 'K';
        map[2, 6] = 'D';
        // TODO: dodaj stan klucza i otwieranie drzwi.
        MapRenderer.Print(map, 1, 1);
    }

    private static void Task6()
    {
        char[,] map = CreateBasicMap();
        // TODO: dodaj przeciwnika i jego turę.
        MapRenderer.Print(map, 1, 1, 9, 4);
    }

    private static void Task7()
    {
        char[,] map = CreateProjectMap();
        // TODO: połącz wszystkie mechaniki w projekt „Ucieczka z lochu”.
        MapRenderer.Print(map, 1, 1, 10, 5);
        MapRenderer.PrintLegend();
    }

    private static char[,] CreateBasicMap()
    {
        return new char[,]
        {
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', '.', '.', '.', '.', '.', '#', '.', '.', '.', '.', '#' },
            { '#', '.', '#', '#', '.', '.', '#', '.', '#', '#', '.', '#' },
            { '#', '.', '.', '#', '.', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '#', '#', '.', '.', '.', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
        };
    }

    private static char[,] CreateProjectMap()
    {
        return new char[,]
        {
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', '.', '.', 'G', '.', '#', '.', '.', '.', '.', '.', '.', 'E', '#' },
            { '#', '.', '#', '#', '.', '#', '.', '#', '#', '#', '.', '#', '#', '#' },
            { '#', '.', '.', '#', '.', '.', 'K', '.', '.', '#', '.', '.', '.', '#' },
            { '#', '#', '.', '#', '#', '#', 'D', '#', '.', '#', '#', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '#', '.', '.', '.', '.', '.', '#' },
            { '#', '.', '#', '#', '#', 'G', '.', '.', '.', '#', '#', '.', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
        };
    }
}
