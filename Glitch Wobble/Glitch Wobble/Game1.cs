using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Timers;

namespace Glitch_Wobble
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        //Enums
        //Menu
        enum MenuButtonState
        {
            ActivePlayButton,
            ActiveOptionButton,

            IdlePlayButton,
            IdleOptionButton
        }
        MenuButtonState currentMenuButtonState;

        enum OptionButtonState
        {
            ActiveEasy,
            ActiveMedium,
            ActiveHard,
            ActiveCancel,

            IdleEasy,
            IdleMedium,
            IdleHard,
            IdleCancel
        }
        OptionButtonState currentOptionButtonState;
        //Changes between menu and game
        enum GameState
        {
            Menu,
            Options,
            PlayGame,
            Pause,
            Win,
            GameOver
        }
        GameState currentGameState;

        //Fields
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState key;
        //Textures
        Texture2D glitchSkin;
        Texture2D longSwordSkin;
        Texture2D slimeSkin;
        Texture2D vertSkin;
        Texture2D horzSkin;
        //Classes
        Glitch glitch;
        Long_Sword longSword;
        Slime slime1;
        Vertical_Platform vert1;
        Horizontal_Platform horz1;
        //Rectangles
        Rectangle glitchPos;
        Rectangle longSwordPos;
        Rectangle slimePos1;
        Rectangle vertPos1;
        Rectangle horzPos1;
        //Rectangle is x, y, width and height



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
            currentGameState = GameState.PlayGame;
            currentMenuButtonState = MenuButtonState.ActivePlayButton;
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
            //Textures
            glitchSkin = Content.Load<Texture2D>("glitchSkin.png");
            longSwordSkin = Content.Load<Texture2D>("longSwordSkin.png");
            slimeSkin = Content.Load<Texture2D>("slimeSkin.png");
            vertSkin = Content.Load<Texture2D>("vertSkin.png");
            horzSkin = Content.Load<Texture2D>("horzSkin.png");
            //Starting Positions Rectangles
            glitchPos = new Rectangle(0, 0, 100, 100);
            longSwordPos = new Rectangle(0, 0, 100, 100);
            slimePos1 = new Rectangle(100, 100, 350, 200);
            vertPos1 = new Rectangle(100, 300, 400, 100);
            horzPos1 = new Rectangle(100, 500, 400, 100);
            //Class Initializations
            glitch = new Glitch(glitchPos, glitchSkin);
            longSword = new Long_Sword(longSwordPos, longSwordSkin);
            slime1 = new Slime(slimePos1, slimeSkin, true, 0);
            vert1 = new Vertical_Platform(vertPos1, vertSkin);
            horz1 = new Horizontal_Platform(horzPos1, horzSkin);
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
            switch (currentMenuButtonState)
            {
                case MenuButtonState.ActivePlayButton:
                    if (key.IsKeyDown(Keys.Down))
                    {
                        currentMenuButtonState = MenuButtonState.ActiveOptionButton;
                    }
                    else if (key.IsKeyDown(Keys.Enter))
                    {
                        currentGameState = GameState.PlayGame;
                    }
                    break;
                case MenuButtonState.ActiveOptionButton:

                    if (key.IsKeyDown(Keys.Up))
                    {
                        currentMenuButtonState = MenuButtonState.ActivePlayButton;
                    }
                    else if (key.IsKeyDown(Keys.Enter))
                    {
                        currentGameState = GameState.Options;
                    }
                    break;
            }
            //Options Button Switch
            switch (currentOptionButtonState)
            {
                case OptionButtonState.ActiveEasy:
                    if (key.IsKeyDown(Keys.Down))
                    {
                        currentOptionButtonState = OptionButtonState.ActiveMedium;
                    }
                    else if (key.IsKeyDown(Keys.Up))
                    {
                        currentOptionButtonState = OptionButtonState.ActiveCancel;
                    }
                    else if (key.IsKeyDown(Keys.Enter))
                    {
                        //Put code to switch difficulty
                        currentGameState = GameState.Menu;
                    }
                    break;
                case OptionButtonState.ActiveMedium:
                    if (key.IsKeyDown(Keys.Down))
                    {
                        currentOptionButtonState = OptionButtonState.ActiveHard;
                    }
                    else if (key.IsKeyDown(Keys.Up))
                    {
                        currentOptionButtonState = OptionButtonState.ActiveEasy;
                    }
                    else if (key.IsKeyDown(Keys.Enter))
                    {
                        //Put code to switch difficulty
                        currentGameState = GameState.Menu;
                    }
                    break;
                case OptionButtonState.ActiveHard:
                    if (key.IsKeyDown(Keys.Down))
                    {
                        currentOptionButtonState = OptionButtonState.ActiveCancel;
                    }
                    else if (key.IsKeyDown(Keys.Up))
                    {
                        currentOptionButtonState = OptionButtonState.ActiveMedium;
                    }
                    else if (key.IsKeyDown(Keys.Enter))
                    {
                        //Put code to switch difficulty
                        currentGameState = GameState.Menu;
                    }
                    break;
                case OptionButtonState.ActiveCancel:
                    if (key.IsKeyDown(Keys.Down))
                    {
                        currentOptionButtonState = OptionButtonState.ActiveEasy;
                    }
                    else if (key.IsKeyDown(Keys.Up))
                    {
                        currentOptionButtonState = OptionButtonState.ActiveHard;
                    }
                    else if (key.IsKeyDown(Keys.Enter))
                    {
                        currentGameState = GameState.Menu;
                    }
                    break;
            }
            //Game Switch
            switch (currentGameState)
            {
                case GameState.Menu:
                    break;
                case GameState.Options:

                    break;
                case GameState.PlayGame:
                    //Each time this runs, have a reset level method. Also, put all game logic into this part
                    //Glitch Check Collision Code. Have this run for every enemy (copy and paste it). See if there's a more efficient way to do this
                    GlitchHurt(slime1);

                    glitch.Switch();
                    slime1.Switch();
                    vert1.Switch();
                    horz1.Switch();

                    break;
                case GameState.Pause:
                    break;
                case GameState.Win:
                    break;
                case GameState.GameOver:
                    break;
            }

            //External Switches
            

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
            //Main Draw Switches
            //Menu Button Switches
            switch (currentMenuButtonState)
            {
                case MenuButtonState.ActivePlayButton:
                    //spriteBatch.Draw(playActiveButtonSkin, playActiveButtonRectangle, Color.White)
                    break;
                case MenuButtonState.ActiveOptionButton:
                    //spriteBatch.Draw(playActiveOptionButtonSkin, playActiveButtonRectangle, Color.White)
                    break;
                case MenuButtonState.IdlePlayButton:
                    //spriteBatch.Draw(playIdleButtonSkin, playActiveButtonRectangle, Color.White)
                    break;
                case MenuButtonState.IdleOptionButton:
                    //spriteBatch.Draw(playIdleOptionButtonSkin, playActiveButtonRectangle, Color.White)
                    break;
                default:
                    break;
            }
            //OptionButtonSwitches
            switch (currentOptionButtonState)
            {
                case OptionButtonState.ActiveEasy:
                    break;
                case OptionButtonState.ActiveMedium:
                    break;
                case OptionButtonState.ActiveHard:
                    break;
                case OptionButtonState.ActiveCancel:
                    break;
                case OptionButtonState.IdleEasy:
                    break;
                case OptionButtonState.IdleMedium:
                    break;
                case OptionButtonState.IdleHard:
                    break;
                case OptionButtonState.IdleCancel:
                    break;
                default:
                    break;
            }

            glitch.Draw(spriteBatch);
            slime1.Draw(spriteBatch);
            longSword.Draw(spriteBatch);
            vert1.Draw(spriteBatch);
            horz1.Draw(spriteBatch);

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
