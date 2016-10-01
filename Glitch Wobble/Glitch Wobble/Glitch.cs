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
    class Glitch : Beings
    {
        //Fields
        Timer JumpTimer;
        SpriteBatch spriteBatch;
        KeyboardState key = Keyboard.GetState();
        Rectangle hitBox;

        //Constructor
        public Glitch (Rectangle p, Texture2D s)
        {
            this.position = p;
            this.skin = s;
            JumpTimer = new Timer();
            JumpTimer.Interval = 2000;
            JumpTimer.Elapsed += EndJump;
        }

        //Timer Function
        private void EndJump(Object source, System.Timers.ElapsedEventArgs e)
        {
            EndJump();
        }

        //Glitch State
        enum GlitchState
        {
            MoveRight,
            MoveLeft,
            JumpStart,
            JumpEnd,
            Idle,
            Hurt,
            Dead
        }
        GlitchState currentGlitchState;
        //Monogame Methods
        public void Initialize()
        {

        }
        public void LoadContent()
        {

        }
        public void Draw()
        {
            switch (currentGlitchState)
            {
                case GlitchState.MoveRight:
                    //Animation
                    break;
                case GlitchState.MoveLeft:
                    //Flip Image
                    break;
                case GlitchState.JumpStart:
                    //JumpBegin
                    break;
                case GlitchState.JumpEnd:
                    //JumpEnd
                    break;
                case GlitchState.Idle:
                    //see if you need a left and right idle
                    break;
                case GlitchState.Hurt:
                    break;
                case GlitchState.Dead:
                    break;
                default:
                    break;
            }
        }
        //Main Methods
        public void Switch()
        {
            switch (currentGlitchState)
            {
                case GlitchState.MoveRight:
                    Move();
                    break;
                case GlitchState.MoveLeft:
                    Move();
                    break;
                case GlitchState.JumpStart:
                    StartJump();
                    break;
                case GlitchState.JumpEnd:
                    EndJump();
                    break;
                case GlitchState.Idle:
                    break;
                case GlitchState.Hurt:
                    break;
                case GlitchState.Dead:
                    break;
                default:
                    break;
            }
        }
        public void Move()
        {
            if (key.IsKeyDown(Keys.Left) == true)
            {
                position.X -= 3;
            }
            if (key.IsKeyDown(Keys.Right) == true)
            {
                position.X += 3;
            }
        }
        public void StartJump()
        {
            if (key.IsKeyDown(Keys.Up) == true)
            {
                JumpTimer.Start();
                currentGlitchState = GlitchState.JumpStart;
                position.Y += 1;
            }
        }
        public void EndJump()
        {
            position.Y -= 1;
            JumpTimer.Stop();
            currentGlitchState = GlitchState.JumpEnd;
        }

    }
}
