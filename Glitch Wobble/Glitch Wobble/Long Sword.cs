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
            //Makes sure that the long sword's position follows Glitch's position
            //this.position = glitch.Position;
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
                case LongSwordState.Idle:
                    break;
                case LongSwordState.MoveLeft:
                    break;
                case LongSwordState.MoveRight:
                    break;
                case LongSwordState.Jump:
                    break;
                case LongSwordState.Attack:
                    break;
                case LongSwordState.Hurt:
                    break;
                case LongSwordState.Dead:
                    break;
            }
        }

        //Methods
        public void Switch()
        {
            switch (currentLongSwordState)
            {
                case LongSwordState.Idle:
                    break;
                case LongSwordState.MoveLeft:
                    break;
                case LongSwordState.MoveRight:
                    break;
                case LongSwordState.Jump:
                    break;
                case LongSwordState.Attack:
                    break;
                case LongSwordState.Hurt:
                    break;
                case LongSwordState.Dead:
                    break;
            }
        }
    }
}
