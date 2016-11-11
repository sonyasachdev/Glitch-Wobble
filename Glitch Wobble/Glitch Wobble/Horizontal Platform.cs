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
    class Horizontal_Platform : Platform
    {
        //Fields
        Rectangle hitBox;
        Rectangle LeftBound;
        Rectangle RightBound;
        public Timer SpawnTimer;
        HorizontalPlatformState currentPlatformState;

        //Test Fields
        Texture2D hitboxSkin;

        //Constructor
        public Horizontal_Platform(Rectangle p /*, Rectangle l, Rectangle r */)
        {
            //Positions
            this.position = p;
            LeftBound = new Rectangle(600, 100, 10, 10);
            RightBound = new Rectangle(1000, 100, 10, 10);

            //This is to externally have the left and right bounds made so you can make more platforms easily
            //LeftBound = l;
            //RightBound = r;

            //Sets Hitbox
            hitbox = new Rectangle(position.X, position.Y, 315, 10);

            //Timer
            SpawnTimer = new Timer();
            SpawnTimer.Interval = 2000;
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
        public override void Draw(SpriteBatch spriteBatch)
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
            hitbox.X = position.X+40;
            hitbox.Y = position.Y;

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
    }
}
