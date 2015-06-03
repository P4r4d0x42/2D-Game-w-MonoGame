using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace InputWrapper
{
    internal struct AllInputButtons
    {
        private const Keys kA_ButtonKey = Keys.K;
        private const Keys kB_ButtonKey = Keys.L;
        private const Keys kX_ButtonKey = Keys.J;
        private const Keys kY_ButtonKey = Keys.I;
        private const Keys kBack_ButtonKey = Keys.F1;
        private const Keys kStart_ButtonKey = Keys.F2;


        private ButtonState GetState(ButtonState gameButtonState, Keys key)
        {
            if (Keyboard.GetState().IsKeyDown(key))
                return ButtonState.Pressed;

            if (GamePad.GetState(PlayerIndex.One).IsConnected)
                return gameButtonState;

            return ButtonState.Released;

        }

        // Assessors
        public ButtonState A
        {
            get {return GetState(GamePad.GetState(PlayerIndex.One).Buttons.A, kA_ButtonKey);}
        }

        public ButtonState B
        {
            get { return GetState(GamePad.GetState(PlayerIndex.One).Buttons.B, kB_ButtonKey); }
        }

        public ButtonState Back
        {
            get { return GetState(GamePad.GetState(PlayerIndex.One).Buttons.Back, kBack_ButtonKey); }
        }

        public ButtonState Start
        {
            get { return GetState(GamePad.GetState(PlayerIndex.One).Buttons.Start, kStart_ButtonKey); }
        }

        public ButtonState X
        {
            get { return GetState(GamePad.GetState(PlayerIndex.One).Buttons.X, kX_ButtonKey); }
        }

        public ButtonState Y
        {
            get { return GetState(GamePad.GetState(PlayerIndex.One).Buttons.Y, kY_ButtonKey); }
        }
    }

    internal struct AllInputTriggers
    {
        private const Keys KLeftTrigger = Keys.N;
        private const Keys KRightTrigger = Keys.M;
        const float kKeyTriggerValue = 0.75f;

        private float GetTriggerState(float gamePadTrigger, Keys key)
        {
            if (Keyboard.GetState().IsKeyDown(key)) // checks for keyboard input first and overrides the game pad if found
                return kKeyTriggerValue;

            if(GamePad.GetState(PlayerIndex.One).IsConnected)
                return gamePadTrigger;

            return 0f; // If you get here, it's not in use
        }


        public float Left
        {
            get { return GetTriggerState(GamePad.GetState(PlayerIndex.One).Triggers.Left, KLeftTrigger);}
        }

        public float Right
        {
            get { return GetTriggerState(GamePad.GetState(PlayerIndex.One).Triggers.Right, KRightTrigger); }
        }

    }

    internal struct AllThumbSticks
    {
        private const Keys kLeftThumbStickUp = Keys.W;
        private const Keys kLeftThumbStickDown = Keys.S;
        private const Keys kLeftThumbStickLeft = Keys.A;
        private const Keys kLeftThumbStickRight = Keys.D;

        private const Keys kRightThumbStickUp = Keys.Up;
        private const Keys kRightThumbStickDown = Keys.Down;
        private const Keys kRightThumbStickLeft = Keys.Left;
        private const Keys kRightThumbStickRight = Keys.Right;

        private const float kKeyDownValue = 0.75f;

        private Vector2 ThumbStickState(Vector2 thumbStickValue,
                                Keys up, Keys down, Keys left, Keys right)
        {
            Vector2 r = new Vector2(0f, 0f);
            if ((GamePad.GetState(PlayerIndex.One).IsConnected)) // TODO: See why there are two () here instead of the normal single of an if statement. Is it some sort of formatting convention?
            {
                r = thumbStickValue;
            }
            if (Keyboard.GetState().IsKeyDown(up)) // checks for keyboard input first and overrides the game pad if found
                r.Y += kKeyDownValue;
            if (Keyboard.GetState().IsKeyDown(down)) // checks for keyboard input first and overrides the game pad if found
                r.Y -= kKeyDownValue;
            if (Keyboard.GetState().IsKeyDown(left)) // checks for keyboard input first and overrides the game pad if found
                r.X -= kKeyDownValue;
            if (Keyboard.GetState().IsKeyDown(right)) // checks for keyboard input first and overrides the game pad if found
                r.X += kKeyDownValue;

            return r;
        }

        public Vector2 Left
        {
            get { 
                return ThumbStickState(GamePad.GetState(PlayerIndex.One).ThumbSticks.Left, 
                kLeftThumbStickUp,kLeftThumbStickDown,
                kLeftThumbStickLeft,kLeftThumbStickRight); 
            }
        }

        public Vector2 Right
        {
            get
            {
                return ThumbStickState(GamePad.GetState(PlayerIndex.One).ThumbSticks.Right,
                kRightThumbStickUp, kRightThumbStickDown,
                kRightThumbStickLeft, kRightThumbStickRight);
            }
        }
    }




    static class InputWrapper
    {
        static public AllInputButtons Buttons = new AllInputButtons();
        static public AllThumbSticks ThumbSticks = new AllThumbSticks();
        static public AllInputTriggers Triggers = new AllInputTriggers();
    }


    // TODO: Left of on step 5 Page 38. Not sure if this is supposed to be in the previous project or it's own. Sort that shit out.
}
