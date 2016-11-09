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
    //Glitch State
    public enum GlitchState
    {
        MoveRight,
        MoveLeft,
        Jump,
        IdleLeft,
        IdleRight,
        Hurt,
        Dead
    }

    public enum keyState
    {
        MoveRight,
        MoveLeft,
        JumpStart,
        JumpEnd,
        IdleLeft,
        IdleRight
    }

    class Glitch : Beings
    {
        //Fields
        SpriteBatch spriteBatch;
        KeyboardState key;
        KeyboardState previousKeyState;
        private int lives;
        private Rectangle hitbox;

        //Animation Fields
        Vector2 pos;
        private Point currentFrame;
        private Point frameSize;
        private int frame;
        private int numFrames;
        private int timeSinceLastFrame;
        private int frameRate;
        SpriteEffects flip;

        //Texture
        Texture2D glitchSkin;
        Texture2D hitboxSkin;

        //Jump Fields
        Vector2 velocity;
        bool hasJumped;

        //Enum Variables
        GlitchState currentGlitchState;
        GlitchState previousGlitchState;
        keyState currentKeyState;

        //Properties
        public int Lives
        {
            get { return lives; }
            set { lives = value; }
        }

        public Rectangle Hitbox
        {
            get { return hitbox; }
            set { hitbox = value; }
        }

        //Constructor
        public Glitch()
        { 
            //Setting Previous GlitchState
            previousGlitchState = currentGlitchState;

            currentGlitchState = GlitchState.IdleRight;
            //Setting Hitbox
            hitbox = new Rectangle(position.X, position.Y, 100, 400);
            //Setting Start Position
            this.position = new Rectangle(0, 200, 400, 400);
            lives = 3;

            hasJumped = false;

            //Animation Initializers
            frameSize.X = 1000;
            frameSize.Y = 1000;
            currentFrame.X = 0;
            currentFrame.Y = 0;
            numFrames = 1;
            frameRate = 100;
            flip = SpriteEffects.FlipHorizontally;

        }

        //Monogame Methods
        public void Initialize()
        {
            currentGlitchState = GlitchState.IdleRight;
        } 
        public void LoadContent(ContentManager Content)
        {
            glitchSkin = Content.Load<Texture2D>("glitchSkin.png");
            hitboxSkin = Content.Load <Texture2D>("playactive.png");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(hitboxSkin, position, Color.White);
            spriteBatch.Draw(hitboxSkin, hitbox, Color.White);
            
            
            switch (currentGlitchState)
            {
                case GlitchState.MoveRight:
                    //Flips Image
                    flip = SpriteEffects.FlipHorizontally;

                    spriteBatch.Draw(glitchSkin, // SpriteSheet
                        pos = new Vector2(position.X, position.Y), // position of slime
                        new Rectangle(currentFrame.X, currentFrame.Y, frameSize.X, frameSize.Y), // size of frame in spritesheet
                        Color.White,
                        0, // don't rotate the image
                        Vector2.Zero, // rotation center (not used)
                        .4f, // scaling factor - dont change image size
                        flip, // Flip or not
                        0//Current Layer
                        );
                    //spriteBatch.Draw(glitchSkin, position, Color.White);
                    break;
                case GlitchState.MoveLeft:

                    flip = SpriteEffects.None;

                    spriteBatch.Draw(glitchSkin, // SpriteSheet
                        pos = new Vector2(position.X, position.Y), // position of slime
                        new Rectangle(currentFrame.X, currentFrame.Y, frameSize.X, frameSize.Y), // size of frame in spritesheet
                        Color.White,
                        0, // don't rotate the image
                        Vector2.Zero, // rotation center (not used)
                        .4f, // scaling factor - dont change image size
                        flip, // Flip or not
                        0//Current Layer
                        );
                    //spriteBatch.Draw(glitchSkin, position, Color.White);
                    break;
                case GlitchState.Jump:

                    spriteBatch.Draw(glitchSkin, // SpriteSheet
                        pos = new Vector2(position.X, position.Y), // position of slime
                        new Rectangle(currentFrame.X, currentFrame.Y, frameSize.X, frameSize.Y), // size of frame in spritesheet
                        Color.White,
                        0, // don't rotate the image
                        Vector2.Zero, // rotation center (not used)
                        .4f, // scaling factor - dont change image size
                        flip, // Flip or not
                        0//Current Layer
                        );
                    //spriteBatch.Draw(glitchSkin, position, Color.White);
                    break;
                case GlitchState.IdleLeft:
                    flip = SpriteEffects.None;

                    spriteBatch.Draw(glitchSkin, // SpriteSheet
                        pos = new Vector2(position.X, position.Y), // position of slime
                        new Rectangle(currentFrame.X, currentFrame.Y, frameSize.X, frameSize.Y), // size of frame in spritesheet
                        Color.White,
                        0, // don't rotate the image
                        Vector2.Zero, // rotation center (not used)
                        .4f, // scaling factor - dont change image size
                        flip, // Flip or not
                        0//Current Layer
                        );
                    //spriteBatch.Draw(glitchSkin, position, Color.White);
                    break;
                case GlitchState.IdleRight:
                    flip = SpriteEffects.FlipHorizontally;

                    spriteBatch.Draw(glitchSkin, // SpriteSheet
                        pos = new Vector2(position.X, position.Y), // position of slime
                        new Rectangle(currentFrame.X, currentFrame.Y, frameSize.X, frameSize.Y), // size of frame in spritesheet
                        Color.White,
                        0, // don't rotate the image
                        Vector2.Zero, // rotation center (not used)
                        .4f, // scaling factor - dont change image size
                        flip, // Flip or not
                        0//Current Layer
                        );
                    //spriteBatch.Draw(glitchSkin, position, Color.White);
                    break;
                case GlitchState.Hurt:
                    //Put hurt animation, also reduce the GUI hearts by one
                    break;
                case GlitchState.Dead:
                    //Run dead animation and change state to GameOver
                    break;
            }
        }
        //Main Methods
        public void Switch(GameTime gameTime)
        {
            //Dynamically sets hitbox
            hitbox.X = position.X;
            hitbox.Y = position.Y;

            //Animation Logic
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > frameRate) // time for a new frame
            {
                timeSinceLastFrame = 0;
                frame++;

                //Resets Animation Loop
                if (frame >= numFrames)
                {
                    frame = 0;
                }

                // set the upper left corner of new frame
                currentFrame.X = frameSize.X * frame;
            }

            //Gamestate Switch logic
            switch (currentGlitchState)
            {
                case GlitchState.MoveRight:
                    Move();
                    break;
                case GlitchState.MoveLeft:
                    Move();
                    break;
                case GlitchState.Jump:
                    Jump();
                    Move();
                    break;
                case GlitchState.IdleLeft:
                    Move();
                    break;
                case GlitchState.IdleRight:
                    Move();
                    break;
                case GlitchState.Hurt:
                    break;
                case GlitchState.Dead:
                    //Run dead animation and change state to GameOver
                    Game1.currentGameState = GameState.GameOver;
                    break;
            }
        }

        public void Jump()
        {
            position.X += (int)velocity.X;
            position.Y += (int)velocity.Y;

            if (Keyboard.GetState().IsKeyDown(Keys.Up) && hasJumped == false)
            {
                position.Y -= 10;
                velocity.Y = -18f;
                hasJumped = true;
            }

            if (hasJumped == true)
            {
                float i = 1;
                velocity.Y += 0.65f * i;
            }

            if (position.Y + 250 >= 500)
                hasJumped = false;

            if (hasJumped == false)
                velocity.Y = 0f;
        }

        //Movement
        public void Move()
        {
            previousKeyState = key;
            key = Keyboard.GetState();
            
            if (key.IsKeyDown(Keys.Right) == true)
            {
                currentGlitchState = GlitchState.MoveRight;
                position.X += 7;
            }
            else if (key.IsKeyDown(Keys.Left) == true)
            {
                currentGlitchState = GlitchState.MoveLeft;
                position.X -= 7;
            }

            if (previousKeyState.IsKeyUp(Keys.Left) == true && key.IsKeyDown(Keys.Left) == true && key.IsKeyDown(Keys.Right) == false)
            {
                currentGlitchState = GlitchState.IdleLeft;
            }
            else if (previousKeyState.IsKeyUp(Keys.Right) == true && key.IsKeyDown(Keys.Right) == true && key.IsKeyDown(Keys.Left) == false)
            {
                currentGlitchState = GlitchState.IdleRight;
            }
            //Makes character Jump
            if(key.IsKeyDown(Keys.Up))
            {
                currentGlitchState = GlitchState.Jump;
            } 
        }
        //Enemy Body Collision Code
        public void GlitchHurtSlime(Enemy enemy)
        {
            //You need to add a cooldown between when the slime hits the player and when she can next be hit by a slime, or it ends immediately
            //Probably need to add a timer.

            //See if you have to put the draw logic in this method?
            if (hitbox.Intersects(enemy.Hitbox) == true)
            {
                if (Lives < 4 && Lives > 0)
                {
                    Lives--;
                }
                else if (Lives == 0)
                {
                    Game1.currentGameState = GameState.GameOver;
                }
            }
        }
    }
}
