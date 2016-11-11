using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Timers;
using System.IO;

namespace Glitch_Wobble
{
    public enum VerticalPlatformState
    {
        Up,
        Down
    }
    class Vertical_Platform : Platform
    {
        //Fields
        Rectangle hitBox;
        Rectangle UpperBound;
        Rectangle LowerBound;
        public Timer SpawnTimer;
        ContentManager Content;
        VerticalPlatformState currentPlatformState;

        //Constructor
        public Vertical_Platform(Rectangle p /*, Rectangle u, Rectangle l */)
        {
            this.position = p;
            UpperBound = new Rectangle(600, 0, 10, 10);
            LowerBound = new Rectangle(600, 700, 10, 10);

            //This will be so that you can input the bounds externally and easily create many platforms
            //UpperBound = u;
            //LowerBound = l;

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
            currentPlatformState = VerticalPlatformState.Down;
        }
        public void LoadContent(ContentManager Content)
        {
            skin = Content.Load<Texture2D>("vertSkin.png");
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (active == true)
            {
                switch (currentPlatformState)
                {
                    case VerticalPlatformState.Up:
                        spriteBatch.Draw(skin, position, Color.White);
                        break;
                    case VerticalPlatformState.Down:
                        spriteBatch.Draw(skin, position, Color.White);
                        break;
                }
            }
        }

        //Methods
        //Update*
        public void Switch()
        {
            hitBox.X = position.X+40;
            hitbox.Y = position.Y;
            switch (currentPlatformState)
            {
                case VerticalPlatformState.Up:
                    MoveUp(UpperBound);
                    break;
                case VerticalPlatformState.Down:
                    MoveDown(LowerBound);
                    break;
            }
        }

        //Move Up*
        public void MoveUp(Rectangle UpperBound)
        {
            if (position.Y > UpperBound.Y )
            {
                position.Y -= 5;
            }
            else if (position.Y <= UpperBound.Y)
            {
                currentPlatformState = VerticalPlatformState.Down;
            }
        }

        //Move Down*
        public void MoveDown(Rectangle LowerBound)
        {
            if (position.Y < LowerBound.Y)
            {
                position.Y += 5;
            }
            else if (position.Y >= LowerBound.Y)
            {
                currentPlatformState = VerticalPlatformState.Up;
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
        public void Spawn()
        {
            SpawnTimer.Start();
            Active = true;
        }
        public void Despawn()
        {
            SpawnTimer.Stop();
            Active = false;
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
