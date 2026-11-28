using DungeonRider.Core.Game;

namespace DungeonRider.App.UI;

public static class MapRenderer
{
    public static void Print(DungeonGame game)
    {
        for (int y = 0; y < game.Map.Height; y++)
        {
            for (int x = 0; x < game.Map.Width; x++)
                Console.Write(x == game.Player.X && y == game.Player.Y ? '@' : game.Map.GetField(x, y));
            Console.WriteLine();
        }
        Console.WriteLine("Legenda: # ściana | . podłoga | @ gracz | > wyjście | $ skarb");
        Console.WriteLine($"Gracz: {game.Player.Name} | Skarby: {game.Player.CollectedTreasures}");
    }
}
