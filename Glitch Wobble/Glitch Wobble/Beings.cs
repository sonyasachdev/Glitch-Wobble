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
    public class Beings
    {
        //Fields
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

        //Methods
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(skin, position, Color.White);
        }
    }
}
