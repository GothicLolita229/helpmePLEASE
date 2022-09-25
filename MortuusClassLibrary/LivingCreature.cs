﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortuusClassLibrary
{
    public abstract class LivingCreature
    {

        public LivingCreature() { }
        public LivingCreature(int id, string name, string race, string lcclass, string description, int hp, int ac)
        {
            ID = id;
            Name = name;
            Race = race;
            LcClass = lcclass;
            Description = description;
            HP = hp;
            AC = ac;
        }

        public int ID{ get; set; }
        public string Name { get; set; }
        public string Race { get; set;}
        public string LcClass { get; set; }
        public string Description { get; set; }
        public static int HP { get; set; }
        public int AC { get; set; }
    }
}
