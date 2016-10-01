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
        protected Rectangle position;
        protected Texture2D skin;

        //Properties
        public Rectangle Position
        {
            get { return position; }
            set { position = value; }
        }
        public Texture2D Skin
        {
            get { return skin; }
            set { skin = value; }
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
        
        //Methods
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
