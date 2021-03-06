﻿using System;
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
    public class Ground:Platform
    {
        //Fields
        public static List<Rectangle> groundList;
        public static List<Rectangle> hitboxList;

        private Rectangle tile1;
        private Rectangle tile2;
        private Rectangle tile3;
        private Rectangle tile4;

        private Rectangle startTile1;
        private Rectangle startTile2;
        private Rectangle startTile3;
        private Rectangle startTile4;

        private Rectangle hitbox1;
        private Rectangle hitbox2;
        private Rectangle hitbox3;
        private Rectangle hitbox4;

        private Rectangle temp1;
        private Rectangle temp2;
        private Rectangle temp3;
        private Rectangle temp4;

        private Texture2D tile1Skin;
        private Texture2D tile2Skin;
        private Texture2D tile3Skin;
        private Texture2D tile4Skin;

        //Random Hole maker
        public static bool makeHole;
        public static int yesno;
        public static int sizeHole;
        private Random rngesus;

        //Properties
        public Rectangle Tile1
        {
            get { return hitbox1; }
            set { hitbox1 = value; }
        }
        public Rectangle Tile2
        {
            get { return hitbox2; }
            set { hitbox2 = value; }
        }
        public Rectangle Tile3
        {
            get { return hitbox3; }
            set { hitbox3 = value; }
        }
        public Rectangle Tile4
        {
            get { return hitbox4; }
            set { hitbox4 = value; }
        }

        //Constructor
        public Ground()
        {
            //Tile1 Initialize
            tile1 = new Rectangle(0, 260, 1000, 500);
            hitbox1 = new Rectangle(tile1.X, tile1.Y + 330 , 1000, 190);
            active = true;

            //Tile2 Initialize
            tile2 = new Rectangle(1000, 260, 1000, 500);
            hitbox2 = new Rectangle(tile2.X, tile2.Y + 330, 1000, 190);
            active = true;

            //Tile1 Initialize
            tile3 = new Rectangle(-2000, 260, 1000, 500);
            hitbox3 = new Rectangle(tile3.X, tile3.Y + 330, 1000, 190);
            active = true;

            //Tile1 Initialize
            tile4 = new Rectangle(-1000, 260, 1000, 500);
            hitbox4 = new Rectangle(tile4.X, tile4.Y + 330, 1000, 190);
            active = true;

            //Setting up ground list
            groundList = new List<Rectangle>();
            groundList.Add(tile1);
            groundList.Add(tile2);
            groundList.Add(tile3);
            groundList.Add(tile4);

            //Setting up hitbox list
            hitboxList = new List<Rectangle>();
            hitboxList.Add(hitbox1);
            hitboxList.Add(hitbox2);
            hitboxList.Add(hitbox3);
            hitboxList.Add(hitbox4);

            //Setting up Temp
            temp1 = hitboxList[0];
            temp2 = hitboxList[1];
            temp3 = hitboxList[2];
            temp4 = hitboxList[3];

            //Setting up Start positions
            startTile1 = tile1;
            startTile2 = tile2;
            startTile3 = tile3;
            startTile4 = tile4;

            //Randomizer
            makeHole = false;
            sizeHole = 0;
            rngesus = new Random();
        }

        //Methods
        public void Initialize()
        {

        }
        public void LoadContent(ContentManager Content)
        {
            tile1Skin = Content.Load<Texture2D>("Ground-1.png");
            tile2Skin = Content.Load<Texture2D>("Ground-1.png"); //change*
            tile3Skin = Content.Load<Texture2D>("Ground-1.png"); //change*
            tile4Skin = Content.Load<Texture2D>("Ground-1.png"); //change*
        }
        public void Update(GameTime gameTime)
        {

            yesno = rngesus.Next(0, 2);
            if(yesno == 0)
            {
                makeHole = true;
            }
            else
            {
                makeHole = false;
            }
            if (makeHole == true)
            {
                sizeHole = rngesus.Next(200, 301);
            }

            //Updates Position
            temp1.X = groundList[0].X;
            temp2.X = groundList[1].X;
            temp3.X = groundList[2].X;
            temp4.X = groundList[3].X;

            //Updates Position
            hitboxList[0] = temp1;
            hitboxList[1] = temp2;
            hitboxList[2] = temp3;
            hitboxList[3] = temp4;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tile1Skin, groundList[0], Color.White);
            spriteBatch.Draw(tile2Skin, groundList[1], Color.White);
            spriteBatch.Draw(tile3Skin, groundList[2], Color.White);
            spriteBatch.Draw(tile4Skin, groundList[3], Color.White);
        }

        public void Reset()
        {
            groundList[0] = startTile1;
            groundList[1] = startTile2;
            groundList[2] = startTile3;
            groundList[3] = startTile4;
        }



    }
}
