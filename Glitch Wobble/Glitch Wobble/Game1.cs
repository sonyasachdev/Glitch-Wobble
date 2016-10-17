using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Timers;
using Microsoft.Xna.Framework.Content;

namespace Glitch_Wobble
{
    //Changes between menu and game
    public enum GameState
    {
        Menu,
        Options,
        PlayGame,
        Pause,
        Win,
        GameOver
    }
    
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        //Enum Variable
        public static GameState currentGameState;

        //Fields
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState key;
        
        //Classes
        Glitch glitch;
        Long_Sword longSword;
        Slime slime1;
        Vertical_Platform vert1;
        Horizontal_Platform horz1;
        Buttons button;

        //Rectangles
        Rectangle slimePos1;
        Rectangle vertPos1;
        Rectangle horzPos1;

        //Textures
        Texture2D glitchSkin;
        Texture2D slimeSkin;
        Texture2D vertSkin;
        Texture2D horzSkin;
        Texture2D longswordSkin;
        Texture2D buttonSkin;




        //Menu Textures
        Texture2D menuSkin;
        //Menu Rectangles
        Rectangle menuPos;


        //Monogame Methods
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //Sets Window Size
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();
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
            //If you get a splashscreen, use:
            //currentMenuState = GameState.SplashScreen;
            currentGameState = GameState.Menu;

            //Class Initializations
            /*
            button.Initialize();
            glitch.Initialize();
            longSword.Initialize();
            slime1.Initialize();
            horz1.Initialize();
            vert1.Initialize();*/

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
            
            //Starting Position Rectangles
            slimePos1 = new Rectangle(100, 100, 350, 200);
            vertPos1 = new Rectangle(100, 300, 400, 100);
            horzPos1 = new Rectangle(100, 500, 400, 100);

            //Class Initializations
            glitch = new Glitch();
            longSword = new Long_Sword();
            slime1 = new Slime(slimePos1, true, 0);
            vert1 = new Vertical_Platform(vertPos1);
            horz1 = new Horizontal_Platform(horzPos1);
            button = new Buttons();

            glitchSkin = Content.Load<Texture2D>("glitchSkin.png");

            
            button.LoadContent(Content);
            slime1.LoadContent(Content);
            glitch.LoadContent(Content);
            longSword.LoadContent(Content);
            vert1.LoadContent(Content);
            horz1.LoadContent(Content);
            

            //Menu Textures
            menuSkin = Content.Load<Texture2D>("mainmenu.png");
            //Menu Rectangle
            menuPos = new Rectangle(0, 0, 1024, 720);

            // TODO: use this.Content to load your game content here
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
            key = Keyboard.GetState();
            //Main Switches
            //Menu Button Switch
            button.MenuButtonSwitch(key);
            //Options Button Switch
            button.OptionButtonSwitch(key);
            //Pause Button Switch
            button.PauseButtonSwitch(key);

            //Game Switch
            switch (currentGameState)
            {
                case GameState.Menu:
                    break;
                case GameState.Options:

                    break;
                case GameState.PlayGame:
                    //Each time this runs, have a reset level method. Also, put all game logic into this part
                    //Glitch Check Collision Code. Have this run for every enemy (copy and paste it). See if there's a more efficient way to do this.
                    GlitchHurt(slime1);

                    //Class switches
                    glitch.Switch();
                    slime1.Switch();
                    vert1.Switch();
                    horz1.Switch();
                    longSword.Switch();
                    break;
                case GameState.Pause:
                    //Draw Pause Screen
                    break;
                case GameState.Win:
                    break;
                case GameState.GameOver:
                    break;
            }

            base.Update(gameTime);
        }

        //Methods for Game
        //Collision Code
        public void GlitchHurt(Slime slime)
        {
            if (glitch.Position.Intersects(slime.Position) == true)
            {
                if (glitch.Lives < 4 && glitch.Lives > 0)
                {
                    glitch.Lives--;
                }
                else if (glitch.Lives == 0)
                {
                    currentGameState = GameState.GameOver;
                }
            }
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            switch (currentGameState)
            {
                case GameState.Menu:
                    spriteBatch.Draw(menuSkin, menuPos, Color.White);
                    button.DrawMenu(spriteBatch);
                    break;
                case GameState.Options:
                    button.DrawOptions(spriteBatch);
                    break;
                case GameState.PlayGame:
                    glitch.Draw(spriteBatch);
                    slime1.Draw(spriteBatch);
                    longSword.Draw(spriteBatch);
                    vert1.Draw(spriteBatch);
                    horz1.Draw(spriteBatch);
                    break;
                case GameState.Pause:
                    break;
                case GameState.Win:
                    break;
                case GameState.GameOver:
                    break;
            }
            

            base.Draw(gameTime);
            spriteBatch.End();
        }
        /*
        private void SlimeIdle(SpriteEffects flipSprite)
        {
            spriteBatch.Draw(slime1.Skin, new Vector2(0, 0), slime1.Position, Color.White, 0, Vector2.Zero, 1.0f, flipSprite, 0);
        }*/
    }
}
