﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MortuusClassLibrary;

namespace ConsoleUI
{
    public class GameMenuSwitcher
    {
        //public static char userChoice; //where is this coming from? because I think that's why game doesn't continue
        public static int currentLocation = 0; // =Player.player.Location; ???
        
        public static void MainMenu()
        {
            string charName = "Ciara"; //LoadPlayer.PlayerInfo();
            //char userChoice;
            int damage; // = CombatSystem.damage;
            int hp = Player.HP;
            char userChoice;
            
            Console.WriteLine("\nMAIN MENU: \n");
            OptionsMenu.HelpMenu();
            
            do
            {
                Console.Write($"{charName}, enter numeric value from menu to select an option: ");
                userChoice = Console.ReadLine()[0];
                Console.WriteLine("\n");
                Room thisRoom = Room.rooms[currentLocation];

                Console.WriteLine($"You are in {thisRoom.Name} ( {thisRoom.IdNumber} )");
                Console.WriteLine(thisRoom.Description);
                Console.WriteLine($"Your exits are {thisRoom.Exits}"); 
                //userChoice = Console.ReadLine()[0];

                switch (userChoice)
                {
                    case '1':
                        currentLocation = MovePlayer.MoveNorth(ref currentLocation);
                        if (currentLocation > Room.rooms.Count - 1)
                        {
                            Console.WriteLine("Please stop banging your head on the dungeon wall. " +
                                "You must turn around and go back because this is the end.");
                        }
                        break;
                    case '2':
                        currentLocation = MovePlayer.MoveSouth(ref currentLocation);
                        if (currentLocation <= 0)
                        {
                            Console.WriteLine("You'll stay here until you move in another direction.");
                        }
                        break;
                    case '3':
                        currentLocation = MovePlayer.MoveEast(ref currentLocation);
                        if (currentLocation <= 0)
                        {
                            Console.WriteLine("You'll stay here until you move in another direction.");
                        }
                        break;
                    case '4':
                        currentLocation = MovePlayer.MoveWest(ref currentLocation);
                        if (currentLocation <= 0)
                        {
                            Console.WriteLine("You'll stay here until you move in another direction.");
                        }
                        break;
                    case '5':
                        // TODO Move entire to combat Class method and then just call method here
                        if (hp >= 1)
                        {
                            Console.WriteLine("You are in a fight!");
                            //Console.WriteLine("Enter action: (a) for attack or any other key to exit.");
                            damage = CombatSystem.AttackPoints();
                            Console.WriteLine($"You've taken {damage} points of damage");
                            hp = CombatSystem.CalcHealth(ref hp, damage);
                            Console.WriteLine($"Your hp is at {hp}\n");
                        }
                        else
                        {
                            Console.WriteLine("You are dead.");
                        }
                        break;
                    case '6':
                        OptionsMenu.Exit();
                        break;
                    case '7':
                        OptionsMenu.WriteExploreMenu();
                        //Console.WriteLine("Menu");
                        char menuOption = Console.ReadLine()[0];
                        OptionsMenu.ExploreMenu(menuOption);
                        break;
                    default:
                        Console.WriteLine("Not a valid option. Maybe check your case and spelling?");
                        break;
                }
            }
            while (userChoice != '6');
            Console.Write("Press enter to exit...");
            // Program ends
            Console.ReadLine();
        }
    }
}
