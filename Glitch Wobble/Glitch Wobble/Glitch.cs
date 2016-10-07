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
    class Glitch : Beings
    {
        //Fields
        Timer jumpTimer;
        SpriteBatch spriteBatch;
        KeyboardState key;
        KeyboardState previousKeyState;
        Rectangle hitBox;
        private int lives;

        Texture2D glitchSkin;
        Rectangle glitchPos;

        //Properties
        public int Lives
        {
            get { return lives; }
            set { lives = value; }
        }

        //Constructor
        public Glitch (Rectangle p)
        {
            this.position = p;
            jumpTimer = new Timer();
            jumpTimer.Interval = 2000;
            jumpTimer.Elapsed += EndJump;
            lives = 3;
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
            IdleLeft,
            IdleRight,
            Hurt,
            Dead
        }
        GlitchState currentGlitchState;

        enum keyState
        {
            MoveRight,
            MoveLeft,
            JumpStart,
            JumpEnd,
            IdleLeft,
            IdleRight
        }
        keyState currentKeyState;
        //Monogame Methods
        public void Initialize()
        {
            currentGlitchState = GlitchState.IdleRight;
        }
        public void LoadContent(ContentManager Content)
        {
            glitchSkin = Content.Load<Texture2D>("glitchSkin.png");
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            
            switch (currentGlitchState)
            {
                case GlitchState.MoveRight:
                    //Animation
                    //PlayerImage(SpriteEffects.None);
                    base.Draw(spriteBatch);
                    break;
                case GlitchState.MoveLeft:
                    //Flip Image using SpriteEffects
                    //PlayerImage(SpriteEffects.FlipHorizontally);
                    base.Draw(spriteBatch);
                    break;
                case GlitchState.JumpStart:
                    //JumpBegin
                    base.Draw(spriteBatch);
                    break;
                case GlitchState.JumpEnd:
                    //JumpEnd
                    base.Draw(spriteBatch);
                    break;
                case GlitchState.IdleLeft:
                    base.Draw(spriteBatch);
                    break;
                case GlitchState.IdleRight:
                    base.Draw(spriteBatch);
                    break;
                case GlitchState.Hurt:
                    break;
                case GlitchState.Dead:
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
                case GlitchState.IdleLeft:
                    Move();
                    break;
                case GlitchState.IdleRight:
                    Move();
                    break;
                case GlitchState.Hurt:
                    break;
                case GlitchState.Dead:
                    break;
            }
        }
        //Movement
        public void Move()
        {
            previousKeyState = key;
            key = Keyboard.GetState();
            
            if (key.IsKeyDown(Keys.Right) == true)
            {
                currentGlitchState = GlitchState.MoveRight;
                position.X += 3;
            }
            else if (key.IsKeyDown(Keys.Left) == true)
            {
                currentGlitchState = GlitchState.MoveLeft;
                position.X -= 3;
            }

            if (previousKeyState.IsKeyUp(Keys.Left) == true && key.IsKeyDown(Keys.Right) == false)
            {
                currentGlitchState = GlitchState.IdleLeft;
            }
            else if (previousKeyState.IsKeyUp(Keys.Right) == true && key.IsKeyDown(Keys.Left) == false)
            {
                currentGlitchState = GlitchState.IdleRight;
            }
        }
        //Jump
        public void StartJump()
        {
            if (key.IsKeyDown(Keys.Up) == true)
            {
                jumpTimer.Start();
                currentGlitchState = GlitchState.JumpStart;
                position.Y += 1;
            }
        }
        public void EndJump()
        {
            position.Y -= 1;
            jumpTimer.Stop();
            currentGlitchState = GlitchState.JumpEnd;
        }
        /*
        private void PlayerImage(SpriteEffects flipSprite)
        {
            spriteBatch.Draw(Skin, new Vector2(0, 0), Position, Color.White, 0, Vector2.Zero, 1.0f, flipSprite, 0);
        }
        */
        //Hurt Code is in main method because it needs to change the gamestate
    }
}
