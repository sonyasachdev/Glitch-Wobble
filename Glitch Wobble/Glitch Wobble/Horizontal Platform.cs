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
        Timer SpawnTimer;
        
        Texture2D horzSkin;
        HorizontalPlatformState currentPlatformState;

        //Constructor
        public Horizontal_Platform(Rectangle p /*, Rectangle l, Rectangle r */)
        {
            this.position = p;
            LeftBound = new Rectangle(100, 100, 10, 10);
            RightBound = new Rectangle(400, 100, 10, 10);
            //horzSkin = skin;
            //LeftBound = l;
            //RightBound = r;
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
            horzSkin = Content.Load<Texture2D>("horzSkin.png");
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if(active == true)
            {
                switch (currentPlatformState)
                {
                    case HorizontalPlatformState.Left:
                        //base.Draw(spriteBatch);
                        spriteBatch.Draw(horzSkin, position, Color.White);
                        break;
                    case HorizontalPlatformState.Right:
                        //base.Draw(spriteBatch);
                        spriteBatch.Draw(horzSkin, position, Color.White);
                        break;
                }
            }
        }
        public void Switch()
        {
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


        //Hitbox Method
    }
}
