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
        /*public virtual void Draw(SpriteBatch spriteBatch)
        {
            //Need to add a sprite effects thing here
            spriteBatch.Draw(skin, position, Color.White);
        }*/

        //Animation Code
        //Fields
        private Texture2D textureImage;
        private int frame;
        private Point frameSize;
        private int numFrames;
        private int timeSinceLastFrame;
        private int millisecondsPerFrame;
        private Point currentFrame;
        private SpriteEffects effect;
        private Vector2 pos;

        // property to change display time
        /*public int MilliseondsPerFrame
        {
            set { millisecondsPerFrame = value; }
        }*/

        // constructor
        /*public Beings(Texture2D img, Point size, int frames, int msPerFrame, SpriteEffects thing, Rectangle p)
        {
            textureImage = img;
            frameSize = size;
            numFrames = frames;
            millisecondsPerFrame = msPerFrame;
            currentFrame.X = 0;
            currentFrame.Y = 0;
            effect = thing;
            
        }*/ 
        public Beings()
        {
            currentFrame.X = 0;
            currentFrame.Y = 0;

        }

        public void Update(GameTime gameTime)
        {
            // check to see if a new frame is needed
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame) // time for a new frame
            {
                timeSinceLastFrame = 0;
                frame++;
                if (frame >= numFrames) // go back to start
                {
                    frame = 0;
                }

                // set the upper left corner of new frame
                currentFrame.X = frameSize.X * frame;
            }
        }

        // called by game1.Draw

            /*
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // draw the correct image
            spriteBatch.Draw(textureImage, // spritesheet
            pos = new Vector2(position.X, position.Y), // where to draw in window
            new Rectangle(currentFrame.X, currentFrame.Y, frameSize.X, frameSize.Y), // pick out a section of spritesheet
            Color.White,
            0, // don't rotate the image
            Vector2.Zero, // rotation center (not used)
            1f, // scaling factor - dont change image size
            effect, // Flip or not
            0  // default layer
            );
        }*/
    }
}