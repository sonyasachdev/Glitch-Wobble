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
        protected bool active;
        protected int timesHit;
        
        //Properties
        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
        public int TimesHit
        {
            get { return timesHit; }
            set { timesHit = value; }
        }

        //Constructor
        public Enemy()
        {
            SpawnTimer = new Timer();
            SpawnTimer.Interval = 4000;
            timesHit = 0;
            active = true;
        }

        //Methods
        //Checks Collision
        public bool CheckCollision(Long_Sword weapon)
        {
            if (this.Position.Intersects(weapon.Position) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Makes Enemy despawn
        public void Dead()
        {
            active = false;
        }
    }
}
