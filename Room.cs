using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public class Room
    {
        public string Description { get; set; }
        public List<Item> Items { get; private set; }
        public List<Monster> Monsters { get; private set; }
        public Dictionary<string, Room> Exits { get; private set; }

        public Room(string description)
        {
            Description = description;
            Items = new List<Item>();
            Monsters = new List<Monster>();
            Exits = new Dictionary<string, Room>();
        }

        public void AddExit(string direction, Room room)
        {
            Exits[direction.ToLower()] = room;
        }

        public Room GetExit(string direction)
        {
            Exits.TryGetValue(direction.ToLower(), out Room room);
            return room;
        }

        public void ListContents()
        {
            if (Items.Any())
                System.Console.WriteLine("You see: " + string.Join(", ", Items));
            if (Monsters.Any())
                System.Console.WriteLine("Monsters here: " + string.Join(", ", Monsters.Select(m => m.Name)));
        }
    }
}