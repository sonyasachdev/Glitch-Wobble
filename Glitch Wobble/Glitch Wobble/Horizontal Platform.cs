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
    class Horizontal_Platform : Platform
    {
        //Fields
        Rectangle hitBox;

        //Platform States
        enum PlatformState
        {
            Left,
            Right
        }
        PlatformState currentPlatformState;

        //Constructor
        public Horizontal_Platform(Rectangle p, Texture2D s)
        {
            this.position = p;
            this.skin = s;
        }

        //Monogame Methods
        public void Initialize()
        {

        }
        public void LoadContent()
        {

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if(active == true)
            {
                //base.Draw(spriteBatch);

                switch (currentPlatformState)
                {
                    case PlatformState.Left:
                        //Purple Platform
                        base.Draw(spriteBatch);
                        break;
                    case PlatformState.Right:
                        //Purple Platform
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
                    MoveRight(position);
                    break;
                case PlatformState.Right:
                    MoveLeft(position);
                    break;
            }
        }
        //Methods
        public void MoveRight(Rectangle pos)
        {
            if (position.X < pos.X)
            {
                position.X += 1;
            }
            else if (position.X >= pos.X)
            {
                currentPlatformState = PlatformState.Left;
            }
        }
        public void MoveLeft(Rectangle pos)
        {
            if (position.X > pos.X)
            {
                position.X -= 1;
            }
            else if (position.X <= pos.X)
            {
                currentPlatformState = PlatformState.Right;
            }
        }
        //Hitbox Method
    }
}
