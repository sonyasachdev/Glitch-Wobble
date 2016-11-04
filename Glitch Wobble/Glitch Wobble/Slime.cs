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
    enum SlimeState
    {
        MoveLeft,
        MoveRight,
        IdleLeft,
        IdleRight,
        Hurt,
        Dead
    }
    public class Slime:Enemy
    {
        //Enum Variables
        SlimeState currentSlimeState;
        SlimeState previousSlimeState;

        //Fields
        Rectangle LeftBound;
        Rectangle RightBound;
        Timer hurtTimer;
        Texture2D slimeSkin;
        SpriteEffects flip;

        //Constructor
        public Slime(Rectangle p, bool a,int t)
        {
            this.position = p;
            this.timesHit = t;
            this.active = a;
            LeftBound = new Rectangle(100, 100, 10, 10);
            RightBound = new Rectangle(700, 100, 10, 10);
            currentSlimeState = SlimeState.MoveRight;

            flip = SpriteEffects.FlipHorizontally;
            previousSlimeState = currentSlimeState;
           
            //At the end of the hurt animation, it will revert to the previous Slime State it was in (Moving left or right)
            hurtTimer = new Timer();
            hurtTimer.Interval = 2000;
            hurtTimer.Elapsed += HurtTimerState;

            
        }
        //Timer Function
        
        private void HurtTimerState(Object source, System.Timers.ElapsedEventArgs e)
        {
            currentSlimeState = previousSlimeState;
        }

        //Monogame Methods
        public void Initialize()
        {
            currentSlimeState = SlimeState.MoveRight;
        }
        public void LoadContent(ContentManager Content)
        {
            slimeSkin = Content.Load<Texture2D>("Slime-Sheet.png");
            //sprite = new Sprite(slimeSkin, new Point(108, 108), 4, 45, flip, position);
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (active == true)
            {
                switch (currentSlimeState)
                {
                    case SlimeState.MoveLeft:
                        //see how to flip the image
                        flip = SpriteEffects.None;
                        //sprite.Draw(gameTime, spriteBatch);
                        //spriteBatch.Draw(slimeSkin, position, Color.White);
                        //Draw(spriteBatch);
                        break;
                    case SlimeState.MoveRight:
                        //Draw(spriteBatch);
                        flip = SpriteEffects.FlipHorizontally;
                        //sprite.Draw(gameTime, spriteBatch);
                        //spriteBatch.Draw(slimeSkin, position, Color.White);
                        break;
                    case SlimeState.Hurt:
                        //Hurt Animation
                        break;
                    case SlimeState.Dead:
                        //Dead Animation
                        break;
                }
            }
            //else, it won't draw
        }

        //Methods
        public void Switch(GameTime gameTime)
        {
            //sprite.Update(gameTime);
            switch (currentSlimeState)
            {
                case SlimeState.MoveLeft:
                    //face = false;
                    MoveLeft(LeftBound);
                    break;
                case SlimeState.MoveRight:
                    //face = true;
                    MoveRight(RightBound);
                    break;
                case SlimeState.Hurt:
                    //Add the timer in here
                    break;
                case SlimeState.Dead:
                    //Code for this method is in enemy
                    Dead();
                    break;
            }
        }

        //Basic AI Code that makes it go left and right
        public void MoveRight(Rectangle RightBound)
        {
            if (position.X < RightBound.X)
            {
                position.X += 3;
            }
            else if (position.X >= RightBound.X)
            {
                currentSlimeState = SlimeState.MoveLeft;
            }
        }
        public void MoveLeft(Rectangle LeftBound)
        {
            if (position.X > LeftBound.X)
            {
                position.X -= 3;
            }
            else if (position.X <= LeftBound.X)
            {
                currentSlimeState = SlimeState.MoveRight;
            }
        }

        public void Hurt(Long_Sword longsword)
        {
            if (this.Position.Intersects(longsword.Position) == true)
            {
                if (timesHit < 2)
                {
                    timesHit++;
                    //set a timer that makes the slime hurt for 1-2 seconds
                    currentSlimeState = SlimeState.Hurt;
                }
                else
                {
                    Dead();
                }
            }
        }

        /*
        //Takes count how many times hitbox has been touched by the weapon's attack state
        //maybe make this return a bool so that with the timer, it will know if the slime was hurt. If true, set state to hurt, if false, set state to dead.
        public bool? Hurt(Long_Sword longSword)
        {
            if (this.Position.Intersects(longSword.Position) == true)
            {
                if (timesHit < 2)
                {
                    timesHit++;
                    //set a timer that makes the slime hurt for 1-2 seconds
                    currentSlimeState = SlimeState.Hurt;
                    isHurt = true;
                    return isHurt;
                }
                else
                {
                    Dead();
                    isHurt = false;
                    return isHurt;
                }
            }
            else
            {
                isHurt = null;
                return isHurt;
            }
        }

        //Ask Steve how to handle this code, how to bring the position of the current Long Sword Rectangle into this class.
        public void ChangeState(bool? hurt)
        {
            if (Hurt() == true)
            {
                currentSlimeState = SlimeState.Hurt;
            }
            else if (Hurt() == false)
            {
                currentSlimeState = SlimeState.Dead;
            }
            else if (Hurt() == null && currentSlimeState == SlimeState.MoveLeft)
            {
                //might modify code to do nothing and make this blank, if problems arise.
                currentSlimeState = SlimeState.MoveLeft;
            }
            else if (Hurt() == null && currentSlimeState == SlimeState.MoveRight)
            {
                //might modify code to do nothing and make this blank, if problems arise.
                currentSlimeState = SlimeState.MoveRight;
            }
        }
        */


        /*
        private void SlimeIdle(SpriteEffects flipSprite)
        {
            spriteBatch.Draw(Skin, new Vector2(0, 0), Position, Color.White, 0, Vector2.Zero, 1.0f, flipSprite, 0);
        }
        
        */


    }
}
