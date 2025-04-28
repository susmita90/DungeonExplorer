using System.Collections.Generic;

namespace DungeonExplorer
{
    public class GameMap
    {
        public Room StartingRoom { get; private set; }
        private List<Room> rooms = new List<Room>();
        public GameMap()
        {
            // Build rooms and connect them
            var room1 = new Room("a dimly lit chamber");
            var room2 = new Room("a dark hallway");
            var room3 = new Room("a treasure vault");
            var room4 = new Room("the dragon's lair");

            room1.AddExit("north", room2);
            room2.AddExit("south", room1);
            room2.AddExit("east", room3);
            room3.AddExit("west", room2);
            room3.AddExit("north", room4);
            room4.AddExit("south", room3);

            // Add items and monsters
            room1.Items.Add(new Weapon("Rusty Sword", 3));
            room2.Monsters.Add(new Goblin());
            room3.Items.Add(new Potion("Healing Potion", 5));
            room4.Monsters.Add(new Dragon());

            rooms.AddRange(new[] { room1, room2, room3, room4 });
            StartingRoom = room1;
        }
    }
}