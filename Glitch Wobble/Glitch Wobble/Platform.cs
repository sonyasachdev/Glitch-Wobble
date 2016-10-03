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
        protected bool active;

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
        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        //Constructors
        public Platform()
        {
            SpawnTimer = new Timer();
            SpawnTimer.Interval = 4000;
            SpawnTimer.Elapsed += Despawn;
            active = true;
        }
        private void Despawn(Object source, System.Timers.ElapsedEventArgs e)
        {
            Despawn();
        }
        
        //Methods
        public void Spawn()
        {
            SpawnTimer.Start();
            active = true;
        }
        public void Despawn()
        {
            SpawnTimer.Stop();
            active = false;
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(skin, position, Color.White);
        }
    }
}
