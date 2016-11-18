using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Glitch_Wobble
{
    public class Health
    {
        protected Texture2D texture;
        protected Rectangle rekt;
        private int x;
        private int y;
        private bool isActive;

        public Health(int x, int y, int width, int height, Texture2D texture)
        {
            rekt = new Rectangle(x, y, width, height);
            isActive = true;
            this.texture = texture;
        }

        public int GetX
        {
            get { return x; }
            set { x = value; }
        }

        public bool GetIsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public int GetY
        {
            get { return y; }
            set { y = value; }
        }

        public void Draw(SpriteBatch sprite)
        {
            if (isActive == true)
                sprite.Draw(texture, rekt, Color.White);
        }

        public Rectangle GetRekt
        {
            get { return rekt; }
            set { rekt = value; }
        }

        public bool CheckCollision(Rectangle rect)
        {
            if (this.rekt.Intersects(rect) == true)
            {
                return true;
            }
            else
                return false;
        }
    }
}
