using System;
using System.Linq;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private GameMap map;

        public Game()
        {
            player = new Player("Adventurer", 15);
            map = new GameMap();
            currentRoom = map.StartingRoom;
        }

        public void Start()
        {
            Console.WriteLine($"Welcome, {player.Name}!");
            bool playing = true;

            while (playing && player.IsAlive())
            {
                Console.WriteLine($"\nYou are in {currentRoom.Description}.");
                currentRoom.ListContents();

                if (currentRoom.Monsters.Any())
                {
                    var monster = currentRoom.Monsters.First();
                    Console.WriteLine($"{monster.Name} blocks your way!");

                    while (monster.IsAlive() && player.IsAlive())
                    {
                        Console.WriteLine("\nWhat will you do? (attack / use [item] / status / run)");
                        string action = Console.ReadLine().ToLower();

                        if (action == "attack")
                        {
                            player.Attack(monster);
                            if (monster.IsAlive())
                                monster.Attack(player);
                        }
                        else if (action.StartsWith("use "))
                        {
                            string itemName = action.Substring(4);
                            var item = player.Inventory.FindItem(itemName);
                            if (item != null)
                            {
                                item.Use(player);
                                if (item is Potion) player.Inventory.RemoveItem(item);
                            }
                            else
                                Console.WriteLine("You don't have that item.");
                        }
                        else if (action == "status")
                        {
                            Console.WriteLine($"{player.Name} HP: {player.Health}");
                            player.Inventory.ListItems();
                        }
                        else if (action == "run")
                        {
                            Console.WriteLine("You flee back!");
                            // Move player to previous room if possible (not implemented here)
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid command.");
                        }
                    }

                    if (!monster.IsAlive())
                    {
                        Console.WriteLine($"You defeated the {monster.Name}!");
                        currentRoom.Monsters.Remove(monster);
                    }
                    if (!player.IsAlive())
                    {
                        Console.WriteLine("You have been defeated!");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("\nWhat do you want to do?");
                    Console.WriteLine(" - look: See the room description");
                    Console.WriteLine(" - status: Check your health and inventory");
                    Console.WriteLine(" - get [item]: Pick up an item");
                    Console.WriteLine(" - go [direction]: Move to another room");
                    Console.WriteLine(" - quit: Exit the game");

                    string input = Console.ReadLine().ToLower();

                    if (input == "look")
                    {
                        Console.WriteLine(currentRoom.Description);
                        currentRoom.ListContents();
                    }
                    else if (input == "status")
                    {
                        Console.WriteLine($"{player.Name} HP: {player.Health}");
                        player.Inventory.ListItems();
                    }
                    else if (input.StartsWith("get "))
                    {
                        string itemName = input.Substring(4);
                        var item = currentRoom.Items.FirstOrDefault(i => i.Name.ToLower() == itemName.ToLower());
                        if (item != null)
                        {
                            item.Collect(player);
                            currentRoom.Items.Remove(item);
                        }
                        else
                        {
                            Console.WriteLine("No such item here.");
                        }
                    }
                    else if (input.StartsWith("go "))
                    {
                        string dir = input.Substring(3);
                        var nextRoom = currentRoom.GetExit(dir);
                        if (nextRoom != null)
                        {
                            currentRoom = nextRoom;
                        }
                        else
                        {
                            Console.WriteLine("You can't go that way.");
                        }
                    }
                    else if (input == "quit")
                    {
                        playing = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid command.");
                    }
                }
            }
            Console.WriteLine("Game Over. Thanks for playing!");
        }
    }
}