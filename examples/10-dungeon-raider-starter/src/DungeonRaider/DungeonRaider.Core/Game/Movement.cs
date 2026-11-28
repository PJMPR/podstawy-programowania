namespace DungeonRaider.Core.Game;

public static class Movement
{
    public static bool TryGetDirection(ConsoleKey key, out int dx, out int dy)
    {
        // TODO Zadanie 1: zamień W/A/S/D na dx i dy.
        dx = 0;
        dy = 0;
        return false;
    }

    public static bool IsInside(char[,] map, int x, int y)
    {
        // TODO Zadanie 3: sprawdź cztery granice.
        return false;
    }

    public static bool CanEnter(char[,] map, int x, int y, bool hasKey)
    {
        // TODO Zadania 3 i 5: obsłuż granice, ściany i drzwi.
        return false;
    }

    public static bool TryMoveEnemy(
        char[,] map, int playerX, int playerY,
        ref int enemyX, ref int enemyY)
    {
        // TODO Zadanie 6: spróbuj osi X, a następnie osi Y.
        return false;
    }
}
