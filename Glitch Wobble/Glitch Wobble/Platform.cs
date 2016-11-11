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
    public class Platform
    {
        //Fields
        Timer SpawnTimer;
        Timer MoveTimer;
        protected SpriteBatch spriteBatch;
        protected Rectangle position;
        protected Rectangle hitbox;
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
        public Rectangle Hitbox
        {
            get { return hitbox; }
            set { hitbox = value; }
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
            SpawnTimer.Interval = 2000;
            SpawnTimer.Elapsed += Despawn;
            Active = true;
        }
        private void Despawn(Object source, System.Timers.ElapsedEventArgs e)
        {
            Despawn();
        }

        private void Spawn(Object source, System.Timers.ElapsedEventArgs e)
        {
            Spawn();
        }
        
        //Methods
        public void Spawning()
        {
            if(Active == true)
            {
                SpawnTimer.Elapsed += Despawn;
            } else
            {
                SpawnTimer.Elapsed += Spawn;
            }
        }
        public void Despawn()
        {
            SpawnTimer.Stop();
            Active = false;
        }

        public void Spawn()
        {
            SpawnTimer.Start();
            Active = true;
        }
        
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Active == true) {
                spriteBatch.Draw(skin, position, Color.White);
            }
        }
    }
}
