using System;

namespace DungeonExplorer
{
    public abstract class Item : ICollectible
    {
        public string Name { get; set; }
        public Item(string name) { Name = name; }
        public abstract void Use(Player player);
        public virtual void Collect(Player player)
        {
            player.Inventory.AddItem(this);
            Console.WriteLine($"{player.Name} picked up {Name}.");
        }
        public override string ToString() => Name;
    }

    public class Weapon : Item
    {
        public int Damage { get; set; }
        public Weapon(string name, int damage) : base(name) { Damage = damage; }
        public override void Use(Player player)
        {
            Console.WriteLine($"{player.Name} wields {Name} (Damage: {Damage}).");
        }
        public override string ToString() => $"{Name} (Weapon, Damage: {Damage})";
    }

    public class Potion : Item
    {
        public int HealAmount { get; set; }
        public Potion(string name, int healAmount) : base(name) { HealAmount = healAmount; }
        public override void Use(Player player)
        {
            player.Health += HealAmount;
            Console.WriteLine($"{player.Name} uses {Name} and heals {HealAmount} HP!");
        }
        public override string ToString() => $"{Name} (Potion, Heal: {HealAmount})";
    }
}