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
        StartJump,
        EndJump,
        Attack,
        Hurt,
        Dead
    }

    public class Long_Sword:Sword
    {

        //Fields
        LongSwordState currentLongSwordState;
        Timer JumpTimer;
        Texture2D longSwordSkin;

        //Constructor
        public Long_Sword()
        {
            position = new Rectangle(0, 0, 100, 100);
            //longSwordSkin = skin;
            //skin = longSwordSkin;
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
            //Draw(spriteBatch);
            
            switch (currentLongSwordState)
            {
                case LongSwordState.Idle:
                    break;
                case LongSwordState.MoveLeft:
                    spriteBatch.Draw(skin, position, Color.White);
                    break;
                case LongSwordState.MoveRight:
                    spriteBatch.Draw(skin, position, Color.White);
                    break;
                case LongSwordState.StartJump:
                    break;
                case LongSwordState.EndJump:
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
                case LongSwordState.StartJump:
                    break;
                case LongSwordState.EndJump:
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
