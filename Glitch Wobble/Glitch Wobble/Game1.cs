﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Timers;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.Diagnostics;

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

    public enum MusicState
    {
        Play,
        Stop,
        Pause
        //Quiet
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
        KeyboardState previousKey;
        
        //Classes
        Glitch glitch;
        Long_Sword longSword;
        Slime slime1;
        Vertical_Platform vert1;
        Horizontal_Platform horz1;
        Ground ground;
        Buttons button;
        Camera cam;

        //Rectangles
        Rectangle slimePos1;
        Rectangle vertPos1;
        Rectangle horzPos1;

        //Menu Textures
        Texture2D menuSkin;

        //Menu Rectangles
        Rectangle menuPos;

        //Draws Hitbox
        public static bool drawHitbox = false;

        //List
        public static List<Slime> enemyList;
        public static List<Horizontal_Platform> horzPlatformList;
        public static List<Vertical_Platform> vertPlatformList;
        List<Health> hearts;

        //Music Fields
        MusicState currentMusicState;
        Song song;
        bool songStart;

        //health fields
        Health hit1;
        Health hit2;
        Health hit3;
        Texture2D heart;
        int counter = 0;

        //Timers
        double slimeTimer;

        //Monogame Methods
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //Sets Window Size
            //Subject to change. Camera will be 1024x720. Actual game will be much bigger than that.
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
            cam = new Camera(GraphicsDevice.Viewport);
            hearts = new List<Health>();

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
            
            //Starting Position Rectangles Platform*
            //x,y,width,height 
            slimePos1 = new Rectangle(500, 400, 108, 108);
            vertPos1 = new Rectangle(600, 400, 400, 100);
            horzPos1 = new Rectangle(600, 500, 400, 100);

            //Class Initializations
            longSword = new Long_Sword();
            glitch = new Glitch();
            slime1 = new Slime(slimePos1, true, 0);
            vert1 = new Vertical_Platform(vertPos1);
            horz1 = new Horizontal_Platform(horzPos1);
            ground = new Ground();
            button = new Buttons();

            //Load Content Logic
            button.LoadContent(Content);
            slime1.LoadContent(Content);
            glitch.LoadContent(Content);
            longSword.LoadContent(Content);
            vert1.LoadContent(Content);
            horz1.LoadContent(Content);
            ground.LoadContent(Content);

            //List Initializations
            enemyList = new List<Slime>();
            enemyList.Add(slime1);

            horzPlatformList = new List<Horizontal_Platform>();
            horzPlatformList.Add(horz1);

            vertPlatformList = new List<Vertical_Platform>();
            vertPlatformList.Add(vert1);

            //Menu Textures
            menuSkin = Content.Load<Texture2D>("logoSkin.png");
            //Menu Rectangle
            menuPos = new Rectangle(0, 0, 1024, 720);

            //Sounds
            currentMusicState = MusicState.Stop;
            songStart = false;
            song = Content.Load<Song>("Level1");

            //health texture
            heart = Content.Load<Texture2D>("Heart");

            //Timers
            slimeTimer = 10.0;


            // TODO: use this.Content to load your game content here
            glitch.Initialize();   //initialized glitch so you can jump and get hurt

            /*
            button.Initialize();
            glitch.Initialize();
            longSword.Initialize();
            slime1.Initialize();   
            horz1.Initialize();
            vert1.Initialize();*/
            
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

            previousKey = key;
            key = Keyboard.GetState();

            if (key.IsKeyDown(Keys.Tab) && previousKey.IsKeyUp(Keys.Tab) == true)
                Process.Start("Game2.exe");

            key = Keyboard.GetState();
            //Game Switch
            switch (currentGameState)
            {
                case GameState.Menu:
                    button.MenuButtonSwitch(key);
                    break;
                case GameState.Options:
                    button.OptionButtonSwitch(key);
                    break;
                case GameState.PlayGame:
                    //Song Start Code
                    if(currentMusicState == MusicState.Stop)
                    {
                        MediaPlayer.Play(song);
                        //MediaPlayer.Volume This controls volume, so lower it when EMP goes off
                        songStart = true;
                        currentMusicState = MusicState.Play;
                    }
                    
                    if (currentMusicState == MusicState.Pause)
                    {
                        MediaPlayer.Resume();
                        currentMusicState = MusicState.Play;
                    }

                    if (key.IsKeyDown(Keys.Space) == true)
                    {
                        Game1.drawHitbox = true;
                    }
                    else if(key.IsKeyDown(Keys.B) == true)
                    {
                        Game1.drawHitbox = false;
                    }

                    //Each time this runs, have a reset level method and maybe a next level. Also, put all game logic into this part
                    horz1.SpawnTimer.Start();
                    vert1.SpawnTimer.Start();

                    slimeTimer -= gameTime.ElapsedGameTime.TotalSeconds;

                    // Slime spawn code
                    /*if (slimeTimer < 0)
                    {
                        slime1.Spawn();
                        enemyList[enemyList.Count - 1].LoadContent(Content);
                        slimeTimer = 10.0;
                    }*/

                    //Glitch collision loop for enemies
                    for (int i = 0; i < enemyList.Count; i++)
                    {
                        glitch.GlitchGetsHurt(enemyList[i]);
                    }

                    //Camera*
                    cam.Update(gameTime, glitch);

                    //Class switches
                    glitch.Switch(gameTime);
                    slime1.Switch(gameTime);
                    vert1.Switch();
                    horz1.Switch();
                    vert1.Spawning();
                    horz1.Spawning();
                    longSword.Switch();
                    ground.Update(gameTime);

                    if ( key.IsKeyDown(Keys.Tab) == true)
                    {
                        currentGameState = GameState.Pause;
                    }

                    break;
                case GameState.Pause:
                    //Draw Pause Screen
                    button.PauseButtonSwitch(key);
                    MediaPlayer.Pause();
                    currentMusicState = MusicState.Pause;

                    if( key.IsKeyDown(Keys.Enter) == true)
                    {
                        currentGameState = GameState.PlayGame;
                    }

                    break;
                case GameState.Win:
                    break;
                case GameState.GameOver:
                    glitch.Reset();
                    horz1.Reset();
                    vert1.Reset();
                    slime1.Reset();
                    ground.Reset();

                    if (key.IsKeyDown(Keys.Enter) == true)
                    {
                        currentGameState = GameState.Menu;
                    }

                    //Song Reset Code
                    songStart = false;
                    currentMusicState = MusicState.Stop;
                    MediaPlayer.Stop();

                    button.GameOverSwitch(key);
                    break;
            }

            base.Update(gameTime);
        }

        //Methods for Game



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            // TODO: Add your drawing code here

            switch (currentGameState)
            {
                case GameState.Menu:
                    spriteBatch.Begin();
                    spriteBatch.Draw(menuSkin, menuPos, Color.White);
                    button.DrawMenu(spriteBatch);
                    break;
                case GameState.Options:
                    spriteBatch.Begin();
                    button.DrawOptions(spriteBatch);
                    break;
                case GameState.PlayGame:
                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, cam.transform);
                    //Note: Order matters! The last thing called is in the front.
                    //Background sprite goes here
                    ground.Draw(spriteBatch);
                    vert1.Draw(spriteBatch); 
                    horz1.Draw(spriteBatch);
                    glitch.Draw(spriteBatch);
                    for (int i = 0; i < enemyList.Count; i++)
                    {
                        enemyList[i].Draw(spriteBatch, gameTime);
                    }
                    longSword.Draw(spriteBatch);

                    //Lives
                    hit1 = new Health(glitch.Position.X - 225, 0, 75, 75, heart);
                    hit2 = new Health(glitch.Position.X - 150, 0, 75, 75, heart);
                    hit3 = new Health(glitch.Position.X - 75, 0, 75, 75, heart);

                    if (glitch.Lives == 2)
                    {
                        hit1.Draw(spriteBatch);
                        hit2.Draw(spriteBatch);
                        hit3.Draw(spriteBatch);
                    }
                    else if (glitch.Lives == 1)
                    {
                        hit1.Draw(spriteBatch);
                        hit2.Draw(spriteBatch);
                    }
                    else if (glitch.Lives == 0)
                        hit1.Draw(spriteBatch);

                    break;
                case GameState.Pause:
                    button.DrawPause(spriteBatch);
                    break;
                case GameState.Win:
                    break;
                case GameState.GameOver:
                    button.DrawGameOver(spriteBatch);
                    break;
            }
            

            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
