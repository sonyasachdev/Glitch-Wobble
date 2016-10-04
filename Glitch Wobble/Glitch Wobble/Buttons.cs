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
    class Buttons
    {
        //Enums
        enum MenuButtonState
        {
            ActivePlayButton,
            ActiveOptionButton,

            IdlePlayButton,
            IdleOptionButton
        }
        MenuButtonState currentMenuButtonState;
        enum OptionButtonState
        {
            ActiveEasy,
            ActiveMedium,
            ActiveHard,
            ActiveCancel,

            IdleEasy,
            IdleMedium,
            IdleHard,
            IdleCancel
        }
        OptionButtonState currentOptionButtonState;

        //Constructors
        public Buttons()
        {
            currentMenuButtonState = MenuButtonState.ActivePlayButton;
            currentOptionButtonState = OptionButtonState.ActiveEasy;
        }

        //Ask how to switch another class' gamestate externally
        //Menu Button Switch

        /*
        public void MenuButtonSwitch(KeyboardState key, Game1 gameState)
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
                        currentGameState = GameState.PlayGame;
                    }
                    break;
                case MenuButtonState.ActiveOptionButton:

                    if (key.IsKeyDown(Keys.Up))
                    {
                        currentMenuButtonState = MenuButtonState.ActivePlayButton;
                    }
                    else if (key.IsKeyDown(Keys.Enter))
                    {
                        currentGameState = GameState.Options;
                    }
                    break;
            }
        }
        //Options Button Switch
        public void OptionButtonSwitch()
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
                        currentGameState = GameState.Menu;
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
                        currentGameState = GameState.Menu;
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
                        currentGameState = GameState.Menu;
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
                        currentGameState = GameState.Menu;
                    }
                    break;
            }
        }
            */
    }
}
