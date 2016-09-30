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
    class Platform
    {
        //Fields
        Timer SpawnTimer;
        Timer MoveTimer;
        SpriteBatch spriteBatch;
        protected Vector2 position;

        //Properties
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        //Constructors
        public Platform()
        {
            SpawnTimer = new Timer();
            SpawnTimer.Interval = 4000;
            SpawnTimer.Elapsed += Despawn;
        }
        private void Despawn(Object source, System.Timers.ElapsedEventArgs e)
        {
            Despawn();
        }
        
        //Other Methods
        public void Spawn()
        {
            SpawnTimer.Start();
        }
        public void Despawn()
        {
            SpawnTimer.Stop();
        }

    }
}
