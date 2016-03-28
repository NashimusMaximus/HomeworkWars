//Class for all character types (at the moment, only one is planned).
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
/// <summary>
/// Zach Darrow | Caleb Fraser | Matt Cooley | Nash Lyke
/// Player child class
/// 
/// </summary>

namespace GUI
{
    class Character:Entity
    {
        //Variables
        private int strength;
        private int defense;

        //Constructor
        public Character(int hp, string nm, string desc, int str, int def):base(hp, nm, desc)
        {
            strength = str;
            defense = def;
        }

        //properties
        public int Strength
        {
            get { return strength; }
            set { strength = value; }
        }

        public int Defense
        {
            get { return defense; }
            set { defense = value; }
        }
    }
}
