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
        protected SpriteBatch spriteBatch;
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
            //Despawn();
        }
        
        //Methods
        /*
        public void Spawn()
        {
            SpawnTimer.Start();
            spriteBatch = LoadContent(Content);
            active = true;
        }
        public void Despawn()
        {
            SpawnTimer.Stop();
            spriteBatch = null;
            active = false;
        }
        

        public void PlatBeat()
        {
            int i = 1;

            if(i == 1)
            {
                Despawn();

                i++;
            } else if (i == 2)
            {
                Spawn();

                i--;
            }
        }
        
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(skin, position, Color.White);
        }*/
    }
}
