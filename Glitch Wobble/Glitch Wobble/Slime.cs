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
    class Slime:Enemy
    {
        //Fields

        //Weapon Initalization
        //Grab what the current position is from main code?
        //Long_Sword longSword = new Long_Sword();
        Rectangle LeftBound;
        Rectangle RightBound;
        SpriteBatch spriteBatch;

        //Constructor
        public Slime(Rectangle p, Texture2D s, bool a,int t)
        {
            this.position = p;
            this.skin = s;
            this.timesHit = t;
            this.active = a;
            LeftBound = new Rectangle(100, 100, 0, 0);
            RightBound = new Rectangle(100, 700, 0, 0);
        }

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
        public void Draw()
        {
            //spriteBatch.Draw(ski, pos, w);
            
            switch (currentSlimeState)
            {
                case SlimeState.MoveLeft:
                    SlimeIdle(SpriteEffects.FlipHorizontally);
                    break;
                case SlimeState.MoveRight:
                    SlimeIdle(SpriteEffects.None);
                    break;
                case SlimeState.Hurt:
                    //Hurt Animation
                    break;
                case SlimeState.Dead:
                    //Dead Animation
                    break;
            }
        }

        //Methods
        public void Switch()
        {
            switch (currentSlimeState)
            {
                case SlimeState.MoveLeft:
                    MoveLeft(RightBound);
                    break;
                case SlimeState.MoveRight:
                    MoveRight(LeftBound);
                    break;
                case SlimeState.Hurt:
                    //Hurt();
                    break;
                case SlimeState.Dead:
                    //Code for this method is in enemy
                    Dead();
                    break;
            }
        }
        //Takes count how many times hitbox has been touched by the weapon's attack state
        /*public void Hurt()
        {
            if (CheckCollision(longSword) == true)
            {
                if (timesHit < 2)
                {
                    timesHit++;
                }
                else
                {
                    Dead();
                }
            }
        }*/
        //Basic AI Code that makes it go left and right
        public void MoveRight(Rectangle pos)
        {
            while (position.X <= pos.X)
            {
                position.X += 1;
            }
            if (position.X == pos.X)
            {
                currentSlimeState = SlimeState.MoveLeft;
            }
        }
        public void MoveLeft(Rectangle pos)
        {
            while (position.X >= pos.X)
            {
                position.X -= 1;
            }
            if (position.X == pos.X)
            {
                currentSlimeState = SlimeState.MoveRight;
            }
        }

        /*
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
        private void SlimeIdle(SpriteEffects flipSprite)
        {
            spriteBatch.Draw(Skin, new Vector2(0,0), Position, Color.White, 0, Vector2.Zero, 1.0f, flipSprite, 0);
        }

    }
}
