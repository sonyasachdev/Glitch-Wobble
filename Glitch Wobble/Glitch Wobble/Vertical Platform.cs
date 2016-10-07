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
    class Vertical_Platform : Platform
    {
        //Fields
        Rectangle hitBox;
        Rectangle UpperBound;
        Rectangle LowerBound;

        Texture2D vertSkin;
        //States
        enum PlatformState
        {
            Up,
            Down
        }
        PlatformState currentPlatformState;

        //Constructor
        public Vertical_Platform(Rectangle p /*, Rectangle u, Rectangle l */)
        {
            this.position = p;
            UpperBound = new Rectangle(100, 0, 10, 10);
            LowerBound = new Rectangle(100, 700, 10, 10);

            //remember that the upper bound will be small (closer to 0) and lower will be big
            //UpperBound = u;
            //LowerBound = l;
        }

        //Monogame Methods
        public void Initialize()
        {
            currentPlatformState = PlatformState.Down;
        }
        public void LoadContent(ContentManager Content)
        {
            vertSkin = Content.Load<Texture2D>("vertSkin.png");
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (active == true)
            {
                switch (currentPlatformState)
                {
                    case PlatformState.Up:
                        base.Draw(spriteBatch);
                        break;
                    case PlatformState.Down:
                        base.Draw(spriteBatch);
                        break;
                }
            }
        }

        //Methods
        public void Switch()
        {
            switch (currentPlatformState)
            {
                case PlatformState.Up:
                    MoveUp(UpperBound);
                    break;
                case PlatformState.Down:
                    MoveDown(LowerBound);
                    break;
            }
        }
        public void MoveUp(Rectangle UpperBound)
        {
            if (position.Y > UpperBound.Y )
            {
                position.Y -= 10;
            }
            else if (position.Y <= UpperBound.Y)
            {
                currentPlatformState = PlatformState.Down;
            }
        }
        public void MoveDown(Rectangle LowerBound)
        {
            if (position.Y < LowerBound.Y)
            {
                position.Y += 10;
            }
            else if (position.Y >= LowerBound.Y)
            {
                currentPlatformState = PlatformState.Up;
            }
        }
    }
}
