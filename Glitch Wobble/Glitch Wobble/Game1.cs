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
        enum MenuState
        {
            //SplashScreen,
            //LoadScreen,
            Main,
            Options,
            Play
        }
        MenuState currentMenuState;
        //Actual Game
        enum PlayState
        {
            Pause,
            Play,
            Win,
            Reset
            //NextLevel,
        }
        PlayState currentPlayState;
        //Changes between menu and game
        enum GameState
        {
            Menu,
            Game,
            Gameover
        }
        GameState currentGameState;
        enum SlimeState
        {
            MoveLeft,
            MoveRight,
            //IdleLeft,
            //IdleRight,
            Hurt,
            Dead
        }
        SlimeState currentSlimeState;
        //Fields
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
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
            currentGameState = GameState.Menu;
            //If you get a splashscreen, use:
            //currentMenuState = MenuState.SplashScreen;
            currentMenuState = MenuState.Main;
            //currentPlayState = PlayState.Play;
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
            //Assigning Textures
            glitch.Skin = glitchSkin;
            longSword.Skin = longSwordSkin;
            slime1.Skin = slimeSkin;
            vert1.Skin = vertSkin;
            horz1.Skin = horzSkin;
            //Assigning Locations
            glitch.Position = glitchPos;
            longSword.Position = longSwordPos;
            slime1.Position = slimePos1;
            vert1.Position = vertPos1;
            horz1.Position = horzPos1;
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
            //Main Switches



            //External Switches
            glitch.Switch();
            slime1.Switch();
            vert1.Switch();
            horz1.Switch();

            base.Update(gameTime);
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

            spriteBatch.Draw(slime1.Skin, slime1.Position, Color.White);
            switch (currentSlimeState)
            {
                case SlimeState.MoveLeft:
                    SlimeIdle(SpriteEffects.FlipHorizontally);
                    break;
                case SlimeState.MoveRight:
                    SlimeIdle(SpriteEffects.None);
                    break;
                case SlimeState.Hurt:
                    //Hurt Animation
                    break;
                case SlimeState.Dead:
                    //Dead Animation
                    break;
            }

            glitch.Draw();
            //slime1.Draw(slime1.Skin, slime1.Position, Color.White);
            longSword.Draw();
            vert1.Draw();
            horz1.Draw();

            base.Draw(gameTime);
            spriteBatch.End();
        }
        private void SlimeIdle(SpriteEffects flipSprite)
        {
            spriteBatch.Draw(slime1.Skin, new Vector2(0, 0), slime1.Position, Color.White, 0, Vector2.Zero, 1.0f, flipSprite, 0);
        }
    }
}
