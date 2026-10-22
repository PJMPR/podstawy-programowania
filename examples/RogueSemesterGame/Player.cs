class Player
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int Gold { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public List<string> Inventory { get; set; }

    public Player(string name, int x, int y)
    {
        Name = name;
        MaxHealth = 30;
        Health = MaxHealth;
        Gold = 0;
        X = x;
        Y = y;
        Inventory = new List<string>();
        Inventory.Add("Mikstura");
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health < 0)
        {
            Health = 0;
        }
    }

    public bool UsePotion()
    {
        int potionIndex = Inventory.IndexOf("Mikstura");

        if (potionIndex == -1 || Health == MaxHealth)
        {
            return false;
        }

        Inventory.RemoveAt(potionIndex);
        Health += 10;

        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }

        return true;
    }
}
