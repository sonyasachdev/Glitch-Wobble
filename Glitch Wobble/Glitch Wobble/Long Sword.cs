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
    public class Long_Sword:Sword
    {
        //Fields
        Timer JumpTimer;
        Rectangle hitBox;

        Texture2D longSwordSkin;

        //Constructor
        public Long_Sword(Rectangle p)
        {
            this.position = p;
        }

        //Different States
        enum LongSwordState
        {
            Idle,
            Run,
            StartJump,
            EndJump,
            Attack,
            Hurt,
            Dead
        }
        LongSwordState currentLongSwordState;

        //Monogame Methods
        public void Initialize()
        {

        }
        public void LoadContent(ContentManager Content)
        {
            longSwordSkin = Content.Load<Texture2D>("longSwordSkin.png");
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            switch (currentLongSwordState)
            {
                case LongSwordState.Idle:
                    break;
                case LongSwordState.Run:
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
                case LongSwordState.Run:
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
