class Game
{
    private const string SaveFileName = "savegame.txt";
    private const string SaveVersion = "ROGUE_SAVE_1";

    private GameState state;
    private Player player;
    private char[,] map;
    private List<Enemy> enemies;
    private Dictionary<char, string> legend;
    private Random random;
    private int level;
    private string message;

    public Game()
    {
        state = GameState.Menu;
        enemies = new List<Enemy>();
        legend = new Dictionary<char, string>();
        random = new Random();
        message = "";

        legend.Add('#', "ściana");
        legend.Add('.', "podłoga");
        legend.Add('@', "bohater");
        legend.Add('E', "przeciwnik");
        legend.Add('$', "złoto");
        legend.Add('!', "mikstura");
        legend.Add('>', "wyjście");
    }

    public void Run()
    {
        while (state != GameState.Exit)
        {
            if (state == GameState.Menu)
            {
                ShowMenu();
            }
            else if (state == GameState.Playing)
            {
                PlayTurn();
            }
            else if (state == GameState.Victory)
            {
                ShowEndScreen(true);
            }
            else if (state == GameState.Defeat)
            {
                ShowEndScreen(false);
            }
        }

        Console.Clear();
        Console.WriteLine("Dziękujemy za grę!");
    }

    private void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("========================");
        Console.WriteLine("      ROGUE 1.0");
        Console.WriteLine("========================");
        Console.WriteLine("1. Nowa gra");
        Console.WriteLine("2. Wczytaj grę");
        Console.WriteLine("3. Instrukcja");
        Console.WriteLine("4. Wyjście");
        Console.Write("Wybór: ");

        string command = Console.ReadLine();

        if (command == "1")
        {
            StartNewGame();
        }
        else if (command == "2")
        {
            if (LoadGame())
            {
                state = GameState.Playing;
            }
            else
            {
                WaitForKey();
            }
        }
        else if (command == "3")
        {
            ShowInstructions();
        }
        else if (command == "4")
        {
            state = GameState.Exit;
        }
        else
        {
            Console.WriteLine("Nieznana opcja.");
            WaitForKey();
        }
    }

    private void StartNewGame()
    {
        Console.Clear();
        Console.Write("Podaj imię bohatera: ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            name = "Bohater";
        }

        player = new Player(name, 1, 1);
        level = 1;
        LoadLevel(level);
        message = "Znajdź wyjście. Najpierw pokonaj wszystkich przeciwników.";
        state = GameState.Playing;
    }

    private void ShowInstructions()
    {
        Console.Clear();
        Console.WriteLine("STEROWANIE");
        Console.WriteLine("W, A, S, D — ruch");
        Console.WriteLine("E — użycie mikstury");
        Console.WriteLine("P — zapis gry");
        Console.WriteLine("Q — powrót do menu");
        Console.WriteLine();
        Console.WriteLine("Wejście na przeciwnika rozpoczyna turę walki.");
        Console.WriteLine("Wyjście otworzy się po pokonaniu wszystkich przeciwników.");
        Console.WriteLine();
        Console.WriteLine("LEGENDA");

        foreach (KeyValuePair<char, string> element in legend)
        {
            Console.WriteLine($"{element.Key} — {element.Value}");
        }

        WaitForKey();
    }

    private void PlayTurn()
    {
        DrawGame();
        ConsoleKey key = Console.ReadKey(true).Key;

        if (key == ConsoleKey.Q)
        {
            state = GameState.Menu;
            return;
        }

        if (key == ConsoleKey.P)
        {
            SaveGame();
            return;
        }

        if (key == ConsoleKey.E)
        {
            if (player.UsePotion())
            {
                message = "Bohater wypił miksturę i odzyskał zdrowie.";
            }
            else
            {
                message = "Nie możesz teraz użyć mikstury.";
            }

            return;
        }

        int dx = 0;
        int dy = 0;

        if (key == ConsoleKey.W)
        {
            dy = -1;
        }
        else if (key == ConsoleKey.S)
        {
            dy = 1;
        }
        else if (key == ConsoleKey.A)
        {
            dx = -1;
        }
        else if (key == ConsoleKey.D)
        {
            dx = 1;
        }
        else
        {
            message = "Nieznany klawisz.";
            return;
        }

        TryMovePlayer(dx, dy);
    }

    private void TryMovePlayer(int dx, int dy)
    {
        int newX = player.X + dx;
        int newY = player.Y + dy;

        if (!IsInsideMap(newX, newY))
        {
            message = "Nie możesz wyjść poza mapę.";
            return;
        }

        if (map[newY, newX] == '#')
        {
            message = "Drogę blokuje ściana.";
            return;
        }

        Enemy enemy = FindEnemy(newX, newY);

        if (enemy != null)
        {
            Fight(enemy);

            if (state == GameState.Defeat)
            {
                return;
            }

            if (enemy.Health > 0)
            {
                return;
            }
        }

        player.X = newX;
        player.Y = newY;
        CollectItem();

        if (map[player.Y, player.X] == '>')
        {
            TryFinishLevel();
        }
        else if (enemy == null)
        {
            message = "Bohater przesunął się na nowe pole.";
        }
    }

    private void Fight(Enemy enemy)
    {
        int playerDamage = random.Next(4, 9);
        bool criticalHit = random.Next(1, 101) <= 20;

        if (criticalHit)
        {
            playerDamage *= 2;
        }

        enemy.TakeDamage(playerDamage);
        message = $"Atakujesz {enemy.Name}: {playerDamage} obrażeń";

        if (criticalHit)
        {
            message += " (trafienie krytyczne)";
        }

        message += ".";

        if (enemy.Health == 0)
        {
            enemies.Remove(enemy);
            int reward = random.Next(3, 9);
            player.Gold += reward;
            message += $" Przeciwnik pokonany. Zdobywasz {reward} złota.";

            if (random.Next(1, 101) <= 30)
            {
                player.Inventory.Add("Mikstura");
                message += " Znajdujesz miksturę.";
            }

            return;
        }

        int enemyDamage = random.Next(2, 7);
        player.TakeDamage(enemyDamage);
        message += $" {enemy.Name} odpowiada za {enemyDamage}.";

        if (player.Health == 0)
        {
            state = GameState.Defeat;
        }
    }

    private void CollectItem()
    {
        char field = map[player.Y, player.X];

        if (field == '$')
        {
            int amount = random.Next(5, 13);
            player.Gold += amount;
            map[player.Y, player.X] = '.';
            message = $"Znajdujesz {amount} sztuk złota.";
        }
        else if (field == '!')
        {
            player.Inventory.Add("Mikstura");
            map[player.Y, player.X] = '.';
            message = "Znajdujesz miksturę.";
        }
    }

    private void TryFinishLevel()
    {
        if (enemies.Count > 0)
        {
            message = "Wyjście jest zamknięte. Pokonaj pozostałych przeciwników.";
            return;
        }

        if (level == 1)
        {
            level = 2;
            LoadLevel(level);
            message = "Wchodzisz na ostatni poziom lochu.";
        }
        else
        {
            state = GameState.Victory;
        }
    }

    private void DrawGame()
    {
        Console.Clear();
        Console.WriteLine($"{player.Name} | HP: {player.Health}/{player.MaxHealth} | Złoto: {player.Gold} | Poziom: {level}");
        Console.WriteLine($"Mikstury: {CountItem("Mikstura")} | Przeciwnicy: {enemies.Count}");
        Console.WriteLine();

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (player.X == x && player.Y == y)
                {
                    WriteSymbol('@');
                }
                else if (FindEnemy(x, y) != null)
                {
                    WriteSymbol('E');
                }
                else
                {
                    WriteSymbol(map[y, x]);
                }
            }

            Console.WriteLine();
        }

        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine(message);
        Console.WriteLine("WASD: ruch | E: mikstura | P: zapis | Q: menu");
    }

    private void WriteSymbol(char symbol)
    {
        if (symbol == '@')
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        else if (symbol == 'E')
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else if (symbol == '$')
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        else if (symbol == '!' || symbol == '>')
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        Console.Write(symbol);
    }

    private int CountItem(string itemName)
    {
        int count = 0;

        foreach (string item in player.Inventory)
        {
            if (item == itemName)
            {
                count++;
            }
        }

        return count;
    }

    private Enemy FindEnemy(int x, int y)
    {
        foreach (Enemy enemy in enemies)
        {
            if (enemy.X == x && enemy.Y == y)
            {
                return enemy;
            }
        }

        return null;
    }

    private bool IsInsideMap(int x, int y)
    {
        return x >= 0 && x < map.GetLength(1) && y >= 0 && y < map.GetLength(0);
    }

    private void LoadLevel(int number)
    {
        string[] rows;
        enemies.Clear();

        if (number == 1)
        {
            rows = new string[]
            {
                "###############",
                "#@............#",
                "#..#####......#",
                "#......#......#",
                "#..$...#..!...#",
                "#......#......#",
                "#......#####..#",
                "#............>#",
                "###############"
            };

            enemies.Add(new Enemy("Goblin", 12, 4, 3));
            enemies.Add(new Enemy("Szczur", 8, 12, 6));
        }
        else
        {
            rows = new string[]
            {
                "###############",
                "#@....#.......#",
                "#.###.#.#####.#",
                "#...#.#.....#.#",
                "#.$.#...!...#.#",
                "#...#####...#.#",
                "#.............#",
                "#............>#",
                "###############"
            };

            enemies.Add(new Enemy("Ork", 18, 3, 6));
            enemies.Add(new Enemy("Strażnik", 22, 10, 3));
        }

        map = CreateMap(rows);
        ValidateEnemyPositions();
    }

    private void ValidateEnemyPositions()
    {
        foreach (Enemy enemy in enemies)
        {
            if (!IsInsideMap(enemy.X, enemy.Y))
            {
                throw new Exception($"Przeciwnik {enemy.Name} znajduje się poza mapą.");
            }

            if (map[enemy.Y, enemy.X] == '#')
            {
                throw new Exception($"Przeciwnik {enemy.Name} znajduje się w ścianie.");
            }
        }
    }

    private char[,] CreateMap(string[] rows)
    {
        int height = rows.Length;
        int width = rows[0].Length;
        char[,] newMap = new char[height, width];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                char symbol = rows[y][x];

                if (symbol == '@')
                {
                    player.X = x;
                    player.Y = y;
                    newMap[y, x] = '.';
                }
                else
                {
                    newMap[y, x] = symbol;
                }
            }
        }

        return newMap;
    }

    private void SaveGame()
    {
        List<string> lines = new List<string>();
        lines.Add(SaveVersion);
        lines.Add(player.Name);
        lines.Add(player.Health.ToString());
        lines.Add(player.MaxHealth.ToString());
        lines.Add(player.Gold.ToString());
        lines.Add(player.X.ToString());
        lines.Add(player.Y.ToString());
        lines.Add(level.ToString());
        lines.Add(player.Inventory.Count.ToString());

        foreach (string item in player.Inventory)
        {
            lines.Add(item);
        }

        lines.Add(map.GetLength(0).ToString());
        lines.Add(map.GetLength(1).ToString());

        for (int y = 0; y < map.GetLength(0); y++)
        {
            string row = "";

            for (int x = 0; x < map.GetLength(1); x++)
            {
                row += map[y, x];
            }

            lines.Add(row);
        }

        lines.Add(enemies.Count.ToString());

        foreach (Enemy enemy in enemies)
        {
            lines.Add($"{enemy.Name}|{enemy.Health}|{enemy.X}|{enemy.Y}");
        }

        try
        {
            File.WriteAllLines(SaveFileName, lines);
            message = $"Gra została zapisana w pliku {SaveFileName}.";
        }
        catch (Exception exception)
        {
            message = $"Nie udało się zapisać gry: {exception.Message}";
        }
    }

    private bool LoadGame()
    {
        if (!File.Exists(SaveFileName))
        {
            Console.WriteLine("Nie znaleziono pliku zapisu.");
            return false;
        }

        try
        {
            string[] lines = File.ReadAllLines(SaveFileName);
            int index = 0;

            if (lines.Length < 12 || lines[index] != SaveVersion)
            {
                Console.WriteLine("Plik ma nieobsługiwaną wersję albo jest niepełny.");
                return false;
            }

            index++;
            string loadedName = lines[index++];
            int loadedHealth = int.Parse(lines[index++]);
            int loadedMaxHealth = int.Parse(lines[index++]);
            int loadedGold = int.Parse(lines[index++]);
            int loadedX = int.Parse(lines[index++]);
            int loadedY = int.Parse(lines[index++]);
            int loadedLevel = int.Parse(lines[index++]);
            int inventoryCount = int.Parse(lines[index++]);

            List<string> loadedInventory = new List<string>();

            for (int i = 0; i < inventoryCount; i++)
            {
                if (index >= lines.Length)
                {
                    Console.WriteLine("Brakuje danych ekwipunku.");
                    return false;
                }

                loadedInventory.Add(lines[index++]);
            }

            int mapHeight = int.Parse(lines[index++]);
            int mapWidth = int.Parse(lines[index++]);

            if (mapHeight <= 0 || mapWidth <= 0 || index + mapHeight > lines.Length)
            {
                Console.WriteLine("Dane mapy są niepełne.");
                return false;
            }

            char[,] loadedMap = new char[mapHeight, mapWidth];

            for (int y = 0; y < mapHeight; y++)
            {
                string row = lines[index++];

                if (row.Length != mapWidth)
                {
                    Console.WriteLine("Jeden z wierszy mapy ma niepoprawną długość.");
                    return false;
                }

                for (int x = 0; x < mapWidth; x++)
                {
                    loadedMap[y, x] = row[x];
                }
            }

            int enemyCount = int.Parse(lines[index++]);

            List<Enemy> loadedEnemies = new List<Enemy>();

            for (int i = 0; i < enemyCount; i++)
            {
                if (index >= lines.Length)
                {
                    Console.WriteLine("Brakuje danych przeciwnika.");
                    return false;
                }

                string[] parts = lines[index++].Split('|');
                int enemyHealth;
                int enemyX;
                int enemyY;

                if (parts.Length != 4 ||
                    !int.TryParse(parts[1], out enemyHealth) ||
                    !int.TryParse(parts[2], out enemyX) ||
                    !int.TryParse(parts[3], out enemyY))
                {
                    Console.WriteLine("Dane przeciwnika są niepoprawne.");
                    return false;
                }

                loadedEnemies.Add(new Enemy(parts[0], enemyHealth, enemyX, enemyY));
            }

            if (loadedX < 0 || loadedX >= mapWidth || loadedY < 0 || loadedY >= mapHeight)
            {
                Console.WriteLine("Pozycja gracza leży poza mapą.");
                return false;
            }

            Player loadedPlayer = new Player(loadedName, loadedX, loadedY);
            loadedPlayer.Health = loadedHealth;
            loadedPlayer.MaxHealth = loadedMaxHealth;
            loadedPlayer.Gold = loadedGold;
            loadedPlayer.Inventory = loadedInventory;

            player = loadedPlayer;
            map = loadedMap;
            enemies = loadedEnemies;
            level = loadedLevel;
            message = "Gra została wczytana.";
            return true;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Nie udało się wczytać gry: {exception.Message}");
            return false;
        }
    }

    private void ShowEndScreen(bool victory)
    {
        Console.Clear();

        if (victory)
        {
            Console.WriteLine("ZWYCIĘSTWO!");
            Console.WriteLine($"{player.Name} opuszcza loch z {player.Gold} sztukami złota.");
        }
        else
        {
            Console.WriteLine("PORAŻKA");
            Console.WriteLine("Bohater poległ w lochu.");
        }

        Console.WriteLine();
        Console.WriteLine("N — nowa gra | M — menu | Q — wyjście");
        ConsoleKey key = Console.ReadKey(true).Key;

        if (key == ConsoleKey.N)
        {
            StartNewGame();
        }
        else if (key == ConsoleKey.Q)
        {
            state = GameState.Exit;
        }
        else
        {
            state = GameState.Menu;
        }
    }

    private void WaitForKey()
    {
        Console.WriteLine();
        Console.WriteLine("Naciśnij dowolny klawisz...");
        Console.ReadKey(true);
    }
}
