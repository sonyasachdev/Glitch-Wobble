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
    public class Slime:Enemy
    {
        //Fields
        Rectangle LeftBound;
        Rectangle RightBound;
        SpriteBatch spriteBatch;
        Timer hurtTimer;
        bool? isHurt;

        //Constructor
        public Slime(Rectangle p, Texture2D s, bool a,int t)
        {
            this.position = p;
            this.skin = s;
            this.timesHit = t;
            this.active = a;
            LeftBound = new Rectangle(100, 100, 10, 10);
            RightBound = new Rectangle(700, 100, 10, 10);
            isHurt = null;
            currentSlimeState = SlimeState.MoveRight;
            /*
            hurtTimer = new Timer();
            hurtTimer.Interval = 2000;
            hurtTimer.Elapsed += ChangeState;*/
        }
        //Timer Function
        /*
        private void ChangeState(Object source, System.Timers.ElapsedEventArgs e)
        {
            ChangeState(isHurt);
        }
        */

        //SlimeStates
        enum SlimeState
        {
            MoveLeft,
            MoveRight,
            //IdleLeft,
            //IdleRight,
            Hurt,
            Dead
        }
        SlimeState currentSlimeState;

        //Monogame Methods
        public void Initialize()
        {
            currentSlimeState = SlimeState.MoveRight;
        }
        public void LoadContent()
        {
            
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (active == true)
            {
                switch (currentSlimeState)
                {
                    case SlimeState.MoveLeft:
                        //SlimeIdle(SpriteEffects.FlipHorizontally);
                        base.Draw(spriteBatch);
                        break;
                    case SlimeState.MoveRight:
                        //SlimeIdle(SpriteEffects.None);
                        base.Draw(spriteBatch);
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
        public void Switch()
        {
            switch (currentSlimeState)
            {
                case SlimeState.MoveLeft:
                    MoveLeft(LeftBound);
                    break;
                case SlimeState.MoveRight:
                    MoveRight(RightBound);
                    break;
                case SlimeState.Hurt:
                    break;
                case SlimeState.Dead:
                    //Code for this method is in enemy
                    Dead();
                    break;
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

        //Basic AI Code that makes it go left and right
        public void MoveRight(Rectangle RightBound)
        {
            if (position.X < RightBound.X)
            {
                position.X += 10;
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
                position.X -= 10;
            }
            else if (position.X <= LeftBound.X)
            {
                currentSlimeState = SlimeState.MoveRight;
            }
        }
        /*
        private void SlimeIdle(SpriteEffects flipSprite)
        {
            spriteBatch.Draw(Skin, new Vector2(0, 0), Position, Color.White, 0, Vector2.Zero, 1.0f, flipSprite, 0);
        }
        
        public void Move(Vector2 start, Vector2 end)
        {
            //right
            while (position.X <= end.X)
            {
                position.X += 1;
            }
            //left
            while (position.X >= start.X)
            {
                position.X -= 1;
            }
        }
        */


    }
}
