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
        // TODO: Return to page 44 and continue from there






    }




    class InputWrapper
    {
    }


}
