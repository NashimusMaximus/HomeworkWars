//Class for all enemy types.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
/// <summary>
/// Zach Darrow | Caleb Fraser | Matt Cooley | Nash Lyke
/// Enemy Child Class
/// </summary>

namespace GUI
{
    class Enemy:Entity
    {
        //Variables
        private int eneStrength;
        private int eneDefense;

        //Constructor
        public Enemy(int hp, string nm, string desc, int str, int def):base(hp, nm, desc)
        {
            eneStrength = str;
            eneDefense = def;
        }

        //properties
        public int EneStrength
        {
            get { return eneStrength; }
            set { eneStrength = value; }
        }

        public int EneDefense
        {
            get { return eneDefense; }
            set { eneDefense = value; }
        }
    }
}
