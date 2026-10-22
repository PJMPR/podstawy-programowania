class Enemy
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public Enemy(string name, int health, int x, int y)
    {
        Name = name;
        Health = health;
        X = x;
        Y = y;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health < 0)
        {
            Health = 0;
        }
    }
}
