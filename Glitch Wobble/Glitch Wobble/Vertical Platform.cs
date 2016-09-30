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
    class Vertical_Platform : Platform
    {
        //Fields
        enum PlatformState
        {
            Up,
            Down,
        }
        PlatformState currentPlatformState;
        //Constructor
        public Vertical_Platform(Vector2 p)
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
        public void MoveUp(Vector2 pos)
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
        public void MoveDown(Vector2 pos)
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
