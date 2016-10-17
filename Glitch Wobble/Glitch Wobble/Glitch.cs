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
    //Glitch State
    public enum GlitchState
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

    public enum keyState
    {
        MoveRight,
        MoveLeft,
        JumpStart,
        JumpEnd,
        IdleLeft,
        IdleRight
    }

    class Glitch : Beings
    {
        //Fields
        Timer jumpTimer;
        SpriteBatch spriteBatch;
        KeyboardState key;
        KeyboardState previousKeyState;
        private int lives;

        //Texture
        Texture2D glitchSkin;

        //Enum Variables
        GlitchState currentGlitchState;
        GlitchState previousGlitchState;
        keyState currentKeyState;

        //Properties
        public int Lives
        {
            get { return lives; }
            set { lives = value; }
        }

        //Constructor
        public Glitch ()
        {
            jumpTimer = new Timer();
            jumpTimer.Interval = 2000;
            jumpTimer.Elapsed += EndJump;
            this.position = new Rectangle(0, 0, 100, 100);
            lives = 3;
            //glitchSkin = skin;
            //skin = glitchSkin;
        }

        //Timer Function
        private void EndJump(Object source, System.Timers.ElapsedEventArgs e)
        {
            EndJump();
        }
        
        //Monogame Methods
        public void Initialize()
        {
            currentGlitchState = GlitchState.IdleRight;
        }
        public void LoadContent(ContentManager Content)
        {
            glitchSkin = Content.Load<Texture2D>("glitchSkin.png");
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            
            switch (currentGlitchState)
            {
                case GlitchState.MoveRight:
                    //Animation
                    //PlayerImage(SpriteEffects.None);
                    spriteBatch.Draw(glitchSkin, position, Color.White);
                    break;
                case GlitchState.MoveLeft:
                    //Flip Image using SpriteEffects
                    //PlayerImage(SpriteEffects.FlipHorizontally);
                    //Have the Fliphorizontal in Beings class, and have it inherit. Maybe make a 2nd drawmethod?
                    spriteBatch.Draw(glitchSkin, position, Color.White);
                    //Draw(spriteBatch);
                    break;
                case GlitchState.JumpStart:
                    //JumpBegin
                   // Draw(spriteBatch);
                    break;
                case GlitchState.JumpEnd:
                    //JumpEnd
                 //   Draw(spriteBatch);
                    break;
                case GlitchState.IdleLeft:
                    //    Draw(spriteBatch);
                    spriteBatch.Draw(glitchSkin, position, Color.White);
                    break;
                case GlitchState.IdleRight:
                    //    Draw(spriteBatch);
                    spriteBatch.Draw(glitchSkin, position, Color.White);
                    break;
                case GlitchState.Hurt:
                    //Put hurt animation, also reduce the GUI hearts by one
                    break;
                case GlitchState.Dead:
                    //Run dead animation and change state to GameOver
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
                    //Run dead animation and change state to GameOver
                    Game1.currentGameState = GameState.GameOver;
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
    }
}
