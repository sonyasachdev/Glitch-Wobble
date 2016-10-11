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
    //Enums
    public enum MenuButtonState
    {
        ActivePlayButton,
        ActiveOptionButton,
    }
    public enum OptionButtonState
    {
        ActiveEasy,
        ActiveMedium,
        ActiveHard,
        ActiveCancel
    }

    public enum PauseButtonState
    {
        ActiveResume,
        ActiveQuit,
        /*Don't need the idles anymore because both buttos will be drawn on the menu and depending on the state, a button will go over the existing ones.*/
    }
    class Buttons
    {

        //Enum Variable
        PauseButtonState currentPauseButtonState;
        OptionButtonState currentOptionButtonState;
        MenuButtonState currentMenuButtonState;
        //Fields
        //Button Textures
        Texture2D playIdle;
        Texture2D playActive;
        Texture2D optionsIdle;
        Texture2D optionsActive;

        //Button Rectangles
        Rectangle playIdleRect;
        Rectangle playActiveRect;
        Rectangle optionsIdleRect;
        Rectangle optionsActiveRect;

        KeyboardState key;
        
        //Constructors
        public Buttons()
        {
            currentMenuButtonState = MenuButtonState.ActivePlayButton;
            currentOptionButtonState = OptionButtonState.ActiveEasy;
        }

        public void Initialize()
        {
            
        }
        public void LoadContent(ContentManager Content)
        {
            playIdle = Content.Load<Texture2D>("playidle.png");
            playActive = Content.Load<Texture2D>("playactive.png");
            optionsIdle = Content.Load<Texture2D>("optionsidle.png");
            optionsActive = Content.Load<Texture2D>("optionsactive.png");

            playIdleRect = new Rectangle(100, 300, 300, 100);
            playActiveRect = new Rectangle(100, 300, 300, 100);
            optionsIdleRect = new Rectangle(100, 500, 300, 100);
            optionsActiveRect = new Rectangle(100, 500, 300, 100);
        }
        public void DrawMenu(SpriteBatch spriteBatch)
        {
            //Draws the static idle buttons
            spriteBatch.Draw(optionsIdle, optionsIdleRect, Color.White);
            spriteBatch.Draw(playIdle, playIdleRect, Color.White);

            switch (currentMenuButtonState)
            {
                case MenuButtonState.ActivePlayButton:
                    spriteBatch.Draw(playActive, playActiveRect, Color.White);
                    break;
                case MenuButtonState.ActiveOptionButton:
                    spriteBatch.Draw(optionsActive, optionsActiveRect, Color.White);
                    break;
            }
        }
        public void DrawOptions(SpriteBatch spriteBatch)
        {

            switch (currentOptionButtonState)
            {
                case OptionButtonState.ActiveEasy:
                    break;
                case OptionButtonState.ActiveMedium:
                    break;
                case OptionButtonState.ActiveHard:
                    break;
                case OptionButtonState.ActiveCancel:
                    break;
            }
        }
        
        //Menu Button Switch
        public void MenuButtonSwitch(KeyboardState key)
        {
            switch (currentMenuButtonState)
            {
                case MenuButtonState.ActivePlayButton:
                    if (key.IsKeyDown(Keys.Down))
                    {
                        currentMenuButtonState = MenuButtonState.ActiveOptionButton;
                    }
                    else if (key.IsKeyDown(Keys.Enter))
                    {
                        Game1.currentGameState = GameState.PlayGame;
                    }
                    break;
                case MenuButtonState.ActiveOptionButton:

                    if (key.IsKeyDown(Keys.Up))
                    {
                        currentMenuButtonState = MenuButtonState.ActivePlayButton;
                    }
                    else if (key.IsKeyDown(Keys.Enter))
                    {
                        Game1.currentGameState = GameState.Options;
                    }
                    break;
            }
        }

        //Options Button Switch
        public void OptionButtonSwitch(KeyboardState key)
        {
            
            switch (currentOptionButtonState)
            {
                case OptionButtonState.ActiveEasy:
                    if (key.IsKeyDown(Keys.Down))
                    {
                        currentOptionButtonState = OptionButtonState.ActiveMedium;
                    }
                    else if (key.IsKeyDown(Keys.Up))
                    {
                        currentOptionButtonState = OptionButtonState.ActiveCancel;
                    }
                    else if (key.IsKeyDown(Keys.Enter))
                    {
                        //Put code to switch difficulty
                        Game1.currentGameState = GameState.Menu;
                    }
                    break;
                case OptionButtonState.ActiveMedium:
                    if (key.IsKeyDown(Keys.Down))
                    {
                        currentOptionButtonState = OptionButtonState.ActiveHard;
                    }
                    else if (key.IsKeyDown(Keys.Up))
                    {
                        currentOptionButtonState = OptionButtonState.ActiveEasy;
                    }
                    else if (key.IsKeyDown(Keys.Enter))
                    {
                        //Put code to switch difficulty
                        Game1.currentGameState = GameState.Menu;
                    }
                    break;
                case OptionButtonState.ActiveHard:
                    if (key.IsKeyDown(Keys.Down))
                    {
                        currentOptionButtonState = OptionButtonState.ActiveCancel;
                    }
                    else if (key.IsKeyDown(Keys.Up))
                    {
                        currentOptionButtonState = OptionButtonState.ActiveMedium;
                    }
                    else if (key.IsKeyDown(Keys.Enter))
                    {
                        //Put code to switch difficulty
                        Game1.currentGameState = GameState.Menu;
                    }
                    break;
                case OptionButtonState.ActiveCancel:
                    if (key.IsKeyDown(Keys.Down))
                    {
                        currentOptionButtonState = OptionButtonState.ActiveEasy;
                    }
                    else if (key.IsKeyDown(Keys.Up))
                    {
                        currentOptionButtonState = OptionButtonState.ActiveHard;
                    }
                    else if (key.IsKeyDown(Keys.Enter))
                    {
                        Game1.currentGameState = GameState.Menu;
                    }
                    break;
            }
        }

        //Pause Button Switch
        public void PauseButtonSwitch(KeyboardState key)
        {
            switch (currentPauseButtonState)
            {
                case PauseButtonState.ActiveResume:
                    if (key.IsKeyDown(Keys.Right) == true)
                    {
                        currentPauseButtonState = PauseButtonState.ActiveQuit;
                    }
                    else if (key.IsKeyDown(Keys.Enter) == true)
                    {
                        Game1.currentGameState = GameState.PlayGame;
                    }
                    break;
                case PauseButtonState.ActiveQuit:
                    if (key.IsKeyDown(Keys.Left) == true)
                    {
                        currentPauseButtonState = PauseButtonState.ActiveResume;
                    }
                    else if (key.IsKeyDown(Keys.Enter) == true)
                    {
                        //take to Warning Button state. Create one.
                    }
                    break;
            }
        }
    }
}
