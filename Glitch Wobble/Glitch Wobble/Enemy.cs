using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Timers;

namespace Glitch_Wobble
{
    class Enemy : Beings
    {
        //Fields
        Timer SpawnTimer;
        int timesHit;

        //Constructor
        public Enemy(Vector2 p)
        {
            this.position = p;
            SpawnTimer = new Timer();
            SpawnTimer.Interval = 4000;
            timesHit = 0;
        }
        //SlimeStates
        enum SlimeState
        {
            Move,
            Hurt,
            Dead
        }
        SlimeState currentEnemyState;

        //Monogame Methods
        public void Initialize()
        {

        }
        public void Draw()
        {
            switch (currentEnemyState)
            {
                case SlimeState.Move:
                    //Move Animation
                    break;
                case SlimeState.Hurt:
                    //Hurt Animation
                    break;
                case SlimeState.Dead:
                    //Dead Animation
                    break;
                default:
                    break;
            }
        }

        //Methods
        public void Switch()
        {
            switch (currentEnemyState)
            {
                case SlimeState.Move:

                    break;
                case SlimeState.Hurt:
                    Hurt();
                    break;
                case SlimeState.Dead:
                    Dead();
                    break;
                default:
                    break;
            }
        }
        public void Hurt()
        {
            
        }
        public void Dead()
        {

        }
    }
}
