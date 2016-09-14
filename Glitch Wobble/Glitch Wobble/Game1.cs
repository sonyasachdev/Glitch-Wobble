using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Glitch_Wobble
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Variables
        private Vector2 characterLocation;

        enum GameState
        {
            //SplashScreen,
            Menu,
            Options,
            Pause,
            HowToPlay,
            Game,
            Win,
            //NextLevel,
            GameOver
        }
        GameState currentGameState;
        enum LongSwordState
        {
            Attack,
            Move,
            Jump,
            Stand,
            Hurt,
            Dead
        }
        LongSwordState currentLongSwordState;
        enum DaggerState
        {
            Attack,
            Move,
            Jump,
            Stand,
            Hurt,
            Dead
        }
        DaggerState currentDaggerState;
        enum BlasterState
        {
            Attack,
            Move,
            Jump,
            Stand,
            Hurt,
            Dead
        }
        BlasterState currentBlasterState;
        enum EnemyState
        {
            Attack,
            Move,
            Hurt,
            Dead
        }
        EnemyState currentEnemyState;
        /*
        enum CharacterState
        {
            LongSword,
            Dagger,
            Blaster,
            Move,
            Jump,
            Stand,
            Dead,
            Hurt
        }
        CharacterState currentCharacterState;
        */


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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

            Move();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        //Keyboard Input Method
        public void Move()
        {
            KeyboardState key = Keyboard.GetState();
            if (key.IsKeyDown(Keys.Up) == true)
            {
                //Code to make character Jump, maybe have some physics?
            }
            if (key.IsKeyDown(Keys.Left) == true)
            {
                characterLocation.X -= 3;
            }
            if (key.IsKeyDown(Keys.Right) == true)
            {
                characterLocation.X += 3;
            }
        }

    }
}
