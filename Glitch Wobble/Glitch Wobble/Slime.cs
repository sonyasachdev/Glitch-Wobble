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
        Long_Sword longSword = new Long_Sword();

        //Constructor
        public Slime(Rectangle p, Texture2D s, int t)
        {
            this.position = p;
            this.skin = s;
            this.timesHit = t;
        }

        //SlimeStates
        enum SlimeState
        {
            Left,
            Right,
            Hurt,
            Dead
        }
        SlimeState currentEnemyState;

        //Monogame Methods
        public void Initialize()
        {

        }
        public void LoadContent()
        {

        }
        public void Draw()
        {
            //SpriteBatch.Begin();
            switch (currentEnemyState)
            {
                case SlimeState.Left:
                    //Move Animation
                    break;
                case SlimeState.Right:
                    //Move Animation
                    break;
                case SlimeState.Hurt:
                    //Hurt Animation
                    break;
                case SlimeState.Dead:
                    //Dead Animation
                    break;
            }
            //SpriteBatch.End();
        }

        //Methods
        public void Switch()
        {
            switch (currentEnemyState)
            {
                case SlimeState.Left:
                    MoveLeft(position);
                    break;
                case SlimeState.Right:
                    MoveRight(position);
                    break;
                case SlimeState.Hurt:
                    Hurt();
                    break;
                case SlimeState.Dead:
                    Dead();
                    break;
            }
        }
        //Takes count how many times hitbox has been touched by the weapon's attack state
        public void Hurt()
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
        }
        //Basic AI Code that makes it go left and right
        public void MoveRight(Rectangle pos)
        {
            while (position.X <= pos.X)
            {
                position.X += 1;
            }
            if (position.X == pos.X)
            {
                currentEnemyState = SlimeState.Left;
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
                currentEnemyState = SlimeState.Right;
            }
        }
    }
}
