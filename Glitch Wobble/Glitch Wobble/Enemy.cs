﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Timers;
using Microsoft.Xna.Framework.Content;

namespace Glitch_Wobble
{
    public class Enemy : Beings
    {
        //Fields
        Timer SpawnTimer;
        protected bool active;
        protected int timesHit;
        protected Rectangle hitbox;
        
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
        public Rectangle Hitbox
        {
            get { return hitbox; }
            set { hitbox = value; }
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
        //Makes Enemy despawn
        public void Dead()
        {
            active = false;
        }
    }
}
