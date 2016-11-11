using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Timers;
using Microsoft.Xna.Framework.Content;

namespace Glitch_Wobble
{
    class Ground:Platform
    {
        //Fields

        //Constructor
        public Ground()
        {
            position = new Rectangle(0, 260, 1000, 500);
            hitbox = new Rectangle(position.X, position.Y+330 , 1000, 190);
            active = true;
        }

        //Methods
        public void Initialize()
        {

        }
        public void LoadContent(ContentManager Content)
        {
            skin = Content.Load<Texture2D>("Ground-1.png");
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(skin, position, Color.White);
        }
    }
}
