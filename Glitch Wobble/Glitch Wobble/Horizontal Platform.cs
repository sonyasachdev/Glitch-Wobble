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

        //Platform States
        enum PlatformState
        {
            Left,
            Right,
        }
        PlatformState currentPlatformState;

        //Constructor
        public Horizontal_Platform(Vector2 p)
        {
            this.position = p;
        }

        //Monogame Methods
        public void Initialize()
        {

        }
        public void Draw()
        {
            switch (currentPlatformState)
            {
                case PlatformState.Left:
                    //Purple Platform
                    break;
                case PlatformState.Right:
                    //Purple Platform
                    break;
                default:
                    break;
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
                default:
                    break;
            }
        }
        //Methods
        public void MoveRight(Vector2 pos)
        {
            while (position.X <= pos.X)
            {
                position.X += 1;
            }
            if (position.X == pos.X)
            {
                currentPlatformState = PlatformState.Left;
            }

        }
        public void MoveLeft(Vector2 pos)
        {
            while (position.X >= pos.X)
            {
                position.X -= 1;
            }
            if (position.X == pos.X)
            {
                currentPlatformState = PlatformState.Right;
            }
        }
    }
}
