using System;

namespace DungeonExplorer
{
    public class Monster : Creature
    {
        public int Damage { get; set; }

        public Monster(string name, int health, int damage) : base(name, health)
        {
            Damage = damage;
        }

        public override void Attack(Creature target)
        {
            Console.WriteLine($"{Name} attacks {target.Name} for {Damage} damage!");
            target.TakeDamage(Damage);
        }
    }

    // Example subclasses for polymorphism
    public class Goblin : Monster
    {
        public Goblin() : base("Goblin", 5, 2) { }
        public override void Attack(Creature target)
        {
            Console.WriteLine($"{Name} sneakily stabs {target.Name} for {Damage} damage!");
            target.TakeDamage(Damage);
        }
    }

    public class Dragon : Monster
    {
        public Dragon() : base("Dragon", 20, 6) { }
        public override void Attack(Creature target)
        {
            Console.WriteLine($"{Name} breathes fire at {target.Name} for {Damage} damage!");
            target.TakeDamage(Damage);
        }
    }
}