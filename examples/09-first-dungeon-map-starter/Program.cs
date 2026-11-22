const int PlayerX = 2;
const int PlayerY = 2;

Console.WriteLine("=== PIERWSZA MAPA LOCHU — STARTER ===");
Console.WriteLine("Wybierz zadanie 1–7:");

if (!int.TryParse(Console.ReadLine(), out int taskNumber) || taskNumber < 1 || taskNumber > 7)
{
    Console.WriteLine("Niepoprawny numer zadania.");
    return;
}

switch (taskNumber)
{
    case 1:
        Task1();
        break;
    case 2:
        Task2();
        break;
    case 3:
        Task3();
        break;
    case 4:
        Task4();
        break;
    case 5:
        Task5();
        break;
    case 6:
        Task6();
        break;
    case 7:
        Task7();
        break;
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

    // TODO: wyświetl mapę wierszami za pomocą dwóch zagnieżdżonych pętli.
    Console.WriteLine($"Mapa ma {map.GetLength(0)} wiersze i {map.GetLength(1)} kolumn.");
}

static void Task2()
{
    const int width = 12;
    const int height = 7;
    char[,] map = new char[height, width];

    // TODO: wypełnij krawędzie znakiem '#', a wnętrze znakiem '.'.
    DungeonMap.Print(map);
}

static void Task3()
{
    char[,] map = DungeonMap.Create(12, 7);

    // TODO: dodaj wyjście '>', skarb '$' oraz co najmniej trzy przeszkody '#'.
    DungeonMap.Print(map);
}

static void Task4()
{
    char[,] map = DungeonMap.CreateSample();

    // TODO: wyświetl '@' w pozycji gracza, nie zapisując go do tablicy map.
    DungeonMap.Print(map);
    Console.WriteLine($"Gracz: x={PlayerX}, y={PlayerY}");
}

static void Task5()
{
    char[,] map = DungeonMap.CreateSample();

    // TODO: uzupełnij IsInside i IsWalkable, a następnie sprawdź poniższe pola.
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

    // TODO: policz symbole i znajdź wyjście. Nie zakładaj na stałe rozmiaru mapy.
    DungeonMap.Print(map, PlayerX, PlayerY);
    Console.WriteLine("Uzupełnij raport mapy.");
}

static void Task7()
{
    // TODO: zaprojektuj własną mapę zgodnie z wymaganiami zadania projektowego.
    char[,] map = DungeonMap.CreateSample();
    DungeonMap.Print(map, PlayerX, PlayerY);
    DungeonMap.PrintLegend();
}
