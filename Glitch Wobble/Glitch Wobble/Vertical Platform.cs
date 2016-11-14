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
    public class Vertical_Platform : Platform
    {
        //Fields
        Rectangle UpperBound;
        Rectangle LowerBound;
        public Timer SpawnTimer;
        ContentManager Content;
        VerticalPlatformState currentPlatformState;

        //Active
        public static bool pubActive;

        //Current X and Y Positions
        public static int currentPositionX;
        public static int currentPositionY;

        //Reset ints
        int startPositionX;
        int startPositionY;

        //Direction = true means going up
        public static bool direction;

        //Test Skin
        Texture2D hitboxSkin;

        //Constructor
        public Vertical_Platform(Rectangle p /*, Rectangle u, Rectangle l */)
        {
            this.position = p;
            UpperBound = new Rectangle(600, 100, 10, 10);
            LowerBound = new Rectangle(600, 400, 10, 10);

            //Active
            pubActive = active;

            //Reset Position
            startPositionX = p.X;
            startPositionY = p.Y;

            currentPositionX = p.X;
            currentPositionY = p.Y;
            //This will be so that you can input the bounds externally and easily create many platforms
            //UpperBound = u;
            //LowerBound = l;

            //Sets direction to up
            direction = true;

            //Sets Hitbox
            hitbox = new Rectangle(position.X, position.Y, 315, 10);

            //Timer
            SpawnTimer = new Timer();
            //Change*
            SpawnTimer.Interval = 500;
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
            hitboxSkin = Content.Load<Texture2D>("playactive.png");
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(hitboxSkin, hitbox, Color.White);

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
            hitbox.X = position.X + 40;
            hitbox.Y = position.Y + 10;

            currentPositionX = position.X + 40;
            currentPositionY = position.Y + 10;

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
                direction = false;
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
                direction = true;
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

        //Reset*
        public void Reset()
        {
            position.X = startPositionX;
            position.Y = startPositionY;
        }
    }
}
