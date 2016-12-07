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
        Attack,
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

    public class Glitch : Beings
    {
        //Fields
        Slime slime;
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
        bool onGroundPlatform;

        bool onTile1;
        bool onTile2;
        bool onTile3;
        bool onTile4;

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
            this.position = new Rectangle(0, 200, 580, 760);
            //Setting Hitbox
            hitbox = new Rectangle(position.X, position.Y, 125, 400);
            bottomHitBox = new Rectangle(position.X, position.Y, 125, 10);

            //Setting Life Count
            lives = 2;

            //Setting Platform Boolean
            onHorzPlatform = false;
            onVertPlatform = false;
            onGroundPlatform = true;

            onTile1 = false;
            onTile2 = false;
            onTile3 = false;
            onTile4 = false;

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
            flip = SpriteEffects.None;
        }

        //Monogame Methods
        public void Initialize()
        {
            canBeHit = true;
            currentGlitchState = GlitchState.IdleRight;
        }


        public void LoadContent(ContentManager Content)
        {
            glitchSkin = Content.Load<Texture2D>("glitchSkin.png");
            hitboxSkin = Content.Load <Texture2D>("playactive.png");
        }

        //Draw*
        public void Draw(SpriteBatch spriteBatch)
        {
            //Hitbox visual code
            //spriteBatch.Draw(hitboxSkin, position, Color.White);
            if(Game1.drawHitbox == true)
            {
                spriteBatch.Draw(hitboxSkin, bottomHitBox, Color.White);
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
                    flip = SpriteEffects.FlipHorizontally;

                    spriteBatch.Draw(glitchSkin, // SpriteSheet
                        pos = new Vector2(position.X - 280, position.Y), // position of Glitch
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
                case GlitchState.Jump:

                    if(currentKeyState == keyboardState.Right)
                    {
                        spriteBatch.Draw(glitchSkin, // SpriteSheet
                        pos = new Vector2(position.X - 280, position.Y), // position of Glitch
                        new Rectangle(currentFrame.X, currentFrame.Y, frameSize.X, frameSize.Y), // size of frame in spritesheet
                        Color.White,
                        0, // don't rotate the image
                        Vector2.Zero, // rotation center (not used)
                        .4f, // scaling factor - dont change image size
                        flip, // Flip or not
                        0//Current Layer
                        );
                    }
                    else
                    {
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
                    }
                    break;
                case GlitchState.IdleRight:
                    flip = SpriteEffects.FlipHorizontally;

                    spriteBatch.Draw(glitchSkin, // SpriteSheet
                        pos = new Vector2(position.X - 280, position.Y), // position of Glitch
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

            //Fix this method, for some reason it crashes visual studio
            Loop(); //change*

            if (currentGlitchState == GlitchState.IdleLeft || currentGlitchState == GlitchState.MoveLeft)
                bottomHitBox.X = position.X; //change*

            bottomHitBox.Y = position.Y + 345;

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
                    hitbox.X = position.X;
                    hitbox.Y = position.Y;
                    Move();
                    break;
                case GlitchState.Jump:
                    if(currentKeyState == keyboardState.Left)
                    {
                        hitbox.X = position.X;
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
                    hitbox.X = position.X;
                    hitbox.Y = position.Y;
                    Move();
                    break;
                case GlitchState.Hurt:
                    Move();
                    break;
                case GlitchState.Attack:
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
            
            //Almost after jumping, checks to see if she collides
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
                /*if (currentKeyState == keyboardState.Left)
                {
                    if (position.X < 0)
                        position.X = 0;
                    else
                        position.X += 175;
                }*/

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
                        flip = SpriteEffects.FlipHorizontally;
                    }
                    position.X += 7;
                }

                Console.WriteLine(position.X);
            }

            //Moving Left*
            else if (key.IsKeyDown(Keys.Left) == true)
            {
                //Makes sure that the hitbox matches up to the image before switching Glitch's state
                /*if (currentKeyState == keyboardState.Right)
                {
                    position.X -= 175;
                }
                */
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
                        flip = SpriteEffects.None;
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
            //Ground*
            if (onGroundPlatform == true && currentPlatform == null)
            {
                //checks to see if she's on any ground tile (1-4)
                if (bottomHitBox.Intersects(Ground.hitboxList[0]) == false && bottomHitBox.Intersects(Ground.hitboxList[1]) == false && bottomHitBox.Intersects(Ground.hitboxList[2]) == false && bottomHitBox.Intersects(Ground.hitboxList[3]) == false)
                {
                    onGroundPlatform = false;

                    //Makes sure that she falls
                    hasJumped = true;
                    currentGlitchState = GlitchState.Jump;
                }
            }

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
                        hasJumped = true;
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
                        hasJumped = true;
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
            for (int i = 0; i < 4; i++)
            {
                //Checks if she's on a ground tile
                if (bottomHitBox.Intersects(Ground.hitboxList[i]) == true)
                {
                    onGroundPlatform = true;

                    //Checks if she's in Jump State
                    if (currentGlitchState == GlitchState.Jump)
                    {
                        hasJumped = false;
                        //Checks whether to put her facing right or left when the collision happens and sets her state
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

        //Tile Loop* Method
        public void Loop()
        {
            for (int i = 0; i < 4; i++)
            {
                if (currentGlitchState == GlitchState.MoveRight)
                {
                    #region MoveRight
                    if (i == 0 && bottomHitBox.Intersects(Ground.hitboxList[0]) == true && onGroundPlatform == true && onTile1 == false)
                    {
                        Rectangle temp = Ground.groundList[2];
                        temp.X += 4000;
                        Ground.groundList[2] = temp;
                        onTile1 = true;
                        onTile3 = false;
                    }
                    else if (i == 1 && bottomHitBox.Intersects(Ground.hitboxList[1]) == true && onGroundPlatform == true && onTile2 == false)
                    {
                        Rectangle temp = Ground.groundList[3];
                        if (Ground.makeHole == true)
                        {
                            temp.X += (4000 + Ground.sizeHole);
                        }
                        else
                        {
                            temp.X += 4000;
                        }
                        Ground.groundList[3] = temp;
                        onTile2 = true;
                        onTile4 = false;
                    }
                    else if (i == 2 && bottomHitBox.Intersects(Ground.hitboxList[2]) == true && onGroundPlatform == true && onTile3 == false)
                    {
                        Rectangle temp = Ground.groundList[0];
                        if (Ground.makeHole == true)
                        {
                            temp.X += (4000 + Ground.sizeHole);
                        }
                        else
                        {
                            temp.X += 4000;
                        }
                        Ground.groundList[0] = temp;
                        onTile1 = false;
                        onTile3 = true;
                    }
                    else if (i == 3 && bottomHitBox.Intersects(Ground.hitboxList[3]) == true && onGroundPlatform == true && onTile4 == false)
                    {
                        i = 0;
                        Rectangle temp = Ground.groundList[1];
                        if (Ground.makeHole == true)
                        {
                            temp.X += (4000 + Ground.sizeHole);
                        }
                        else
                        {
                            temp.X += 4000;
                        }
                        Ground.groundList[1] = temp;
                        onTile2 = false;
                        onTile4 = true;
                    }
#endregion
                }
                /*else if (currentGlitchState == GlitchState.MoveLeft)
                {
                    if (Ground.groundList[i] == Ground.groundList[0] && bottomHitBox.Intersects(Ground.groundList[i]) == true)
                    {
                        Rectangle temp = Ground.groundList[2];
                        temp.X -= 4000; 
                        Ground.groundList[2] = temp;
                    }
                    else if (Ground.groundList[i] == Ground.groundList[1] && bottomHitBox.Intersects(Ground.groundList[i]) == true)
                    {
                        Rectangle temp = Ground.groundList[3];
                        temp.X -= 4000; 
                        Ground.groundList[3] = temp;
                    }
                    else if (Ground.groundList[i] == Ground.groundList[2] && bottomHitBox.Intersects(Ground.groundList[i]) == true)
                    {
                        Rectangle temp = Ground.groundList[0];
                        temp.X -= 4000;
                        Ground.groundList[0] = temp;
                    }
                    else if (Ground.groundList[i] == Ground.groundList[3] && bottomHitBox.Intersects(Ground.groundList[i]) == true)
                    {
                        i = 0;
                        Rectangle temp = Ground.groundList[1];
                        temp.X -= 4000;
                        Ground.groundList[1] = temp;
                    }

                }
                */


            }
        }

        public void Attack()
        {
            previousKeyState = key;
            key = Keyboard.GetState();

            if(key.IsKeyDown(Keys.Z) && previousKeyState.IsKeyUp(Keys.Z))
            {
              /*  if(swordHitBox.Intersects(slime.Hitbox))
                {
                    slime.Hurt(this);
                } */
            }
        }

        //Reset* Method
        public void Reset()
        {
            lives = 2;
            position.X = 0;
            position.Y = 200;
            currentGlitchState = GlitchState.IdleRight;
            hasJumped = false;
            onVertPlatform = false;
            onHorzPlatform = false;

            onTile1 = false;
            onTile2 = false;
            onTile3 = false;
            onTile4 = false;

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
                    onGroundPlatform = true;

                    onTile1 = false;
                    onTile2 = false;
                    onTile3 = false;
                    onTile4 = false;

                    currentPlatform = null;
                    currentKeyState = keyboardState.Right;
                    velocity.X = 0f;
                    velocity.Y = 0f;
                }
            }
        }
    }
}
