using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Timers;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

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

    public enum keyboardState
    {
        Right,
        Left
    }

    class Glitch : Beings
    {
        //Fields
        SpriteBatch spriteBatch;
        KeyboardState key;
        KeyboardState previousKeyState;
        private int lives;
        private Rectangle hitbox;
        private Rectangle bottomHitBox;

        private Platform currentPlatform = null;

        //Lower bound that resets and makes her lose a life
        private Rectangle fallBound;

        //Platform Collision Bool
        bool onHorzPlatform;
        bool onVertPlatform;

        //Class Initializer
        Ground ground;

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
        keyboardState currentKeyState;
        keyboardState previousKeyboardState;

        //buffer timer variables
        Timer bufferTime;
        bool canBeHit;

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
            previousKeyboardState = currentKeyState;

            currentGlitchState = GlitchState.IdleRight;
            currentKeyState = keyboardState.Right;

            //Setting Start* Position
            this.position = new Rectangle(0, 200, 300, 400);
            //Setting Hitbox
            hitbox = new Rectangle(position.X, position.Y, 125, 400);
            bottomHitBox = new Rectangle(position.X, position.Y, 125, 10);

            //Setting Life Count
            lives = 2;

            //Setting Platform Boolean
            onHorzPlatform = false;
            onVertPlatform = false;

            //Setting fallBound
            fallBound = new Rectangle(-1000000, 2000, 2000000, 10);

            //Jump
            hasJumped = false;

            //Initialize ground TEST*
            ground = new Ground();

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
            canBeHit = true;
            currentGlitchState = GlitchState.IdleRight;
           // bufferTime = new Timer(2000);
            //bufferTime.Elapsed += BufferTime_Elapsed;
        }

       /* private void BufferTime_Elapsed(object sender, ElapsedEventArgs e)
        {
            bufferTime.Stop();
            canBeHit = true;

            if (currentKeyState == keyboardState.Right)
            {
                currentGlitchState = GlitchState.IdleRight;
            }

            else
                currentGlitchState = GlitchState.IdleLeft;
        } */

        public void LoadContent(ContentManager Content)
        {
            glitchSkin = Content.Load<Texture2D>("glitchSkin.png");
            hitboxSkin = Content.Load <Texture2D>("playactive.png");
        }

        //Draw*
        public void Draw(SpriteBatch spriteBatch)
        {
            //Hitbox visual code
            spriteBatch.Draw(hitboxSkin, bottomHitBox, Color.White);
            //spriteBatch.Draw(hitboxSkin, position, Color.White);
            if(Game1.drawHitbox == true)
            {
                spriteBatch.Draw(hitboxSkin, hitbox, Color.White);
            }

            //fallBound visual code
            spriteBatch.Draw(hitboxSkin, fallBound, Color.White);

            if (currentGlitchState == GlitchState.Hurt)
            {
            }

            switch (currentGlitchState)
            {
                case GlitchState.MoveRight:
                    flip = SpriteEffects.None;

                    spriteBatch.Draw(glitchSkin, // SpriteSheet
                        pos = new Vector2(position.X, position.Y), // position of Glitch
                        new Rectangle(currentFrame.X, currentFrame.Y, frameSize.X, frameSize.Y), // size of frame in spritesheet
                        Color.White,
                        0, // don't rotate the image
                        Vector2.Zero, // rotation center (not used)
                        .4f, // scaling factor - dont change image size
                        flip, // Flip or not
                        0//Current Layer
                        );
                    break;
                case GlitchState.MoveLeft:

                    flip = SpriteEffects.FlipHorizontally;

                    spriteBatch.Draw(glitchSkin, // SpriteSheet
                        pos = new Vector2(position.X, position.Y), // position of Glitch
                        new Rectangle(currentFrame.X, currentFrame.Y, frameSize.X, frameSize.Y), // size of frame in spritesheet
                        Color.White,
                        0, // don't rotate the image
                        Vector2.Zero, // rotation center (not used)
                        .4f, // scaling factor - dont change image size
                        flip, // Flip or not
                        0//Current Layer
                        );
                    break;
                case GlitchState.Jump:
                    spriteBatch.Draw(glitchSkin, // SpriteSheet
                        pos = new Vector2(position.X, position.Y), // position of Glitch
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
                    flip = SpriteEffects.None;

                    spriteBatch.Draw(glitchSkin, // SpriteSheet
                        pos = new Vector2(position.X, position.Y), // position of Glitch
                        new Rectangle(currentFrame.X, currentFrame.Y, frameSize.X, frameSize.Y), // size of frame in spritesheet
                        Color.White,
                        0, // don't rotate the image
                        Vector2.Zero, // rotation center (not used)
                        .4f, // scaling factor - dont change image size
                        flip, // Flip or not
                        0//Current Layer
                        );
                    break;
                case GlitchState.IdleLeft:
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
                    break;
                case GlitchState.Hurt:
                    //Put hurt animation, also reduce the GUI hearts by one
                    spriteBatch.Draw(glitchSkin, // SpriteSheet
                        pos = new Vector2(position.X, position.Y), // position of Glitch
                        new Rectangle(currentFrame.X, currentFrame.Y, frameSize.X, frameSize.Y), // size of frame in spritesheet
                        Color.Red,
                        0, // don't rotate the image
                        Vector2.Zero, // rotation center (not used)
                        .4f, // scaling factor - dont change image size
                        flip, // Flip or not
                        0//Current Layer
                        );
                    break;
                case GlitchState.Dead:
                    //Run dead animation and change state to GameOver
                    break;
            }
        }

        //Update*
        public void Switch(GameTime gameTime)
        {
            //Dynamically sets hitbox
            hitbox.X = position.X;
            hitbox.Y = position.Y;
            
            bottomHitBox.X = position.X;

            if (currentGlitchState == GlitchState.IdleLeft || currentGlitchState == GlitchState.MoveLeft)
                bottomHitBox.X = position.X + 290;

            bottomHitBox.Y = position.Y + 385;

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
                    hitbox.X = position.X;
                    hitbox.Y = position.Y;
                    Move();
                    break;
                case GlitchState.MoveLeft:
                    hitbox.X = 275+position.X;
                    hitbox.Y = position.Y;
                    Move();
                    break;
                case GlitchState.Jump:
                    if(currentKeyState == keyboardState.Left)
                    {
                        hitbox.X = 275 + position.X;
                    }
                    Jump();
                    Move();
                    Fall();
                    break;
                case GlitchState.IdleRight:
                    hitbox.X = position.X;
                    hitbox.Y = position.Y;
                    Move();
                    break;
                case GlitchState.IdleLeft:
                    hitbox.X = 275+position.X;
                    hitbox.Y = position.Y;
                    Move();
                    break;
                case GlitchState.Hurt:
                    Move();
                    break;
                case GlitchState.Dead:
                    //Run dead animation and change state to GameOver
                    Game1.currentGameState = GameState.GameOver;
                    break;
            }
        }

        //Jump*
        public void Jump()
        {
            previousKeyState = key;
            key = Keyboard.GetState();

            position.X += (int)velocity.X;
            position.Y += (int)velocity.Y;

            //Up
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && hasJumped == false)
            {
                position.Y -= 10;
                velocity.Y = -18f;

                hasJumped = true;

                onHorzPlatform = false;
                onVertPlatform = false;
            }

            //Down
            if (hasJumped == true)
            {
                if (velocity.Y < 13f)
                {
                    velocity.Y += 0.65f;
                }
                else
                {
                    velocity.Y = 13f;
                }
            }

            //Instead of this piece have a for*loop calling endjump for each platform
            if (velocity.Y > -16.7f)
            {
                for (int i = 0; i < Game1.horzPlatformList.Count; i++)
                {
                    EndHorzMoveJump(Game1.horzPlatformList[i]);
                    EndGroundJump(ground);
                }
                for (int i = 0; i < Game1.vertPlatformList.Count; i++)
                {
                    EndVertMoveJump(Game1.vertPlatformList[i]);
                    EndGroundJump(ground);
                }
            }

            if (hasJumped == false)
            {
                velocity.Y = 0f;
            }
        }

        //Move*
        public void Move()
        {
            previousKeyState = key;
            key = Keyboard.GetState();
            
            //Moving Right*
            if (key.IsKeyDown(Keys.Right) == true)
            {
                //Makes sure that the hitbox matches up to the image before switching Glitch's state
                if (currentKeyState == keyboardState.Left)
                {
                    if (position.X < 0)
                        position.X = 0;
                    else
                        position.X += 175;
                }

                //Changes the KeyState to Right
                currentKeyState = keyboardState.Right;

                //Makes sure that glitch isn't in Jump before switching the state so that she doesn't stop midair
                if (currentGlitchState != GlitchState.Jump)
                {
                    currentGlitchState = GlitchState.MoveRight;
                    position.X += 7;
                }
                else
                {
                    //Makes sure Glitch flips visually in air
                    if (previousGlitchState == GlitchState.MoveRight)
                    {
                        flip = SpriteEffects.None;
                    }
                    position.X += 7;
                }

                Console.WriteLine(position.X);
            }

            //Moving Left*
            else if (key.IsKeyDown(Keys.Left) == true)
            {
                //Makes sure that the hitbox matches up to the image before switching Glitch's state
                if (currentKeyState == keyboardState.Right)
                {
                    position.X -= 175;
                }

                //Changes the KeyState to Right
                currentKeyState = keyboardState.Left;

                //Makes sure that glitch isn't in Jump before switching the state so that she doesn't stop midair
                if (currentGlitchState != GlitchState.Jump)
                {
                    currentGlitchState = GlitchState.MoveLeft;
                    position.X -= 7;
                }
                else
                {
                    //Makes sure Glitch flips visually in air
                    if (previousGlitchState == GlitchState.MoveRight)
                    {
                        flip = SpriteEffects.FlipHorizontally;
                    }
                    position.X -= 7;
                }

                if (position.X < -280)    //prevents glitch from going back too far and stops her at x = -280
                    position.X = -280;
            }

            if (previousKeyState.IsKeyUp(Keys.Left) == true && key.IsKeyDown(Keys.Left) == true)
            {
                if (currentGlitchState != GlitchState.Jump)
                {
                    currentGlitchState = GlitchState.IdleLeft;
                }
            }
            else if (previousKeyState.IsKeyUp(Keys.Right) == true && key.IsKeyDown(Keys.Right) == true)
            {
                if (currentGlitchState != GlitchState.Jump)
                {
                    currentGlitchState = GlitchState.IdleRight;
                }
            }

            //Makes Glitch Jump
            if(previousKeyState.IsKeyUp(Keys.Up) == true && key.IsKeyDown(Keys.Up) == true)
            {
                currentGlitchState = GlitchState.Jump;
            }

            //Makes her move with platform
            //Horizontal
            if (onHorzPlatform == true && currentPlatform != null)
            {
                if (bottomHitBox.Intersects(currentPlatform.HitBox) == false)
                {
                    onHorzPlatform = false;
                    currentPlatform = null;
                    hasJumped = true;
                    currentGlitchState = GlitchState.Jump;
                }
                else
                {
                    if (Horizontal_Platform.pubActive == false)
                    {
                        onHorzPlatform = false;
                        currentPlatform = null;
                        hasJumped = false;
                        currentGlitchState = GlitchState.Jump;
                    }
                }

                if (Horizontal_Platform.direction == true)
                {
                    position.X += 5;
                }
                else
                {
                    position.X -= 5;
                }
            }

            //Vertical
            if (onVertPlatform == true && currentPlatform != null)
            {
                if (bottomHitBox.Intersects(currentPlatform.HitBox) == false)
                {
                    onVertPlatform = false;
                    currentPlatform = null;
                    hasJumped = true;
                    currentGlitchState = GlitchState.Jump;
                }
                else
                {
                    if(Vertical_Platform.pubActive == false)
                    {
                        onVertPlatform = false;
                        currentPlatform = null;
                        hasJumped = false;
                        currentGlitchState = GlitchState.Jump;
                    }
                }

                //Decides which position to move glitch in.
                if (Vertical_Platform.direction == true)
                {
                    position.Y -= 5;
                }
                else
                {
                    position.Y += 5;
                }
            }
        }

        //Enemy Collision* Code
        public bool GlitchGetsHurt(Enemy enemy)
        {
            //You need to add a cooldown between when the slime hits the player and when she can next be hit by a slime, or it ends immediately
            //Probably need to add a timer*.

            //See if you have to put the draw logic in this method?
            if (hitbox.Intersects(enemy.Hitbox) == true)
            {
                if (currentKeyState == keyboardState.Right)
                    position.X -= 75;
                else
                    position.X += 75;

                if (Lives < 3 && Lives > 0)
                {
                    currentGlitchState = GlitchState.Hurt;
                    Lives--;
                }
                else if (Lives == 0)
                {
                    Game1.currentGameState = GameState.GameOver;
                }

                return true;
            }
            else
                return false;
        }

        //Horizontal Collision* Code
        public void EndHorzMoveJump(Horizontal_Platform platform)
        {
            if (platform.Active == true)
            {
                //Checks if Glitch is touching a platform
                if (bottomHitBox.Intersects(platform.HitBox) == true)
                {
                    currentPlatform = platform;

                    onHorzPlatform = true;
                    //Checks if she's in Jump State
                    if (currentGlitchState == GlitchState.Jump)
                    {
                        hasJumped = false;
                        //Checks whether to put her facing right or left when the collision happens
                        if (currentKeyState == keyboardState.Right)
                        {
                            currentGlitchState = GlitchState.IdleRight;
                        }
                        else if (currentKeyState == keyboardState.Left)
                        {
                            currentGlitchState = GlitchState.IdleLeft;
                        }
                    }
                }
            }
        }

        //Vertical Collision* Code
        public void EndVertMoveJump(Vertical_Platform platform)
        {
            if (platform.Active == true)
            {
                //Checks if Glitch is touching a platform
                if (bottomHitBox.Intersects(platform.HitBox) == true)
                {
                    currentPlatform = platform;

                    onVertPlatform = true;
                    //Checks if she's in Jump State
                    if (currentGlitchState == GlitchState.Jump)
                    {
                        hasJumped = false;
                        //Checks whether to put her facing right or left when the collision happens
                        if (currentKeyState == keyboardState.Right)
                        {
                            currentGlitchState = GlitchState.IdleRight;
                        }
                        else if (currentKeyState == keyboardState.Left)
                        {
                            currentGlitchState = GlitchState.IdleLeft;
                        }
                    }
                }
            }
        }

        //Ground Collision* Code
        public void EndGroundJump(Ground ground)
        {
            //Change
            //Checks if Glitch is touching the ground
            if (bottomHitBox.Intersects(ground.HitBox) == true)
            {
                //Checks if she's in Jump State
                if (currentGlitchState == GlitchState.Jump)
                {
                    hasJumped = false;
                    //Checks whether to put her facing right or left when the collision happens
                    if (currentKeyState == keyboardState.Right)
                    {
                        currentGlitchState = GlitchState.IdleRight;
                    }
                    else if (currentKeyState == keyboardState.Left)
                    {
                        currentGlitchState = GlitchState.IdleLeft;
                    }

                }
            }
        }

        //Reset* Method
        public void Reset()
        {
            lives = 3;
            position.X = 0;
            position.Y = 200;
            currentGlitchState = GlitchState.IdleRight;
            hasJumped = false;
            onVertPlatform = false;
            onHorzPlatform = false;
            currentPlatform = null;
            currentKeyState = keyboardState.Right;
            velocity.X = 0f;
            velocity.Y = 0f;
        }

        //Falling Reset Code
        public void Fall()
        {
            if (hitbox.Intersects(fallBound) == true)
            {
                if (Lives == 0)
                {
                    Game1.currentGameState = GameState.GameOver;
                }
                else
                {
                    lives -= 1;
                    position.X = 0;
                    position.Y = 200;
                    currentGlitchState = GlitchState.IdleRight;
                    hasJumped = false;
                    onVertPlatform = false;
                    onHorzPlatform = false;
                    currentPlatform = null;
                    currentKeyState = keyboardState.Right;
                    velocity.X = 0f;
                    velocity.Y = 0f;
                }
            }
        }
    }
}
