using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
/// <summary>
/// T3AM - Zach Darrow | Caleb Fraser | Matt Cooley | Nash Lyke
/// GUI Game Class
/// Caveats: Game Textures are still blurry | External Tool/File.IO doesn't run correctly - elaborated on in the constructor
/// Inventory Button in In Game Menu is bugged, placed to the side
/// Character Selection, Inventory, and Power-Ups still work in progress
/// Free Roaming is still a work in progress
/// </summary>
namespace GUI
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        string[] files; //array to hold file names
        BinaryReader input; //binary reader stream

        int eDef;   //player/enemy attributes
        int eHlth;
        int eStr;
        int pDef;
        int pHlth;
        int pStr;
        string eSprite;
        string pSprite;

        Character c1;
        Enemy e1;
        Random rgen = new Random();
        DamageStep ds = new DamageStep();
        int PlayerDamage;
        int EnemyDamage;
        string UserAttack; //Either Q,G, or P
        int Time = 0;
        int EnemyAction;


        //attributes for player and enemy
        Texture2D playerText, enemyText;
        SpriteFont font;

        //attributes for main menu
        Texture2D box, exitButton, playButton, optionsButton;
        Rectangle boxRect, exitRect, playRect, optsRect;

        //attributes for options
        Texture2D optsBackButton;
        Rectangle optsBackRect;

        //attributes for in game menu
        Texture2D inGameMenuBox, resumeButton, inventoryButton, characterButton, igmExitButton;
        Rectangle igmbRect, resumeRect, inventoryRect, charRect, igmExitRect;

        //attributes for character selection
        Texture2D characterBox, characterMenuBox, selectButton1, backButton1;
        Rectangle charBoxRect, charMenuRect, selectRect1, backRect1;

        //attributes for inventory
        Texture2D invenMenu, backButton2, selectButton2, waterBox, sodaBox, burgerBox, steakBox, candyBox, coffeeBox, espressoBox, energyBox, bookBox, notesBox, tutorBox;
        Rectangle invenMenuRect, backRect2, selectRect2, waterRect, sodaRect, burgerRect, steakRect, candyRect, coffeeRect, espressoRect, energyRect, bookRect, notesRect, tutorRect;

        //attributes for combat selection screen
        Texture2D attackButton, powButton, combatPlayButton;
        Rectangle attackRect, powRect, combatPlayRect;
        Texture2D quickButton, quickSelection, guardButton, guardSelection, powerButton, powerSelection;
        Rectangle quickRect, quickSelRect, guardRect, guardSelRect, powerRect, powerSelRect;
        Texture2D backButton3;
        Rectangle backRect3;

        //attributes for game over
        Texture2D gameOver, goExitButton;
        Rectangle gameOverRect, goExitRect;

        //game states
        enum GameState { MainMenu, Game, Options, InGameMenu, CharacterSelection, Inventory, Combat, CombatSelection, GameOver};
        GameState gameState;

        //combat selection states
        enum CombatSelectionState { Null, AttackSelection, PowerUpSelection};
        CombatSelectionState combatSelectionState;

        //attack selection states
        enum AttackSelection { Null, Quick, Power, Guard};
        AttackSelection attackSelection;

        //player/enemy states
        enum EntityState { Idle, Attack};
        EntityState entityState;

        public Game1()  //CONSTRUCTOR
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            /*
            files = Directory.GetFiles("Homework Wars External Tool - Copy/Homework Wars External Tool/Homework Wars External Tool/bin/Debug", "Plr*");
            foreach(string file in files)
            {
                input = new BinaryReader(File.OpenRead(file));

                pHlth = input.ReadInt32();
                pStr = input.ReadInt32();
                pDef = input.ReadInt32();
                pSprite = input.ReadString();
                eHlth = input.ReadInt32();
                eStr = input.ReadInt32();
                eDef = input.ReadInt32();
                eSprite = input.ReadString();
                input.Close();              
            }
            */
            
            c1 = new Character(1000, "Ethan Bradbury", "Character", 22, 8);     //these objects will be made withthe information from the attributee external editor
            e1 = new Enemy(1000, "Ronald McDonald", "Enemy", 32, 4);            //We need to find out how to find the exact directory to make the GetFiles method working.

        }

        //button pressed method
        //determines whether mouse presses a button
        public bool ButtonPressed(Rectangle rect)
        {
            //get the mouse state
            MouseState mstate = Mouse.GetState();

            if(rect.Contains(mstate.Position))  //if rectangle contains the mouse
            {
                if(mstate.LeftButton == ButtonState.Pressed)  //if button is pressed
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //key pressed method
        //determines whether a key is pressed
        public bool KeyPressed(Keys ky)
        {
            KeyboardState kbState = Keyboard.GetState();

            if(kbState.IsKeyDown(ky) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            gameState = GameState.MainMenu;  //initial gamestae is the main menu
            combatSelectionState = CombatSelectionState.Null;
            attackSelection = AttackSelection.Null;
            entityState = EntityState.Idle;

            IsMouseVisible = true;  //mouse is visible

            //main menu
            boxRect = new Rectangle((GraphicsDevice.Viewport.Width/2) - 150, (GraphicsDevice.Viewport.Height/ 2) - 200, 300, 350);  //position of menu box
            playRect = new Rectangle(275, 40, 250, 150);  //position of play button
            optsRect = new Rectangle(275, 130, 250, 150);  //position of options button
            exitRect = new Rectangle(275, 220, 250, 150);  //position of exit button

            //options
            optsBackRect = new Rectangle(275, 215, 250, 100);

            //in game menu
            igmbRect = new Rectangle((GraphicsDevice.Viewport.Width / 2) - 150, (GraphicsDevice.Viewport.Height / 2) - 200, 300, 400);  //position of menu box
            resumeRect = new Rectangle(275, 55, 250, 100);  //position of resume button
            charRect = new Rectangle(275, 135, 250, 100);  //position of character button
            inventoryRect = new Rectangle(550, 215, 250, 100);  //position of inventory button
            igmExitRect = new Rectangle(275, 295, 250, 150);  //position of exit button

            //character selection
            charMenuRect = new Rectangle((GraphicsDevice.Viewport.Width / 2) - 150, (GraphicsDevice.Viewport.Height / 2) - 200, 300, 300);  //position of menu
            backRect1 = new Rectangle(275, 225, 250, 100);  //position of back button

            //inventory
            invenMenuRect = new Rectangle((GraphicsDevice.Viewport.Width / 2) - 335, (GraphicsDevice.Viewport.Height / 2) - 160, 670, 320);  //position of menu
            backRect2 = new Rectangle(275, 225, 250, 100);
            //selectRect1 = new Rectangle(135, 290, 250, 100);

            //combat selection
            attackRect = new Rectangle(15, 365, 250, 100);
            powRect = new Rectangle(275, 365, 250, 100);
            combatPlayRect = new Rectangle(535, 365, 250, 150);

            //attack selction
            quickRect = new Rectangle(15, 300, 250, 100);
            guardRect = new Rectangle(275, 300, 250, 100);
            powerRect = new Rectangle(535, 300, 250, 100);
            quickSelRect = new Rectangle(25, 410, 238, 110);
            guardSelRect = new Rectangle(25, 410, 238, 110);
            powerSelRect = new Rectangle(25, 410, 238, 110);

            //power-up selection
            backRect3 = new Rectangle(15, 300, 250, 100);

            //game over
            gameOverRect = new Rectangle(205, 75, 350, 200);
            goExitRect = new Rectangle(275, 205, 250, 150);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //player and enemy
            playerText = Content.Load<Texture2D>("Player");
            enemyText = Content.Load<Texture2D>("Enemy");
            font = Content.Load<SpriteFont>("Font1");

            //main menu
            box = Content.Load<Texture2D>("Character Box");
            playButton = Content.Load<Texture2D>("Play Button");
            optionsButton = Content.Load<Texture2D>("Options Button");
            exitButton = Content.Load<Texture2D>("Exit Button");

            //options
            optsBackButton = Content.Load<Texture2D>("Back Button");

            //in game menu
            inGameMenuBox = Content.Load<Texture2D>("Character Box");
            resumeButton = Content.Load<Texture2D>("Resume Button");
            inventoryButton = Content.Load<Texture2D>("Inventory Button");
            characterButton = Content.Load<Texture2D>("Character Button");
            igmExitButton = Content.Load<Texture2D>("Exit Button");

            //character selection
            characterMenuBox = Content.Load<Texture2D>("Character Box");
            backButton1 = Content.Load<Texture2D>("Back Button");

            //inventory
            invenMenu = Content.Load<Texture2D>("Character Box");
            backButton2 = Content.Load<Texture2D>("Back Button");
            selectButton2 = Content.Load<Texture2D>("Un-pressed Select Button");

            //combat selection
            attackButton = Content.Load<Texture2D>("Attack Button");
            powButton = Content.Load<Texture2D>("Power Up Button");
            combatPlayButton = Content.Load<Texture2D>("Play Button");

            //attack selection
            guardButton = Content.Load<Texture2D>("Guard Button");
            quickButton = Content.Load<Texture2D>("Quick Button");
            powerButton = Content.Load<Texture2D>("Power Button");
            quickSelection = Content.Load<Texture2D>("Quick Selection");
            guardSelection = Content.Load<Texture2D>("Guard Selection");
            powerSelection = Content.Load<Texture2D>("Power Selection");

            //power-up selection
            backButton3 = Content.Load<Texture2D>("Back Button");

            //game over
            gameOver = Content.Load<Texture2D>("Game Over");
            goExitButton = Content.Load<Texture2D>("Exit Button");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //MAIN MENU
            if(gameState == GameState.MainMenu)
            {
                if (ButtonPressed(playRect) == true)  //is play is pressed
                {
                    gameState = GameState.Game;
                }

                if (ButtonPressed(optsRect) == true)  //if options is pressed
                {
                    gameState = GameState.Options;
                }

                if (ButtonPressed(exitRect) == true)  //if exit is pressed
                {
                    Exit();
                }
            }

            //GAME
            if(gameState == GameState.Game)
            {
                if(KeyPressed(Keys.Q) == true)  //if Q key is pressed
                {
                    gameState = GameState.InGameMenu;
                }

                if (KeyPressed(Keys.E) == true)  //if Q key is pressed
                {
                    gameState = GameState.CombatSelection;
                }
            }

            //OPTIONS
            if(gameState == GameState.Options)
            {
                if(ButtonPressed(optsBackRect) == true)
                {
                    gameState = GameState.MainMenu;
                }
            }

            //IN GAME MENU
            if(gameState == GameState.InGameMenu)
            {
                if(ButtonPressed(resumeRect) == true)  //if resume is pressed
                {
                    gameState = GameState.Game;
                }

                if(ButtonPressed(charRect) == true)  //if character is pressed
                {
                    gameState = GameState.CharacterSelection;
                }

                if(ButtonPressed(inventoryRect) == true)  //if inventory is pressed
                {
                    gameState = GameState.Inventory;
                }

                if(ButtonPressed(igmExitRect) == true) //if exit is pressed
                {
                    Exit();
                }
            }

            //CHARACTER SELECTION
            if (gameState == GameState.CharacterSelection)
            {
                if(ButtonPressed(backRect1) == true)  //if back button is pressed
                {
                    gameState = GameState.InGameMenu;
                }
            }


            //INVENTORY
            if (gameState == GameState.Inventory)
            {
                if (ButtonPressed(backRect2) == true)  //if back button is pressed
                {
                    gameState = GameState.InGameMenu;
                }
            }

            //COMBAT SELECTION
            if (gameState == GameState.CombatSelection)
            {
                if (ButtonPressed(attackRect) == true)  //if attack button is pressed
                {
                    combatSelectionState = CombatSelectionState.AttackSelection;
                }

                if (ButtonPressed(powRect) == true)  //if power-up button is pressed
                {
                    combatSelectionState = CombatSelectionState.PowerUpSelection;
                }

                if(ButtonPressed(combatPlayRect) == true)
                {
                    gameState = GameState.Combat;
                }

                //reset damage numbers
                PlayerDamage = 0;
                EnemyDamage = 0;

                //game over initiate
                if (c1.Health <= 0 || e1.Health <= 0)
                {
                    gameState = GameState.GameOver;
                }
            }

            //ATTACK SELECTION
            if(combatSelectionState == CombatSelectionState.AttackSelection)
            {
                if (ButtonPressed(quickRect) == true)  //if quick button is pressed
                {
                    combatSelectionState = CombatSelectionState.Null;
                    attackSelection = AttackSelection.Quick;
                    UserAttack = "Q";
                }

                if (ButtonPressed(guardRect) == true)  //if guard button is pressed
                {
                    combatSelectionState = CombatSelectionState.Null;
                    attackSelection = AttackSelection.Guard;
                    UserAttack = "G";
                }

                if (ButtonPressed(powerRect) == true)  //if power button is pressed
                {
                    combatSelectionState = CombatSelectionState.Null;
                    attackSelection = AttackSelection.Power;
                    UserAttack = "P";
                }
            }

            //POWER-UP SELECTION
            if (combatSelectionState == CombatSelectionState.PowerUpSelection)
            {
                if (ButtonPressed(backRect3) == true)  //if back button is pressed
                {
                    combatSelectionState = CombatSelectionState.Null;
                }
            }

            //COMBAT
            if (gameState == GameState.Combat)
            {
                if(Time == 0)
                {
                    EnemyAction = rgen.Next(1, 4);
                }

                if(Time == 180)
                {

                    if (EnemyAction == 1)
                    {
                        PlayerDamage = ds.ReturnDamagePlayer(c1, e1, UserAttack, "Q");
                        EnemyDamage = ds.ReturnDamageEnemy(c1, e1, UserAttack, "Q");
                        c1.Health = c1.Health - PlayerDamage;
                        e1.Health = e1.Health - EnemyDamage;
                    }

                    if (EnemyAction == 2)
                    {
                        PlayerDamage = ds.ReturnDamagePlayer(c1, e1, UserAttack, "G");
                        EnemyDamage = ds.ReturnDamageEnemy(c1, e1, UserAttack, "G");
                        c1.Health = c1.Health - PlayerDamage;
                        e1.Health = e1.Health - EnemyDamage;
                    }

                    if (EnemyAction == 3)
                    {
                        PlayerDamage = ds.ReturnDamagePlayer(c1, e1, UserAttack, "P");
                        EnemyDamage = ds.ReturnDamageEnemy(c1, e1, UserAttack, "P");
                        c1.Health = c1.Health - PlayerDamage;
                        e1.Health = e1.Health - EnemyDamage;
                    }
                }

                //timer
                Time++;

                //after 5 seconds
                if(Time >= 180)
                {
                    entityState = EntityState.Attack;
                }

                //after 10 seconds
                if (Time >= 360 || KeyPressed(Keys.Enter) == true)
                {
                    gameState = GameState.CombatSelection;
                    Time = 0;
                    entityState = EntityState.Idle;
                }
            }

            //GAMEOVER
            if (gameState == GameState.GameOver)
            {
                if(ButtonPressed(goExitRect) == true)
                {
                    Exit();
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            //MAIN MENU
            if(gameState == GameState.MainMenu)
            {
                spriteBatch.Draw(box, boxRect, Color.White);
                spriteBatch.Draw(playButton, playRect, Color.White);
                spriteBatch.Draw(optionsButton, optsRect, Color.White);
                spriteBatch.Draw(exitButton, exitRect, Color.White);
            }

            //OPTIONS
            if(gameState == GameState.Options)
            {
                spriteBatch.Draw(box, boxRect, Color.White);
                spriteBatch.Draw(optsBackButton, optsBackRect, Color.White);
            }

            //GAME
            if(gameState == GameState.Game)
            {
                spriteBatch.DrawString(font, "WORK IN PROGRESS", new Vector2(305, 50), Color.White);
                spriteBatch.DrawString(font, "Press E to enter battle phase", new Vector2(305, 70), Color.White);
            }

            //IN GAME MENU
            if (gameState == GameState.InGameMenu)
            {
                spriteBatch.Draw(inGameMenuBox, igmbRect, Color.White);
                spriteBatch.Draw(resumeButton, resumeRect, Color.White);
                spriteBatch.Draw(inventoryButton, inventoryRect, Color.White);
                spriteBatch.Draw(characterButton, charRect, Color.White);
                spriteBatch.Draw(igmExitButton, igmExitRect, Color.White);
            }

            //CHARACTER SELECTION
            if (gameState == GameState.CharacterSelection)
            {
                spriteBatch.Draw(characterMenuBox, charMenuRect, Color.White);
                spriteBatch.Draw(backButton1, backRect1, Color.White);
            }


            //INVENTORY
            if (gameState == GameState.Inventory)
            {
                spriteBatch.Draw(invenMenu, invenMenuRect, Color.White);
                spriteBatch.Draw(backButton2, backRect2, Color.White);
                //spriteBatch.Draw(selectButton2, selectRect2, Color.White);
            }

            //COMBAT SELECTION
            if (gameState == GameState.CombatSelection)
            {
                spriteBatch.Draw(attackButton, attackRect, Color.White);
                spriteBatch.Draw(powButton, powRect, Color.White);
                spriteBatch.Draw(combatPlayButton, combatPlayRect, Color.White);

                //player
                spriteBatch.DrawString(font, c1.Name, new Vector2(450, 65), Color.White);
                spriteBatch.Draw(playerText, new Rectangle(450, 90, 200, 200), new Rectangle(0, 0, 200, 200), Color.White);
                spriteBatch.DrawString(font, "Health: " + c1.Health, new Vector2(450, 300), Color.White);

                //enemy
                spriteBatch.DrawString(font, e1.Name, new Vector2(150, 65), Color.White);
                spriteBatch.Draw(enemyText, new Rectangle(150, 90, 200, 200), new Rectangle(0, 0, 200, 200), Color.White);
                spriteBatch.DrawString(font, "Health: " + e1.Health, new Vector2(150, 300), Color.White);

                if (combatSelectionState == CombatSelectionState.Null)
                {

                }

                if(attackSelection == AttackSelection.Null)
                {

                }

                if (attackSelection == AttackSelection.Quick)
                {
                    spriteBatch.Draw(quickSelection, quickSelRect, Color.White);
                }

                if (attackSelection == AttackSelection.Guard)
                {
                    spriteBatch.Draw(guardSelection, guardSelRect, Color.White);
                }

                if (attackSelection == AttackSelection.Power)
                {
                    spriteBatch.Draw(powerSelection, powerSelRect, Color.White);
                }

                if (combatSelectionState == CombatSelectionState.AttackSelection)
                {
                    spriteBatch.Draw(quickButton, quickRect, Color.White);
                    spriteBatch.Draw(guardButton, guardRect, Color.White);
                    spriteBatch.Draw(powerButton, powerRect, Color.White);
                }

                if (combatSelectionState == CombatSelectionState.PowerUpSelection)
                {
                    spriteBatch.Draw(backButton3, backRect3, Color.White);
                }
            }

            //COMBAT
            if (gameState == GameState.Combat)
            {
                //idle
                if(entityState == EntityState.Idle)
                {
                    //player
                    spriteBatch.DrawString(font, c1.Name, new Vector2(450, 65), Color.White);
                    spriteBatch.Draw(playerText, new Rectangle(450, 90, 200, 200), new Rectangle(0, 0, 200, 200), Color.White);
                    spriteBatch.DrawString(font, "Health: " + c1.Health, new Vector2(450, 300), Color.White);
                    if(UserAttack == "Q")
                    {
                        spriteBatch.DrawString(font, "Attack Type: Quick", new Vector2(450, 320), Color.White);
                    }
                    if (UserAttack == "G")
                    {
                        spriteBatch.DrawString(font, "Attack Type: Guard", new Vector2(450, 320), Color.White);
                    }
                    if (UserAttack == "P")
                    {
                        spriteBatch.DrawString(font, "Attack Type: Power", new Vector2(450, 320), Color.White);
                    }

                    //enemy
                    spriteBatch.DrawString(font, e1.Name, new Vector2(150, 65), Color.White);
                    spriteBatch.Draw(enemyText, new Rectangle(150, 90, 200, 200), new Rectangle(0, 0, 200, 200), Color.White);
                    spriteBatch.DrawString(font, "Health: " + e1.Health, new Vector2(150, 300), Color.White);
                    if (EnemyAction == 1)
                    {
                        spriteBatch.DrawString(font, "Attack Type: Quick", new Vector2(150, 320), Color.White);
                    }
                    if (EnemyAction == 2)
                    {
                        spriteBatch.DrawString(font, "Attack Type: Guard", new Vector2(150, 320), Color.White);
                    }
                    if (EnemyAction == 3)
                    {
                        spriteBatch.DrawString(font, "Attack Type: Power", new Vector2(150, 320), Color.White);
                    }
                }

                //attacking
                if (entityState == EntityState.Attack)
                {
                    //player
                    spriteBatch.DrawString(font, c1.Name, new Vector2(450, 65), Color.White);
                    spriteBatch.Draw(playerText, new Rectangle(450, 90, 200, 200), new Rectangle(200, 0, 200, 200), Color.White);
                    spriteBatch.DrawString(font, "Health: " + c1.Health, new Vector2(450, 300), Color.White);
                    spriteBatch.DrawString(font, "Damage Taken: " + PlayerDamage, new Vector2(450, 320), Color.White);

                    //enemy
                    spriteBatch.DrawString(font, e1.Name, new Vector2(150, 65), Color.White);
                    spriteBatch.Draw(enemyText, new Rectangle(150, 90, 200, 200), new Rectangle(200, 0, 200, 200), Color.White);
                    spriteBatch.DrawString(font, "Health: " + e1.Health, new Vector2(150, 300), Color.White);
                    spriteBatch.DrawString(font, "Damage Taken: " + EnemyDamage, new Vector2(150, 320), Color.White);
                }
            }

            //GAMEOVER
            if (gameState == GameState.GameOver)
            {
                spriteBatch.Draw(gameOver, gameOverRect, Color.White);
                spriteBatch.Draw(goExitButton, goExitRect, Color.White);

                if(c1.Health <= 0)
                {
                    spriteBatch.DrawString(font, "You Died", new Vector2(335, 50), Color.White);
                }
                else
                {
                    spriteBatch.DrawString(font, "You Win", new Vector2(335, 50), Color.White);
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
