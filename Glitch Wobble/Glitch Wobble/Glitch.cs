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
        Jump,
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
        Timer startJumpTimer1;
        Timer startJumpTimer2;
        Timer startJumpTimer3;
        Timer endJumpTimer;
        SpriteBatch spriteBatch;
        KeyboardState key;
        KeyboardState previousKeyState;
        private int lives;
        private bool jump1;
        private bool jump2;
        private bool jump3;

        //Texture
        Texture2D glitchSkin;

        Vector2 velocity;
        bool hasJumped;

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
        public Glitch()
        {
            //Jump Timer
            /*startJumpTimer1 = new Timer();
            startJumpTimer1.Interval = 250;
            startJumpTimer1.Elapsed += slowJump1;

            startJumpTimer2 = new Timer();
            startJumpTimer2.Interval = 250;
            startJumpTimer2.Elapsed += slowJump2;

            startJumpTimer3 = new Timer();
            startJumpTimer3.Interval = 250;
            startJumpTimer3.Elapsed += switchJump; 

            endJumpTimer = new Timer();
            endJumpTimer.Interval = 750;
            endJumpTimer.Elapsed += EndJump; */

            //Setting Previous GlitchState
            previousGlitchState = currentGlitchState;

            //Setting Start Position
            this.position = new Rectangle(0, 200, 125, 250);
            lives = 3;

            //Setting the jump bools
            jump1 = false;
            jump2 = false;
            jump3 = false;

            hasJumped = true;
        }

        //Timer Function
        /*private void slowJump1(Object source, System.Timers.ElapsedEventArgs e)
        {
            startJumpTimer1.Stop();
            StartJump2();
        }
        private void slowJump2(Object source, System.Timers.ElapsedEventArgs e)
        {
            startJumpTimer2.Stop();
            StartJump3();
        }

        private void switchJump(Object source, System.Timers.ElapsedEventArgs e)
        {
            startJumpTimer3.Stop();
            currentGlitchState = GlitchState.JumpEnd;
        }
        private void EndJump(Object source, System.Timers.ElapsedEventArgs e)
        {
            endJumpTimer.Stop();
            currentGlitchState = previousGlitchState;
        } */

        //Monogame Methods
        public void Initialize()
        {
            currentGlitchState = GlitchState.IdleRight;
        } 
        public void LoadContent(ContentManager Content)
        {
            glitchSkin = Content.Load<Texture2D>("glitchSkin.jpg");
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
                    spriteBatch.Draw(glitchSkin, position, Color.White);
                    //Draw(spriteBatch);
                    break;
                case GlitchState.Jump:
                    // Draw(spriteBatch);
                    spriteBatch.Draw(glitchSkin, position, Color.White);
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
                case GlitchState.Jump:
                    Jump();
                    //StartJump1();
                    break;
                /*case GlitchState.JumpEnd:
                    //  EndJump();
                    break;*/
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

        //Jump
        /*public void StartJump1()
        {
            if (jump1 == false)
            {
                jump1 = true;
                startJumpTimer1.Start();

                //Arc Logic
                position.Y -= 10;
                //Trying to get a loop to work so that it's moving smoothly
                //Makes sure you can still move while Jumping
                if (key.IsKeyDown(Keys.Right) == true)
                {
                    position.X += 7;
                }
                else if (key.IsKeyDown(Keys.Left) == true)
                {
                    position.X -= 7;
                }
            }
        }

        public void StartJump2()
        {
            if (jump2 == false)
            {
                jump2 = true;
                startJumpTimer2.Start();

                //Arc Logic
                position.Y -= 5;

                //Makes sure you can still move while Jumping
                if (key.IsKeyDown(Keys.Right) == true)
                {
                    position.X += 7;
                }
                else if (key.IsKeyDown(Keys.Left) == true)
                {
                    position.X -= 7;
                }
            }
        }

        public void StartJump3()
        {
            if (jump3 == false)
            {
                jump3 = true;
                startJumpTimer3.Start();

                //Arc Logic
                position.Y -= 3;

                //Makes sure you can still move while Jumping
                if (key.IsKeyDown(Keys.Right) == true)
                {
                    position.X += 7;
                }
                else if (key.IsKeyDown(Keys.Left) == true)
                {
                    position.X -= 7;
                }
            }
            
        }



        public void EndJump()
        {
            endJumpTimer.Start();

            Rectangle temp = new Rectangle();
            temp.Y = position.Y;

            //Arc Logic
            if (position.Y > temp.Y - 5)
            {
                position.Y += 10;
            }
            else if (position.Y > temp.Y - 8)
            {
                position.Y += 5;
            }
            else if (position.Y > temp.Y - 9)
            {
                position.Y += 2;
            }

            //Makes sure you can still move while Jumping
            if (key.IsKeyDown(Keys.Right) == true)
            {
                position.X += 7;
            }
            else if (key.IsKeyDown(Keys.Left) == true)
            {
                position.X -= 7;
            }
        } */

        public void Jump()
        {
            position.X += (int)velocity.X;
            position.Y += (int)velocity.Y;

            if (Keyboard.GetState().IsKeyDown(Keys.Up) && hasJumped == false)
            {
                position.Y -= 10;
                velocity.Y = -18f;
                hasJumped = true;
            }

            if (hasJumped == true)
            {
                float i = 1;
                velocity.Y += 0.65f * i;
            }

            if (position.Y + glitchSkin.Height >= 900)
                hasJumped = false;

            if (hasJumped == false)
                velocity.Y = 0f;
        }

        //Movement
        public void Move()
        {
            previousKeyState = key;
            key = Keyboard.GetState();
            
            if (key.IsKeyDown(Keys.Right) == true)
            {
                currentGlitchState = GlitchState.MoveRight;
                position.X += 7;
            }
            else if (key.IsKeyDown(Keys.Left) == true)
            {
                currentGlitchState = GlitchState.MoveLeft;
                position.X -= 7;
            }

            if (previousKeyState.IsKeyUp(Keys.Left) == true && key.IsKeyDown(Keys.Right) == false)
            {
                currentGlitchState = GlitchState.IdleLeft;
            }
            else if (previousKeyState.IsKeyUp(Keys.Right) == true && key.IsKeyDown(Keys.Left) == false)
            {
                currentGlitchState = GlitchState.IdleRight;
            }
            //Makes character Jump
            if(key.IsKeyDown(Keys.Up))
            {
                currentGlitchState = GlitchState.Jump;
            } 
        }
        //Enemy Body Collision Code
        public void GlitchHurt(Slime slime)
        {
            //You need to add a cooldown between when the slime hits the player and when she can next be hit by a slime, or it ends immediately
            //Probably need to add a timer.

            //See if you have to put the draw logic in this method?
            if (position.Intersects(slime.Position) == true)
            {
                if (Lives < 4 && Lives > 0)
                {
                    Lives--;
                }
                else if (Lives == 0)
                {
                    Game1.currentGameState = GameState.GameOver;
                }
            }
        }


    }
}
