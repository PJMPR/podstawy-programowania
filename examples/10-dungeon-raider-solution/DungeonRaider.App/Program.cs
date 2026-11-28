using DungeonRaider.App.UI;
using DungeonRaider.Core.Game;

namespace DungeonRaider.App;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("=== DUNGEON RAIDER — ROZWIĄZANIE ===");
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
        while (true)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Q) return;

            if (Movement.TryGetDirection(key, out int dx, out int dy))
            {
                Console.WriteLine($"{key}: dx={dx}, dy={dy}");
            }
            else
            {
                Console.WriteLine("Ten klawisz nie oznacza ruchu.");
            }
        }
    }

    private static void Task2()
    {
        int playerX = 2;
        int playerY = 2;
        Console.WriteLine("WASD zmienia pozycję, Q kończy.");

        while (true)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Q) return;
            if (!Movement.TryGetDirection(key, out int dx, out int dy)) continue;

            int nextX = playerX + dx;
            int nextY = playerY + dy;
            Console.WriteLine($"Aktualna: ({playerX}, {playerY}), proponowana: ({nextX}, {nextY})");
            playerX = nextX;
            playerY = nextY;
        }
    }

    private static void Task3() => RunGame(CreateBasicMap(), false, false, false, false);

    private static void Task4()
    {
        char[,] map = CreateBasicMap();
        map[1, 3] = 'G';
        map[4, 8] = 'G';
        RunGame(map, true, false, false, false);
    }

    private static void Task5()
    {
        char[,] map = CreateBasicMap();
        map[1, 4] = 'G';
        map[4, 2] = 'K';
        map[3, 6] = 'D';
        RunGame(map, true, true, false, false);
    }

    private static void Task6() => RunGame(CreateEnemyMap(), false, false, true, false);

    private static void Task7() => RunGame(CreateProjectMap(), true, true, true, true);

    private static void RunGame(
        char[,] map, bool useItems, bool useDoor,
        bool useEnemy, bool useExit)
    {
        int playerX = 1;
        int playerY = 1;
        int enemyX = useEnemy ? 10 : -1;
        int enemyY = useEnemy ? 5 : -1;
        int gold = 0;
        int moves = 0;
        bool hasKey = false;
        bool gameOver = false;
        string ending = "";
        string message = "Znajdź drogę przez loch.";
        int totalGold = CountSymbol(map, 'G');

        while (!gameOver)
        {
            MapRenderer.Print(map, playerX, playerY, enemyX, enemyY, gold, hasKey, moves, message);
            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Q)
            {
                ending = "REZYGNACJA";
                message = "Gracz zakończył rozgrywkę.";
                break;
            }

            if (!Movement.TryGetDirection(key, out int dx, out int dy))
            {
                message = "Nieznane polecenie.";
                continue;
            }

            int nextX = playerX + dx;
            int nextY = playerY + dy;

            if (!Movement.CanEnter(map, nextX, nextY, useDoor && hasKey))
            {
                message = Movement.IsInside(map, nextX, nextY) && map[nextY, nextX] == 'D'
                    ? "Drzwi są zamknięte. Potrzebujesz klucza."
                    : "Ruch jest zablokowany.";
                continue;
            }

            playerX = nextX;
            playerY = nextY;
            moves++;
            message = "Wykonano ruch.";

            if (useItems)
            {
                char field = map[playerY, playerX];
                if (field == 'G')
                {
                    gold++;
                    map[playerY, playerX] = '.';
                    message = "Zebrano złoto.";
                }
                else if (useDoor && field == 'K')
                {
                    hasKey = true;
                    map[playerY, playerX] = '.';
                    message = "Zebrano klucz.";
                }
                else if (useDoor && field == 'D')
                {
                    hasKey = false;
                    map[playerY, playerX] = '.';
                    message = "Otwarto drzwi. Klucz został zużyty.";
                }
            }

            if (useExit && map[playerY, playerX] == 'E')
            {
                if (gold == totalGold)
                {
                    gameOver = true;
                    ending = "ZWYCIĘSTWO";
                    message = "Zebrano całe złoto i opuszczono loch.";
                }
                else
                {
                    message = $"Wyjście jest zamknięte. Brakuje złota: {totalGold - gold}.";
                }
            }

            if (!gameOver && useEnemy)
            {
                Movement.TryMoveEnemy(map, playerX, playerY, ref enemyX, ref enemyY);
                if (enemyX == playerX && enemyY == playerY)
                {
                    gameOver = true;
                    ending = "PORAŻKA";
                    message = "Przeciwnik złapał gracza.";
                }
            }
        }

        MapRenderer.Print(map, playerX, playerY, enemyX, enemyY, gold, hasKey, moves, message);
        Console.WriteLine($"=== {ending} ===");
        Console.WriteLine($"Wynik: {gold}/{totalGold} złota, ruchy: {moves}.");
    }

    private static int CountSymbol(char[,] map, char symbol)
    {
        int count = 0;
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == symbol) count++;
            }
        }
        return count;
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

    private static char[,] CreateEnemyMap()
    {
        return new char[,]
        {
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '#' },
            { '#', '.', '#', '#', '.', '#', '.', '#', '#', '#', '.', '#' },
            { '#', '.', '.', '#', '.', '#', '.', '.', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '#', '.', '.', '.', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '#' },
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
