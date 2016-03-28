//The base class for all entity types. Contains health, name, and description types.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
/// <summary>
/// Zach Darrow | Caleb Fraser | Matt Cooley | Nash Lyke
/// Parent class of Enemy and Player
/// 
/// </summary>

namespace GUI
{
    class Entity
    {
        //Notes for external tool: want the tool to be able to change health, damage, and sprite of enemies.
        //Variables
        private int health;
        private string name;
        private string description;

        //Constructor
        public Entity(int hp, string nm, string desc)
        {
            health = hp;
            name = nm;
            description = desc;
        }

        //properties
        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
