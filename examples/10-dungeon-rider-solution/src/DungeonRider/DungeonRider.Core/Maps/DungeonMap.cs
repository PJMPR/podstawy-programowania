namespace DungeonRider.Core.Maps;

public class DungeonMap
{
    private readonly char[,] fields;

    public int Width => fields.GetLength(1);
    public int Height => fields.GetLength(0);

    public DungeonMap(int width, int height)
    {
        if (width < 3 || height < 3)
            throw new ArgumentException("Mapa musi mieć co najmniej 3 × 3 pola.");

        fields = new char[height, width];
        for (int y = 0; y < Height; y++)
        for (int x = 0; x < Width; x++)
            fields[y, x] = IsEdge(x, y) ? '#' : '.';
    }

    public char GetField(int x, int y)
    {
        EnsureInside(x, y);
        return fields[y, x];
    }

    public void SetField(int x, int y, char symbol)
    {
        EnsureInside(x, y);
        fields[y, x] = symbol;
    }

    public bool IsInside(int x, int y) => x >= 0 && x < Width && y >= 0 && y < Height;
    public bool IsWalkable(int x, int y) => IsInside(x, y) && fields[y, x] != '#';

    public int Count(char symbol)
    {
        int count = 0;
        for (int y = 0; y < Height; y++)
        for (int x = 0; x < Width; x++)
            if (fields[y, x] == symbol) count++;
        return count;
    }

    public bool TryFind(char symbol, out int foundX, out int foundY)
    {
        for (int y = 0; y < Height; y++)
        for (int x = 0; x < Width; x++)
            if (fields[y, x] == symbol)
            {
                foundX = x;
                foundY = y;
                return true;
            }
        foundX = -1;
        foundY = -1;
        return false;
    }

    private bool IsEdge(int x, int y) => x == 0 || x == Width - 1 || y == 0 || y == Height - 1;

    private void EnsureInside(int x, int y)
    {
        if (!IsInside(x, y)) throw new ArgumentOutOfRangeException($"Pole ({x}, {y}) leży poza mapą.");
    }
}
