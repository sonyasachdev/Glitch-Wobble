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
    class Long_Sword:Sword
    {
        //Fields
        Timer JumpTimer;

        //Constructor
        public Long_Sword(Vector2 p)
        {
            this.position = p;
        }

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
    }
}
