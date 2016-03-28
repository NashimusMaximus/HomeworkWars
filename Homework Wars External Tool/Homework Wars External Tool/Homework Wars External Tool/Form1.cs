using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //For converting data to file usable by Homework Wars

namespace Homework_Wars_External_Tool
{
    public partial class HomeworkWarsTool : Form
    {
        //Variables (All initial set to 0/zero to make sure the game knows which values to change
        int characterHealth = 0;
        int characterStr = 0;
        int characterDef = 0;
        string characterSprite = "zero";
        int enemyHealth = 0;
        int enemyStr = 0;
        int enemyDef = 0;
        string enemySprite = "zero";
        Boolean control = false;

        //Create a prompt form for dialogue
        //Created in the prompt class


        public HomeworkWarsTool()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            //Clear the changebox
            ChangeBox.Clear();

            //Check all of the items in the ChangeBox
            //Player Health
            if(PlayerBox.GetItemChecked(0))
            {
                //This code changes the changebox to show the user that they selected change character health.
                ChangeBox.Text = "Selected: Change Character Health.\n";

                //Creates a prompt that will obtain the health, then attempts to parse the value.
                control = false;
                do
                {
                    string change = Prompt.ShowDialog("Change Character Health", "Health Value (Use an integer value greater than zero or zero to cancel): ");
                    if (Int32.TryParse(change, out characterHealth))
                    {
                        if (characterHealth > 0)
                        {
                            ChangeBox.Text += "Character health value changed to " + change + ".\n";
                            control = true;
                        }
                        else if(characterHealth == 0)
                        {
                            ChangeBox.Text += "Change canceled.\n";
                            control = true;
                        }
                    }
                } while (control == false);    

            }
            //Player Strength
            if (PlayerBox.GetItemChecked(1))
            {
                ChangeBox.Text += "Selected: Change Character Strength.\n";

                control = false;
                do
                {
                    string change = Prompt.ShowDialog("Change Character Strength", "Strength Value (Use an integer value greater than zero or zero to cancel): ");
                    if (Int32.TryParse(change, out characterStr))
                    {
                        if (characterStr > 0)
                        {
                            ChangeBox.Text += "Character strength value changed to " + change + ".\n";
                            control = true;
                        }
                        else if (characterStr == 0)
                        {
                            ChangeBox.Text += "Change canceled.\n";
                            control = true;
                        }
                    }
                } while (control == false);

            }
            //Player Defense
            if (PlayerBox.GetItemChecked(2))
            {
                ChangeBox.Text += "Selected: Change Character Defense.\n";

                control = false;
                do
                {
                    string change = Prompt.ShowDialog("Change Character Defense", "Defense Value (Use an integer value greater than zero or zero to cancel): ");
                    if (Int32.TryParse(change, out characterDef))
                    {
                        if (characterDef > 0)
                        {
                            ChangeBox.Text += "Character defense value changed to " + change + ".\n";
                            control = true;
                        }
                        else if (characterDef == 0)
                        {
                            ChangeBox.Text += "Change canceled.\n";
                            control = true;
                        }
                    }
                } while (control == false);

            }
            //Player Sprite
            if (PlayerBox.GetItemChecked(3))
            {
                ChangeBox.Text += "Selected: Change Character Sprite.\n";

                control = false;
                do
                {
                    //Get sprite name then check it for existing sprites
                    string change = Prompt.ShowDialog("Change Character Sprite", "Sprite Name (Enter the exact name of the sprite [Ex. ghost] or the word zero): ");
                    if (change == "player" || change == "wizard")
                    {
                        ChangeBox.Text += "Character Sprite changed to " + change + ".\n";
                        characterSprite = change;
                        control = true;
                    }
                    if (change == "zero")
                    {
                        ChangeBox.Text += "Character Sprite change canceled.\n";
                        characterSprite = change;
                        control = true;
                    }
                } while (control == false);

            }
            //Enemy Health
            if (EnemyBox.GetItemChecked(0))
            {
                ChangeBox.Text += "Selected: Change Enemy Health.\n";

                control = false;
                do
                {
                    string change = Prompt.ShowDialog("Change Enemy Health", "Health Value (Use an integer value greater than zero or zero to cancel): ");
                    if (Int32.TryParse(change, out enemyHealth))
                    {
                        if (enemyHealth > 0)
                        {
                            ChangeBox.Text += "Enemy health value changed to " + change + ".\n";
                            control = true;
                        }
                        else if (enemyHealth == 0)
                        {
                            ChangeBox.Text += "Change canceled.\n";
                            control = true;
                        }
                    }
                } while (control == false);

            }
            //Enemy Stength
            if (EnemyBox.GetItemChecked(1))
            {
                ChangeBox.Text += "Selected: Change Enemy Strength.\n";

                control = false;
                do
                {
                    string change = Prompt.ShowDialog("Change Enemy Strength", "Strength Value (Use an integer value greater than zero or zero to cancel): ");
                    if (Int32.TryParse(change, out enemyStr))
                    {
                        if (enemyStr > 0)
                        {
                            ChangeBox.Text += "Enemy stregnth value changed to " + change + ".\n";
                            control = true;
                        }
                        else if (enemyStr == 0)
                        {
                            ChangeBox.Text += "Change canceled.\n";
                            control = true;
                        }
                    }
                } while (control == false);

            }
            //Enemy Defense
            if (EnemyBox.GetItemChecked(2))
            {
                ChangeBox.Text += "Selected: Change Enemy Defense.\n";

                control = false;
                do
                {
                    string change = Prompt.ShowDialog("Change Enemy Defense", "Defense Value (Use an integer value greater than zero or zero to cancel): ");
                    if (Int32.TryParse(change, out enemyDef))
                    {
                        if (enemyDef > 0)
                        {
                            ChangeBox.Text += "Enemy defense value changed to " + change + ".\n";
                            control = true;
                        }
                        else if (enemyDef == 0)
                        {
                            ChangeBox.Text += "Change canceled.\n";
                            control = true;
                        }
                    }
                } while (control == false);

            }
            //Enemy Sprite
            if (EnemyBox.GetItemChecked(3))
            {
                ChangeBox.Text += "Selected: Change Enemy Sprite.\n";

                control = false;
                do
                {
                    string change = Prompt.ShowDialog("Change Enemy Sprite", "Sprite Name (Enter the exact name of the sprite [Ex. ghost] or the word zero to cancel): ");
                    if (change == "player" || change == "wizard")
                    {
                        ChangeBox.Text += "Enemy Sprite changed to " + change + ".\n";
                        enemySprite = change;
                        control = true;
                    }
                    if (change == "zero")
                    {
                        ChangeBox.Text += "Character Sprite change canceled.\n";
                        characterSprite = change;
                        control = true;
                    }
                } while (control == false);

            }

            //Write to a text file for the game
            Stream file = File.OpenWrite("PlrEnmAttributes.dat");
            BinaryWriter output = new BinaryWriter(file);

            output.Write(characterHealth);  //int32
            output.Write(characterStr);     //int32
            output.Write(characterDef);     //int32
            output.Write(characterSprite);  //string
            output.Write(enemyHealth);      //int32
            output.Write(enemyStr);         //int32
            output.Write(enemyDef);         //int32
            output.Write(enemySprite);      //string

            output.Close();

        }
    }
}
