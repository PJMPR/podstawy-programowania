using DungeonRider.App.UI;
using DungeonRider.Core.Game;

namespace DungeonRider.App;

public static class Program
{
    public static void Main()
    {
        DungeonGame game = DungeonGame.CreateSample();
        MapRenderer.Print(game);

        while (!game.IsFinished)
        {
            Console.Write("Ruch (WASD, Q — koniec): ");
            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Q) break;

            (int dx, int dy) = key switch
            {
                ConsoleKey.W => (0, -1),
                ConsoleKey.S => (0, 1),
                ConsoleKey.A => (-1, 0),
                ConsoleKey.D => (1, 0),
                _ => (0, 0)
            };

            if ((dx != 0 || dy != 0) && !game.Player.TryMove(dx, dy, game.Map))
                Console.WriteLine("Ruch zablokowany.");
            MapRenderer.Print(game);
        }

        Console.WriteLine(game.IsFinished ? "Dotarłeś do wyjścia!" : "Koniec gry.");
    }
}
