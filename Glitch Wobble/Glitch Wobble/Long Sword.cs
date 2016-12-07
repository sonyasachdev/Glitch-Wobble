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
    enum LongSwordState
    {
        Idle,
        MoveLeft,
        MoveRight,
        Jump,
        Attack,
        Hurt,
        Dead
    }

    public class Long_Sword:Sword
    {
        //See if you need longsword to inherit from glitch. Have it inherit glitch's position so that the longsword will follow where her body is.

        //Fields
        LongSwordState currentLongSwordState;
        Texture2D longSwordSkin;
        Glitch glitch;

        //Constructor
        public Long_Sword()
        {
            this.position = glitch.Position;
        }
        
        //Monogame Methods
        public void Initialize()
        {

        }
        public void LoadContent(ContentManager Content)
        {
            longSwordSkin = Content.Load<Texture2D>("longSwordSkin.png");
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            switch (currentLongSwordState)
            {
                case LongSwordState.MoveRight:
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
                case LongSwordState.MoveLeft:

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
                case LongSwordState.Jump:

                    if (currentKeyState == keyboardState.Right)
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
                case LongSwordState.IdleRight:
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
                case LongSwordState.IdleLeft:
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
                case LongSwordState.Hurt:
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
        public void Switch(GameTime gameTime)
        {

        }
        
        }
    }
}
