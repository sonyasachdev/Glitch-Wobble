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
    class Horizontal_Platform : Platform
    {
        //Fields
        Rectangle hitBox;
        Rectangle LeftBound;
        Rectangle RightBound;

        Texture2D horzSkin;

        //Platform States
        enum PlatformState
        {
            Left,
            Right
        }
        PlatformState currentPlatformState;

        //Constructor
        public Horizontal_Platform(Rectangle p /*, Rectangle l, Rectangle r */)
        {
            this.position = p;
            LeftBound = new Rectangle(100, 100, 10, 10);
            RightBound = new Rectangle(400, 100, 10, 10);
            //LeftBound = l;
            //RightBound = r;

        }

        //Monogame Methods
        public void Initialize()
        {
            currentPlatformState = PlatformState.Right;
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
                    case PlatformState.Left:
                        base.Draw(spriteBatch);
                        break;
                    case PlatformState.Right:
                        base.Draw(spriteBatch);
                        break;
                }
            }
        }
        public void Switch()
        {
            switch (currentPlatformState)
            {
                case PlatformState.Left:
                    MoveLeft(LeftBound);
                    break;
                case PlatformState.Right:
                    MoveRight(RightBound);
                    break;
            }
        }
        //Methods
        public void MoveRight(Rectangle RightBound)
        {
            if (position.X < RightBound.X)
            {
                position.X += 10;
            }
            else if (position.X >= RightBound.X)
            {
                currentPlatformState = PlatformState.Left;
            }
        }
        public void MoveLeft(Rectangle LeftBound)
        {
            if (position.X > LeftBound.X)
            {
                position.X -= 10;
            }
            else if (position.X <= LeftBound.X)
            {
                currentPlatformState = PlatformState.Right;
            }
        }
        //Hitbox Method
    }
}
