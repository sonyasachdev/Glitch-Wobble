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
    //Platform States
    public enum HorizontalPlatformState
    {
        Left,
        Right
    }
    public class Horizontal_Platform : Platform
    {
        //Fields
        Rectangle LeftBound;
        Rectangle RightBound;
        public Timer SpawnTimer;
        HorizontalPlatformState currentPlatformState;

        //Active
        public static bool pubActive;

        //Current Position ints
        public static int currentPositionX;
        public static int currentPositionY;

        //Reset ints
        int startPositionX;
        int startPositionY;

        //Direction = true means going right
        public static bool direction;

        //Test Fields
        Texture2D hitboxSkin;

        //Constructor
        public Horizontal_Platform(Rectangle p /*, Rectangle l, Rectangle r */)
        {
            //Positions
            this.position = p;
            LeftBound = new Rectangle(600, 100, 10, 10);
            RightBound = new Rectangle(800, 100, 10, 10);

            pubActive = active;

            //Reset Positions
            startPositionX = p.X;
            startPositionY = p.Y;

            currentPositionX = p.X;
            currentPositionY = p.Y;

            //This is to externally have the left and right bounds made so you can make more platforms easily
            //LeftBound = l;
            //RightBound = r;

            //Sets direction to right
            direction = true;

            //Sets Hitbox
            hitbox = new Rectangle(position.X, position.Y, 315, 10);
            
            //Timer
            SpawnTimer = new Timer();
            SpawnTimer.Interval = 1000;
            SpawnTimer.Elapsed += Despawn;
            Active = true;

        }

        //Monogame Methods
        public void Initialize()
        {
            currentPlatformState = HorizontalPlatformState.Right;
        }
        public void LoadContent(ContentManager Content)
        {
            skin = Content.Load<Texture2D>("horzSkin.png");
            hitboxSkin = Content.Load<Texture2D>("playactive.png");
        }
        //Draw*
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(hitboxSkin, hitbox, Color.White);

            if(active == true)
            {
                switch (currentPlatformState)
                {
                    case HorizontalPlatformState.Left:
                        spriteBatch.Draw(skin, position, Color.White);
                        break;
                    case HorizontalPlatformState.Right:
                        spriteBatch.Draw(skin, position, Color.White);
                        break;
                }
            }
        }
        //Update*
        public void Switch()
        {
            hitbox.X = position.X + 40;
            hitbox.Y = position.Y + 10;

            currentPositionX = position.X + 40;
            currentPositionY = position.Y + 10;

            switch (currentPlatformState)
            {
                case HorizontalPlatformState.Left:
                    MoveLeft(LeftBound);
                    break;
                case HorizontalPlatformState.Right:
                    MoveRight(RightBound);
                    break;
            }
        }

        //Methods
        //Move Right*
        public void MoveRight(Rectangle RightBound)
        {
            if (position.X < RightBound.X)
            {
                position.X += 5;
            }
            else if (position.X >= RightBound.X)
            {
                direction = false;
                currentPlatformState = HorizontalPlatformState.Left;
            }
        }
        //Move Left*
        public void MoveLeft(Rectangle LeftBound)
        {
            if (position.X > LeftBound.X)
            {
                position.X -= 5;
            }
            else if (position.X <= LeftBound.X)
            {
                direction = true;
                currentPlatformState = HorizontalPlatformState.Right;
            }
        }
        //Spawn*
        public void Spawning()
        {
            if (Active == true)
            {
                SpawnTimer.Elapsed += Despawn;
            }
            else
            {
                SpawnTimer.Elapsed += Spawn;
            }
        }
        public void Despawn()
        {
            SpawnTimer.Stop();
            Active = false;
        }

        public void Spawn()
        {
            SpawnTimer.Start();
            Active = true;
        }
        private void Despawn(Object source, System.Timers.ElapsedEventArgs e)
        {
            Despawn();
        }

        private void Spawn(Object source, System.Timers.ElapsedEventArgs e)
        {
            Spawn();
        }

        //Reset*
        public void Reset()
        {
            position.X = startPositionX;
            position.Y = startPositionY;
        }
    }
}
