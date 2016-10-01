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

        //States
        enum PlatformState
        {
            Up,
            Down,
        }
        PlatformState currentPlatformState;

        //Constructor
        public Vertical_Platform(Rectangle p, Texture2D s)
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
            //skin = Content.Load<Texture2D>("vertPlatform.png");
        }
        public void Draw()
        {
            switch (currentPlatformState)
            {
                case PlatformState.Up:
                    //Blue Platform
                    break;
                case PlatformState.Down:
                    //Blue Platform
                    break;
                default:
                    break;
            }
        }

        //Methods
        public void Switch()
        {
            switch (currentPlatformState)
            {
                case PlatformState.Up:
                    MoveUp(position);
                    break;
                case PlatformState.Down:
                    MoveDown(position);
                    break;
                default:
                    break;
            }
        }
        public void MoveUp(Rectangle pos)
        {
            while (position.Y <= pos.Y )
            {
                position.Y += 1;
            }
            if (position.Y == pos.Y)
            {
                currentPlatformState = PlatformState.Down;
            }
        }
        public void MoveDown(Rectangle pos)
        {
            while (position.Y >= pos.Y)
            {
                position.Y -= 1;
            }
            if (position.Y == pos.Y)
            {
                currentPlatformState = PlatformState.Up;
            }
        }  
    }
}
