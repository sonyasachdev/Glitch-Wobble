using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glitch_Wobble
{
    class Camera
    {
        public Matrix transform;
        Viewport view;
        Vector2 center;

        Glitch glitch;

        public Camera(Viewport newView)
        {
            view = newView;
        }

        public void Update(GameTime gameTime)
        {
            center = new Vector2(glitch.Position.X + (glitch.Position.Width / 2) - 400, glitch.Position.Y + (glitch.Position.Height / 2) - 250);
            transform = Matrix.CreateScale(new Vector3(1, 1, 0)) * Matrix.CreateTranslation(new Vector3(-center.X, -center.Y, 0));
        }
    }
}
