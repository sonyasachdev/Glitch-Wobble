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
    enum SlimeState
    {
        MoveLeft,
        MoveRight,
        IdleLeft,
        IdleRight,
        Hurt,
        Dead
    }
    public class Slime : Enemy
    {
        //Enum Variables
        SlimeState currentSlimeState;
        SlimeState previousSlimeState;

        //Fields
        Rectangle LeftBound;
        Rectangle RightBound;
        Timer hurtTimer;
        Timer spawnTimer;
        Texture2D slimeSkin;
        Texture2D hitboxSkin;

        //Reset ints
        int startPositionX;
        int startPositionY;

        //Animation Fields
        Vector2 pos;
        private Point currentFrame;
        private Point frameSize;
        private int frame;
        private int numFrames;
        private int timeSinceLastFrame;
        private int frameRate;
        SpriteEffects flip;

        //Constructor
        public Slime(Rectangle p, bool a, int t)
        {
            this.position = p;
            this.timesHit = t;
            this.active = a;
            LeftBound = new Rectangle(1000, 100, 10, 10);
            RightBound = new Rectangle(3000, 100, 10, 10);

            startPositionX = p.X;
            startPositionY = p.Y;

            currentSlimeState = SlimeState.MoveRight;

            flip = SpriteEffects.FlipHorizontally;
            previousSlimeState = currentSlimeState;

            //Setting hitbox
            hitbox = new Rectangle(position.X, position.Y, 108, 108);

            //At the end of the hurt animation, it will revert to the previous Slime State it was in (Moving left or right)
            hurtTimer = new Timer();
            hurtTimer.Interval = 2000;
            hurtTimer.Elapsed += HurtTimerState;

            //Spawns a new enemy every second
            spawnTimer = new Timer();
            spawnTimer.Interval = 1000;
            spawnTimer.Elapsed += Spawn;
            //spawnTimer.Start();

            //Animation Initializers
            frameSize.X = 108;
            frameSize.Y = 108;
            currentFrame.X = 0;
            currentFrame.Y = 0;
            numFrames = 4;
            frameRate = 100;
        }

        //Timer Function
        //TimerEnd*
        private void HurtTimerState(Object source, System.Timers.ElapsedEventArgs e)
        {
            currentSlimeState = previousSlimeState;
        }

        //Monogame Methods
        public void Initialize()
        {
            currentSlimeState = SlimeState.MoveRight;
        }
        public void LoadContent(ContentManager Content)
        {
            slimeSkin = Content.Load<Texture2D>("Slime-Sheet.png");
            hitboxSkin = Content.Load<Texture2D>("playactive.png");
        }
        //Draw*
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            //Visual Hitbox 
            //spriteBatch.Draw(hitboxSkin, hitbox, Color.White);
            if (active == true)
            {
                switch (currentSlimeState)
                {
                    case SlimeState.MoveLeft:
                        flip = SpriteEffects.None;

                        spriteBatch.Draw(slimeSkin, // SpriteSheet
                        pos = new Vector2(position.X, position.Y), // position of slime
                        new Rectangle(currentFrame.X, currentFrame.Y, frameSize.X, frameSize.Y), // size of frame in spritesheet
                        Color.White,
                        0, // don't rotate the image
                        Vector2.Zero, // rotation center (not used)
                        1.5f, // scaling factor - dont change image size
                        flip, // Flip or not
                        0//Current Layer
                        );
                        break;
                    case SlimeState.MoveRight:
                        flip = SpriteEffects.FlipHorizontally;

                        spriteBatch.Draw(slimeSkin, // Spritesheet
                        pos = new Vector2(position.X, position.Y), // Position
                        new Rectangle(currentFrame.X, currentFrame.Y, frameSize.X, frameSize.Y), // size of frame
                        Color.White,
                        0, // don't rotate the image
                        Vector2.Zero, // rotation center (not used)
                        1.5f, // scaling factor - dont change image size
                        flip, // Flip or not
                        0//Current Layer
                        );
                        break;
                    case SlimeState.Hurt:
                        //Hurt Animation
                        break;
                    case SlimeState.Dead:
                        //Dead Animation
                        break;
                }
            }
            //else, it won't draw
        }
        
        //Update*
        public void Switch(GameTime gameTime)
        {
            //Hitbox Logic
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

            switch (currentSlimeState)
            {
                case SlimeState.MoveLeft:
                    MoveLeft(LeftBound);
                    break;
                case SlimeState.MoveRight:
                    MoveRight(RightBound);
                    break;
                case SlimeState.Hurt:
                    //Add the timer in here
                    break;
                case SlimeState.Dead:
                    //Code for this method is in enemy
                    Dead();
                    break;
            }
        }

        //Basic AI Code that makes it go left and right
        //Move*
        public void MoveRight(Rectangle RightBound)
        {
            if (position.X < RightBound.X)
            {
                position.X += 3;
            }
            else if (position.X >= RightBound.X)
            {
                currentSlimeState = SlimeState.MoveLeft;
            }
        }
        public void MoveLeft(Rectangle LeftBound)
        {
            if (position.X > LeftBound.X)
            {
                position.X -= 3;
            }
            else if (position.X <= LeftBound.X)
            {
                currentSlimeState = SlimeState.MoveRight;
            }
        }

        //Collision*
        public void Hurt(Long_Sword longsword)
        {
            if (this.Position.Intersects(longsword.Position) == true)
            {
                if (timesHit < 2)
                {
                    timesHit++;
                    //set a timer that makes the slime hurt for 1-2 seconds
                    currentSlimeState = SlimeState.Hurt;
                }
                else
                {
                    Dead();
                }
            }
        }

        //Reset*
        public void Reset()
        {
            position.X = startPositionX;
            position.Y = startPositionY;
        }

        public void Spawn(Object source, System.Timers.ElapsedEventArgs e)
        {
            Spawn();
        }

        private Slime Spawn()
        {
            Slime slime1 = new Slime(new Rectangle(500, 425, 108, 108), true, 0);
            Game1.enemyList.Add(slime1);
            return slime1;
        }

        public void Spawning()
        {
            //spawnTimer.Elapsed += Spawn;
        }

        /*
        //Takes count how many times hitbox has been touched by the weapon's attack state

        //maybe make this return a bool so that with the timer, it will know if the slime was hurt. If true, set state to hurt, if false, set state to dead.
        public bool? Hurt(Long_Sword longSword)
        {
            if (this.Position.Intersects(longSword.Position) == true)
            {
                if (timesHit < 2)
                {
                    timesHit++;
                    //set a timer that makes the slime hurt for 1-2 seconds
                    currentSlimeState = SlimeState.Hurt;
                    isHurt = true;
                    return isHurt;
                }
                else
                {
                    Dead();
                    isHurt = false;
                    return isHurt;
                }
            }
            else
            {
                isHurt = null;
                return isHurt;
            }
        }
        */
    }
}
