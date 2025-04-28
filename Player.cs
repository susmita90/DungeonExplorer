using System;
using System.Linq;

namespace DungeonExplorer
{
    public class Player : Creature
    {
        public Inventory Inventory { get; private set; }

        public Player(string name, int health) : base(name, health)
        {
            Inventory = new Inventory();
        }

        public override void Attack(Creature target)
        {
            // Use best weapon if available, else punch (1 damage)
            var weapon = Inventory.Items.OfType<Weapon>().OrderByDescending(w => w.Damage).FirstOrDefault();
            int damage = weapon != null ? weapon.Damage : 1;
            Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage!");
            target.TakeDamage(damage);
        }
    }
}