const int PlayerX = 2;
const int PlayerY = 2;

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

static void Task1()
{
    char[,] map =
    {
        { '#', '#', '#', '#', '#' },
        { '#', '.', '.', '>', '#' },
        { '#', '.', '.', '.', '#' },
        { '#', '#', '#', '#', '#' }
    };

    for (int y = 0; y < map.GetLength(0); y++)
    {
        for (int x = 0; x < map.GetLength(1); x++)
        {
            Console.Write(map[y, x]);
        }

        Console.WriteLine();
    }
}

static void Task2()
{
    DungeonMap.Print(DungeonMap.Create(12, 7));
}

static void Task3()
{
    DungeonMap.Print(DungeonMap.CreateSample());
    DungeonMap.PrintLegend();
}

static void Task4()
{
    char[,] map = DungeonMap.CreateSample();
    DungeonMap.Print(map, PlayerX, PlayerY);
    Console.WriteLine($"Pole pod graczem nadal zawiera: '{map[PlayerY, PlayerX]}'.");
}

static void Task5()
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

static void Task6()
{
    char[,] map = DungeonMap.CreateSample();
    DungeonMap.Print(map, PlayerX, PlayerY);

    Console.WriteLine($"Ściany: {DungeonMap.CountSymbol(map, '#')}");
    Console.WriteLine($"Podłoga: {DungeonMap.CountSymbol(map, '.')}");
    Console.WriteLine($"Skarby: {DungeonMap.CountSymbol(map, '$')}");

    if (DungeonMap.TryFindSymbol(map, '>', out int exitX, out int exitY))
    {
        Console.WriteLine($"Wyjście: x={exitX}, y={exitY}");
    }
}

static void Task7()
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

    DungeonMap.Print(map, playerX, playerY);
    DungeonMap.PrintLegend();
    Console.WriteLine($"Rozmiar: {map.GetLength(1)} × {map.GetLength(0)}");
    Console.WriteLine($"Skarby: {DungeonMap.CountSymbol(map, '$')}");
    Console.WriteLine($"Start jest dostępny: {DungeonMap.IsWalkable(map, playerX, playerY)}");
}
