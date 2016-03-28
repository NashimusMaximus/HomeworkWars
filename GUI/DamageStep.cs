using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
/// <summary>
/// Zach Darrow | Caleb Fraser | Matt Cooley | Nash Lyke
/// Damage Class - contains methods for attack styles
/// </summary>

namespace GUI
{
    class DamageStep
    {
        //attributes
        private string playerType;
        private string enemyType;
        private int playerTypeStr;
        private int enemyTypeStr;
        private int DamageEnemy;
        private int DamagePlayer;
        private double Critical = 1.0;
        private double powerUp = 1.0;
        private double MatchUpUser;
        private double MatchUpEnemy;
        private Random rgen = new Random();

        public DamageStep ( )
        {

        }

        //returns damage done by the enemy
        public int ReturnDamageEnemy(Character pl, Enemy en, string plAtkType, string enAtkType)
        {
            playerType = plAtkType;
            enemyType = enAtkType;

            if (playerType == "Q")
            {
                if (enemyType == "Q")
                {
                    playerTypeStr = 85;
                    enemyTypeStr = 85;
                    MatchUpUser = 1.0;
                    MatchUpEnemy = 1.0;
                }
                if (enemyType == "G")
                {
                    playerTypeStr = 85;
                    enemyTypeStr = 100;
                    MatchUpUser = 0.1;
                    MatchUpEnemy = 1.0;
                }
                if (enemyType == "P")
                {
                    playerTypeStr = 85;
                    enemyTypeStr = 150;
                    MatchUpUser = 1.1;
                    MatchUpEnemy = 0;
                }
            }

            if (playerType == "G")
            {

                if (enemyType == "Q")
                {
                    playerTypeStr = 100;
                    enemyTypeStr = 85;
                    MatchUpUser = 1.0;
                    MatchUpEnemy = 0.1;
                }
                if (enemyType == "G")
                {
                    playerTypeStr = 100;
                    enemyTypeStr = 100;
                    MatchUpUser = 0;
                    MatchUpEnemy = 0;
                }
                if (enemyType == "P")
                {
                    playerTypeStr = 100;
                    enemyTypeStr = 150;
                    MatchUpUser = 0;
                    MatchUpEnemy = 0.8;
                }
            }

            if (playerType == "P")
            {
                if (enemyType == "Q")
                {
                    playerTypeStr = 150;
                    enemyTypeStr = 85;
                    MatchUpUser = 0;
                    MatchUpEnemy = 1.1;
                }
                if (enemyType == "G")
                {
                    playerTypeStr = 150;
                    enemyTypeStr = 100;
                    MatchUpUser = 0.8;
                    MatchUpEnemy = 0;
                }
                if (enemyType == "P")
                {
                    playerTypeStr = 150;
                    enemyTypeStr = 150;
                    MatchUpUser = 1.1;
                    MatchUpEnemy = 1.1;
                }
            }
            DamageEnemy = (int)(((pl.Strength / en.EneDefense) * playerTypeStr + 2) * (Critical * (rgen.Next(85, 100)) / 100) * powerUp * MatchUpUser);
            return DamageEnemy;
        }

        //returns the damage done by the player
        public int ReturnDamagePlayer(Character pl, Enemy en, string plAtkType, string enAtkType)
        {
            playerType = plAtkType;
            enemyType = enAtkType;

            if (playerType == "Q")
            {
                if (enemyType == "Q")
                {
                    playerTypeStr = 85;
                    enemyTypeStr = 85;
                    MatchUpUser = 1.0;
                    MatchUpEnemy = 1.0;
                }
                if (enemyType == "G")
                {
                    playerTypeStr = 85;
                    enemyTypeStr = 100;
                    MatchUpUser = 0.1;
                    MatchUpEnemy = 1.0;
                }
                if (enemyType == "P")
                {
                    playerTypeStr = 85;
                    enemyTypeStr = 150;
                    MatchUpUser = 1.1;
                    MatchUpEnemy = 0;
                }
            }

            if (playerType == "G")
            {

                if (enemyType == "Q")
                {
                    playerTypeStr = 100;
                    enemyTypeStr = 85;
                    MatchUpUser = 1.0;
                    MatchUpEnemy = 0.1;
                }
                if (enemyType == "G")
                {
                    playerTypeStr = 100;
                    enemyTypeStr = 100;
                    MatchUpUser = 0;
                    MatchUpEnemy = 0;
                }
                if (enemyType == "P")
                {
                    playerTypeStr = 100;
                    enemyTypeStr = 150;
                    MatchUpUser = 0;
                    MatchUpEnemy = 0.8;
                }
            }

            if (playerType == "P")
            {
                if (enemyType == "Q")
                {
                    playerTypeStr = 150;
                    enemyTypeStr = 85;
                    MatchUpUser = 0;
                    MatchUpEnemy = 1.1;
                }
                if (enemyType == "G")
                {
                    playerTypeStr = 150;
                    enemyTypeStr = 100;
                    MatchUpUser = 0.8;
                    MatchUpEnemy = 0;
                }
                if (enemyType == "P")
                {
                    playerTypeStr = 150;
                    enemyTypeStr = 150;
                    MatchUpUser = 1.1;
                    MatchUpEnemy = 1.1;
                }
            }
            DamagePlayer = (int)(((en.EneStrength / pl.Defense) * enemyTypeStr + 2) * (Critical * (rgen.Next(85, 100)) / 100) * powerUp * MatchUpEnemy);
            return DamagePlayer;
        }
    }
}
