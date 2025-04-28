using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public class Inventory
    {
        public List<Item> Items { get; private set; }
        public Inventory() { Items = new List<Item>(); }

        public void AddItem(Item item) => Items.Add(item);

        public void RemoveItem(Item item) => Items.Remove(item);

        public void ListItems()
        {
            if (!Items.Any())
                Console.WriteLine("Inventory is empty.");
            else
                Items.ForEach(i => Console.WriteLine(i));
        }

        public Item FindItem(string name)
        {
            return Items.FirstOrDefault(i => i.Name.ToLower() == name.ToLower());
        }
    }
}