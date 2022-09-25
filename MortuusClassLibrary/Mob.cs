﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortuusClassLibrary
{
    public class Mob : LivingCreature
    {
        public static List<Mob> mobs = SqliteDataAccess.LoadMobs();
        public Mob() : base() { }
        public Mob(int id, string name, string race, string mobClass, int hp, int ac, string weapon, string description, string inventory)
            : base(id, name, race, mobClass, description, hp, ac)
        {
            MobClass = mobClass;               
            Weapon = weapon;
            Inventory = inventory;
        }


        public string MobClass {get; set;}
        public string Weapon {get; set;}
        public string Inventory {get; set;}

        public static List<Mob> MobDisplay()
        {
            foreach (Mob mob in mobs)
            {
                Console.WriteLine(mob.Name);
            }
            return mobs;
        }
    }
}
